using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC1.Data;
using PC1.Models;

namespace PC1
{
    public partial class DriversLoad : Form
    {
        private readonly DbContextDb _context;
        bool EditOn = false;
        int EditID;
        public DriversLoad(DbContextDb context)
        {
            InitializeComponent();
            _context = context;
        }

        // Method that moves to the next control in the Form by pressing Enter or Return
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (sender.GetType() is IButtonControl) {
                    btnSubmit.PerformClick();
                }
                else
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                var dd = _context.AssignedtoModel.Where(m => m.regDate == datePicker.Value.ToString("dd/MM/yy")).ToList();
                //var rr = db.GetLoadedDataByDate();
                foreach (var item in dd)
                {//ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
                        listView1.Items.Add(
                            new ListViewItem(
                                new string[] { item.id.ToString(), item.ParcelBarcode, item.InvBarcode, item.VoucherBarcode, item.Name, item.Price }
                                ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3}", ex.Message, ex.StackTrace, ex.Data, ex.Source);
                //something went wrong
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        { //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
            if (!EditOn)
            {
                //var line = $"'{txtParcelBC.Text}','{txtGeneralNumBC.Text}','{txtVoucherBC.Text}','{txtName.Text}','{txtAddress.Text}','{txtPrice.Text}','{txtDriver.Text}','{DateTime.Now.ToString("dd/MM/yy")}'";
                //db.AddAssignedTo(line);
                _context.AssignedtoModel.Add(
                    new AssignedtoModel()
                    {
                        ParcelBarcode = txtParcelBC.Text,
                        InvBarcode = txtGeneralNumBC.Text,
                        VoucherBarcode = txtVoucherBC.Text,
                        Name = txtName.Text,
                        Price = txtPrice.Text,
                        Address = txtAddress.Text,
                        Driver = txtDriver.Text,
                        regDate = DateTime.Now.ToString("dd/MM/yy")
                    });
                _context.SaveChanges();
                //MessageBox.Show(line);
                listView1.Items.Add(
                new ListViewItem( //{txtParcelBC.Text},{txtGeneralNumBC.Text},{txtVoucherBC.Text},{txtName.Text},{txtAddress.Text},{txtPrice.Text}
                    new string[] { "N/A", txtParcelBC.Text, txtGeneralNumBC.Text, txtVoucherBC.Text, txtName.Text, txtPrice.Text }
                ));
            }
            else
            {
                if (EditID != -1)
                {
                    //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver
                    var line = $"" +
                        $"ParcelBarcode='{txtParcelBC.Text}'," +
                        $"InvBarcode='{txtGeneralNumBC.Text}'," +
                        $"VoucherBarcode='{txtVoucherBC.Text}'," +
                        $"Name='{txtName.Text}'," +
                        $"Address='{txtAddress.Text}'," +
                        $"Price='{txtPrice.Text}'," +
                        $"Driver='{txtDriver.Text}'";
                    //db.UpdateIntoID("Parcels", line, EditID);
                    var ad = new AssignedtoModel()
                    {
                        ParcelBarcode=txtParcelBC.Text,
                        InvBarcode=txtGeneralNumBC.Text,
                        VoucherBarcode=txtVoucherBC.Text,
                        Name=txtName.Text,
                        Address=txtAddress.Text,
                        Price=txtPrice.Text,
                        Driver=txtDriver.Text
                    };
                    _context.Update(ad);
                    _context.SaveChanges();

                }
                EditOn = false;
                EditID = -1;
                btnSearch.PerformClick();                
            }
            txtAddress.Text = txtGeneralNumBC.Text = txtGeneralNumBC.Text = txtName.Text = txtParcelBC.Text = txtVoucherBC.Text = txtPrice.Text = "";
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {   
                if (listView1.SelectedItems[0].SubItems[0].Text != "N/A")
                {
                    //var res = db.GetLoadedByID(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                    var res = _context.AssignedtoModel.FirstOrDefault(m =>
                        m.id == Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                    EditID = res.id;
                    EditOn = true;
                    txtParcelBC.Text = res.ParcelBarcode;
                    txtGeneralNumBC.Text = res.InvBarcode;
                    txtVoucherBC.Text = res.VoucherBarcode;
                    txtName.Text = res.Name;
                    txtAddress.Text = res.Address;
                    txtPrice.Text = res.Price;
                    txtDriver.Text = res.Driver;
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox currentContainer = ((TextBox)sender);
            int caretPosition = currentContainer.SelectionStart;

            currentContainer.Text = currentContainer.Text.ToUpper();
            currentContainer.SelectionStart = caretPosition++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rr = _context.AssignedtoModel.Select(m => m.regDate).Distinct().ToList();
            List<DateTime> dates = rr.Select(date => DateTime.Parse(date)).ToList();
            mCalLoad.BoldedDates = dates.ToArray();
        }

        private void mCalLoad_DateSelected(object sender, DateRangeEventArgs e)
        {
            datePicker.Value = mCalLoad.SelectionStart;
            btnSearch.PerformClick();
        }

        private void DriversLoad_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                var res = _context.AssignedtoModel.FirstOrDefault(m => m.id == Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                DialogResult dialogResult = MessageBox.Show($"Θέλετε σίγουρα να διαγράψετε την καταχώρηση {res.id} / {res.Name}?", "Επιβεβαιώστε την διαγραφή", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _context.AssignedtoModel.Remove(res);
                    _context.SaveChanges();
                    listView1.SelectedItems[0].Remove();
                }
                
            }
        }
    }
}
