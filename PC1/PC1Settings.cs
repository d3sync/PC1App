using System;
using System.Windows.Forms;
using PC1.Properties;

namespace PC1;

public partial class PC1Settings : Form
{
    public PC1Settings()
    {
        InitializeComponent();
        textBox1.Text = Settings.Default.dailyFolder;
        textBox2.Text = Settings.Default.storeName;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var res = folderBrowserDialog1.ShowDialog();
        if (res == DialogResult.OK)
        {
            Settings.Default.dailyFolder = textBox1.Text = folderBrowserDialog1.SelectedPath;
            Settings.Default.Save();
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        Settings.Default.dailyFolder = folderBrowserDialog1.SelectedPath;
        Settings.Default.Save();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        Settings.Default.storeName = textBox2.Text;
        Settings.Default.Save();
    }
}