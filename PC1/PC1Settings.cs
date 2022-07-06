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
    public partial class PC1Settings : Form
    {
        public PC1Settings()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.dailyFolder;
            textBox2.Text = Properties.Settings.Default.storeName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                Properties.Settings.Default.dailyFolder = textBox1.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dailyFolder = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.storeName = textBox2.Text;
            Properties.Settings.Default.Save();
        }
    }
}
