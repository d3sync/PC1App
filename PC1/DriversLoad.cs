using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC1
{
    public partial class DriversLoad : Form
    {
        private DatabaseClass db;
        bool EditOn = false;
        int EditID;
        public DriversLoad(DatabaseClass Dbi)
        {
            InitializeComponent();
            db = Dbi;
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
                var rr = db.GetLoadedDataByDate(datePicker.Value.ToString("dd/MM/yyyy"));
                foreach (var item in rr)
                {//ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
                        listView1.Items.Add(
                            new ListViewItem(
                                new string[] { item.id.ToString(), item.ParcelBarcode, item.InvBarcode, item.VoucherBarcode, item.Name, item.Price }
                                ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} --- {ex.StackTrace} --- {ex.Data} --- {ex.Source}");
                //something went wrong
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        { //ParcelBarcode,InvBarcode,VoucherBarcode,Name,Address,Price,Driver,regDate
            if (!EditOn)
            {
                string line = $"'{txtParcelBC.Text}','{txtGeneralNumBC.Text}','{txtVoucherBC.Text}','{txtName.Text}','{txtAddress.Text}','{txtPrice.Text}','{txtDriver.Text}','{DateTime.Now.ToString("dd/MM/yyyy")}'";
                db.AddAssignedTo(line);
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
                    string line = $"" +
                        $"ParcelBarcode='{txtParcelBC.Text}'," +
                        $"InvBarcode='{txtGeneralNumBC.Text}'," +
                        $"VoucherBarcode='{txtVoucherBC.Text}'," +
                        $"Name='{txtName.Text}'," +
                        $"Address='{txtAddress.Text}'," +
                        $"Price='{txtPrice.Text}'," +
                        $"Driver='{txtDriver.Text}'";
                    db.UpdateIntoID("Parcels", line, EditID);
                }
                EditOn = false;
                EditID = -1;
                btnSubmit.Text = "Καταχώρηση";
                btnSearch.PerformClick();                
            }
            txtAddress.Text = txtGeneralNumBC.Text = txtGeneralNumBC.Text = txtName.Text = txtParcelBC.Text = txtVoucherBC.Text = txtPrice.Text = "";
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {   
                if (listView1.SelectedItems[0].SubItems[0].Text != "N/A")
                {
                    var res = db.GetLoadedByID(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                    EditID = res.id;
                    EditOn = true;
                    txtParcelBC.Text = res.ParcelBarcode;
                    txtGeneralNumBC.Text = res.InvBarcode;
                    txtVoucherBC.Text = res.VoucherBarcode;
                    txtName.Text = res.Name;
                    txtAddress.Text = res.Address;
                    txtPrice.Text = res.Price;
                    txtDriver.Text = res.Driver;
                    btnSubmit.Text = $"Ενημέρωση ID={EditID}";
                }
            }
        }
    }
}
