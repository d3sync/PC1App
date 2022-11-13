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
    public partial class ParcelSettings : Form
    {
        private readonly DbContextDb _context;
        private readonly ReceiveParcels _receiveParcels;
        private ReceivedParcels rr;
        public ParcelSettings(DbContextDb context, string id, ReceiveParcels fr1)
        {
            _receiveParcels = fr1;
            InitializeComponent();
            _context = context;
            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Value";

            var items = new[] {
                new { Text = "ΣΤΟ ΚΑΤΑΣΤΗΜΑ", Value = 0 },
                new { Text = "ΠΑΡΑΔΟΘΗΚΕ", Value = 1 },
                new { Text = "ΠΡΟΣ ΑΚΥΡΩΣΗ", Value = 2 },
                new { Text = "ΑΚΥΡΩΜΕΝΟ", Value = 3 }

            };
            cmbStatus.DataSource = items;
            rr = _context.ReceivedParcels.FirstOrDefault(x => x.id == Guid.Parse(id));
            if (rr != null)
            {
                richTextBox1.Text = rr.Comments;
                cmbStatus.SelectionStart = (int)rr.IsCompleted;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            rr.Comments = richTextBox1.Text;
            rr.IsCompleted = Int32.Parse(cmbStatus.SelectedValue.ToString());
            if (rr.IsCompleted == 3)
            {
                rr.Comments = $"{rr.Comments} ΑΚΥΡΩΘΗΚΕ {DateTime.Now.ToString("d")}";
            }
            _context.ReceivedParcels.Update(rr);
            _context.SaveChanges();
            _receiveParcels.DataLoad("");
            this.Dispose();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
