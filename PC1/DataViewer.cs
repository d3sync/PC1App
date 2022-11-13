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
using PC1.Data;
using SQLitePCL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PC1
{
    public partial class DataViewer : Form
    {
        private static DbContextDb _context;
        //private static DatabaseClass dbV;
        public DataViewer(DbContextDb context)
        {
            _context = context;
            InitializeComponent();
            btnRefresh.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                Console.WriteLine($"Attempting to get data for {datePicker.Value.ToString("dd/MM/yy")}");
                //var rr = db.GetDataByDate2(datePicker.Value.ToString("dd/MM/yy"));
                var rr = _context.DeliveredModel.Where(m => m.regDate == datePicker.Value.ToString("dd/MM/yy")).ToList();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var dd = _context.DeliveredModel.Select(m => m.regDate).Distinct().ToList();
            List<DateTime> dates = dd.Select(date => DateTime.Parse(date)).ToList();
            mCalLoad.BoldedDates = dates.ToArray();
        }

        private void mCalLoad_DateSelected(object sender, DateRangeEventArgs e)
        {
            datePicker.Value = mCalLoad.SelectionStart;
            btnSearch.PerformClick();
        }

        private void DataViewer_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }
    }
}
