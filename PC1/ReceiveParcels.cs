using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PC1.Data;
using PC1.Models;

namespace PC1;

public partial class ReceiveParcels : Form
{
    private readonly DbContextDb _context;
    private readonly Form1 form;
    private Guid EditID;
    private bool EditOn;

    public ReceiveParcels(DbContextDb context, Form1 form1)
    {
        form = form1;
        _context = context;
        InitializeComponent();
        var rr = _context.ReceivedParcels.Select(m => m.ArrivalDate)
            .Distinct()
            .ToList();
        var dates = rr.Select(date => DateTime.Parse(date)).ToList();
        mCalLoad.BoldedDates = dates.ToArray();
        DataLoad("");
    }

    private void Control_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
        {
            if (sender.GetType() is IButtonControl)
                btnSubmit.PerformClick();
            else
                SelectNextControl((Control)sender, true, true, true, true);
        }
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        var data = new ReceivedParcels
        {
            ParcelBarcode = txtParcelBC.Text,
            InvBarcode = txtGeneralNumBC.Text,
            VoucherBarcode = txtVoucherBC.Text,
            Name = txtName.Text,
            Address = txtAddress.Text,
            Price = txtPrice.Text,
            Phone = txtPhone.Text,
            Phone2 = txtPhone2.Text
        };
        if (EditOn)
        {
            _context.Update(data);
            MessageBox.Show($"Ενημερώθηκε η εγγραφή με ID: {EditID}");
            EditOn = false;
            EditID = Guid.Empty;
        }
        else
        {
            _context.Add(data);
        }

        _context.SaveChanges();
        btnRefresh.PerformClick();
        ClearTextBoxes();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        DataLoad("");
    }

    private void mCalLoad_DateSelected(object sender, DateRangeEventArgs e)
    {
        DataLoad(mCalLoad.SelectionStart.ToString("dd/MM/yy"));
    }

    public void DataLoad(string? date)
    {
        List<ReceivedParcels> rr;
        listView1.Items.Clear();
        try
        {
            if (!string.IsNullOrEmpty(date))
                rr = _context.ReceivedParcels.Where(d => d.ArrivalDate == date).ToList();
            else
                rr = _context.ReceivedParcels.Where(d => d.IsCompleted == 0 || d.IsCompleted == 2).ToList();

            foreach (var item in rr)
            {
                //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate

                var lvi = new ListViewItem(
                    new[]
                    {
                        item.id.ToString(), item.ParcelBarcode, item.InvBarcode, item.VoucherBarcode, item.Name,
                        item.Address, item.Price, item.Phone, item.Phone2, item.Comments, item.ArrivalDate
                    }
                );
                switch (item.IsCompleted)
                {
                    case 0:
                        lvi.BackColor = Color.White;
                        break;
                    case 1:
                        lvi.BackColor = Color.Chartreuse;
                        break;
                    case 2:
                        lvi.BackColor = Color.Brown;
                        break;
                    case 3:
                        lvi.BackColor = Color.Red;
                        break;
                    default:
                        lvi.BackColor = Color.White;
                        break;
                }

                listView1.Items.Add(lvi);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} --- {1} --- {2} --- {3}", ex.Message, ex.StackTrace, ex.Data, ex.Source);
            //something went wrong
        }
    }

    private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;

        // only allow one decimal point
        if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) e.Handled = true;
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        var currentContainer = (TextBox)sender;
        var caretPosition = currentContainer.SelectionStart;
        currentContainer.Text = currentContainer.Text.ToUpper();
        currentContainer.SelectionStart = caretPosition++;
    }

    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        var current = (TextBox)sender;
        if (e.KeyChar is '.' or ',')
        {
            e.Handled = true;
            current.Text += ",";
            current.SelectionStart = current.Text.Length;
            current.SelectionLength = 0;
        }

        if (e.KeyChar is ',' or '.' && (sender as TextBox).Text.IndexOf(',') > -1) e.Handled = true;
    }

    private void ClearTextBoxes()
    {
        Action<Control.ControlCollection> func = null;

        func = controls =>
        {
            foreach (Control control in controls)
                if (control is TextBox)
                    (control as TextBox).Clear();
                else
                    func(control.Controls);
        };

        func(Controls);
    }

    private void ReceiveParcels_Load(object sender, EventArgs e)
    {
    }

    private void cmlv_Edit_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems[0] != null)
        {
            var res = _context.ReceivedParcels.FirstOrDefault(m =>
                m.id == Guid.Parse(listView1.SelectedItems[0].SubItems[0].Text));
            EditID = res.id;
            EditOn = true;
            txtParcelBC.Text = res.ParcelBarcode;
            txtGeneralNumBC.Text = res.InvBarcode;
            txtVoucherBC.Text = res.VoucherBarcode;
            txtName.Text = res.Name;
            txtAddress.Text = res.Address;
            txtPrice.Text = res.Price;
            txtPhone.Text = res.Phone;
            txtPhone2.Text = res.Phone2;
        }
    }

    private void cmlv_Delete_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems[0] != null)
        {
            var res = _context.ReceivedParcels.FirstOrDefault(m =>
                m.id == Guid.Parse(listView1.SelectedItems[0].SubItems[0].Text));
            var dialogResult = MessageBox.Show($"Θέλετε σίγουρα να διαγράψετε την καταχώρηση {res.id} / {res.Name}?",
                "Επιβεβαιώστε την διαγραφή", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _context.ReceivedParcels.Remove(res);
                _context.SaveChanges();
            }
        }
    }

    private void cmlv_Assign_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems[0] != null)
        {
            var res = _context.ReceivedParcels.FirstOrDefault(m =>
                m.id == Guid.Parse(listView1.SelectedItems[0].SubItems[0].Text));
            var d = new AssignedtoModel
            {
                ParcelBarcode = res.ParcelBarcode,
                VoucherBarcode = res.VoucherBarcode,
                InvBarcode = res.InvBarcode,
                Name = res.Name,
                Address = res.Address,
                Price = res.Price,
                regDate = DateTime.Now.ToString("dd/MM/yy")
            };
            _context.AssignedtoModel.Add(d);
            _context.SaveChanges();
        }
    }

    private void cmlv_Status_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems[0] != null)
        {
            ParcelSettings psform = new(_context, listView1.SelectedItems[0].SubItems[0].Text, this);
            psform.Show();
            psform.BringToFront();
        }
        else
        {
            MessageBox.Show("You haven't selected an entry.");
        }
    }

    private void cmlv_SendToForm_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems[0] != null)
            try
            {
                var res = _context.ReceivedParcels.FirstOrDefault(m =>
                    m.id == Guid.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                form.AddToLV(res);
            }
            catch
            {
            }
    }

    private void txtParcelBC_MouseHover(object sender, EventArgs e)
    {
        var current = (TextBox)sender;
        tssLabel.Text = toolTip1.GetToolTip(current);
    }

    private void ReceiveParcels_MouseHover(object sender, EventArgs e)
    {
        tssLabel.Text = "";
    }
}