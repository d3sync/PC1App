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
    public partial class Form1 : Form
    {
        bool editOn = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (editOn == false)
            {
                listView1.Items.Add(
                new ListViewItem(
                    new string[] {
                        txtParcelNo.Text,
                        txtGeneralNumeration.Text,
                        procDate.Value.ToString("dd/MM/yy"),
                        txtName.Text,
                        txtPrice.Text,
                        cmbType.Text,
                        cmbPaymentMethod.Text,
                        deliveredDate.Value.ToString("dd/MM/yy"),
                        txtDriver.Text
                    })
                );
            }
            else
            {
                listView1.SelectedItems[0].SubItems[0].Text = txtParcelNo.Text;
                listView1.SelectedItems[0].SubItems[1].Text = txtGeneralNumeration.Text;
                listView1.SelectedItems[0].SubItems[2].Text = procDate.Value.ToString("dd/MM/yy");
                listView1.SelectedItems[0].SubItems[3].Text = txtName.Text;
                listView1.SelectedItems[0].SubItems[4].Text = txtPrice.Text;
                listView1.SelectedItems[0].SubItems[5].Text = cmbType.Text;
                listView1.SelectedItems[0].SubItems[6].Text = cmbPaymentMethod.Text;
                listView1.SelectedItems[0].SubItems[7].Text = deliveredDate.Value.ToString("dd/MM/yy");
                listView1.SelectedItems[0].SubItems[8].Text = txtDriver.Text;
                editOn = false;
                listView1.SelectedIndices.Clear();
            }
            txtParcelNo.Text = txtGeneralNumeration.Text = txtName.Text = txtPrice.Text = txtDriver.Text = "";
            procDate.ResetText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtParcelNo.Text = txtGeneralNumeration.Text = txtName.Text = txtPrice.Text = txtDriver.Text = "";
            procDate.ResetText();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                txtParcelNo.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtGeneralNumeration.Text = listView1.SelectedItems[0].SubItems[1].Text;
                procDate.Value = DateTime.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                txtName.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtPrice.Text = listView1.SelectedItems[0].SubItems[4].Text;
                cmbType.Text = listView1.SelectedItems[0].SubItems[5].Text;
                cmbPaymentMethod.Text = listView1.SelectedItems[0].SubItems[6].Text;
                deliveredDate.Value =  DateTime.Parse(listView1.SelectedItems[0].SubItems[7].Text);
                txtDriver.Text = listView1.SelectedItems[0].SubItems[8].Text;
                editOn = true;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                listView1.SelectedItems.Clear();
            }
            }
    }
}
