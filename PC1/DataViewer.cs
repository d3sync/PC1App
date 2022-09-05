using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
            listView1.Items.Clear();
            try
            {
                Console.WriteLine($"Attempting to get data for {datePicker.Value.ToString("dd/MM/yy")}");
                var rr = db.GetDataByDate2(datePicker.Value.ToString("dd/MM/yy"));
                foreach (var item in rr)
                {
                    listView1.Items.Add(
                        new ListViewItem(
                            new string[] { item.id.ToString(), item.parcelno, item.general_numeration, item.procDate, item.name, item.price, item.dc_type, item.regDate }
                            ));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} --- {ex.StackTrace} --- {ex.Data} --- {ex.Source}");
                //something went wrong
            }
        }
    }
}
