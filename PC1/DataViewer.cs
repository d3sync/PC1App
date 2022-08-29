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
    public partial class DataViewer : Form
    {
        private DatabaseClass db = new();
        //private static DatabaseClass dbV;
        public DataViewer()
        {
            InitializeComponent();
            db.connect();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine($"Attempting to get data for {datePicker.Value.ToString("dd/MM/yyyy")}");
                var rr = db.GetDataByDate(datePicker.Value.ToString("dd/MM/yyyy"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} --- {ex.StackTrace} --- {ex.Data} --- {ex.Source}");
                //something went wrong
            }
        }
    }
}
