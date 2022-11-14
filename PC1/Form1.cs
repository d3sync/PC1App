using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PC1.Data;
using PC1.Models;
using PC1.Properties;

namespace PC1;

public partial class Form1 : Form
{
    private readonly DbContextDb _context;
    private bool editOn;
    private string fileStr;

    public Form1(DbContextDb context)
    {
        _context = context;
        InitializeComponent();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var dbFilePath = Settings.Default.dailyFolder;
        if (!File.Exists(@$"{dbFilePath}\PC1db.sqlite")) SQLiteConnection.CreateFile(@$"{dbFilePath}\PC1db.sqlite");
        //db.AddDParcel("'23231323', '4654654654', '21/08/22', 'Alex', '23.20', 'ΑΛΠ-ΔΑ', '21/08/22'");
        eisMetaforan.Text = NextDinero.ToString();
        ekMetaforas.Text = LastDinero.ToString();
    }

    public double LastDinero
    {
        get => Settings.Default.lastdinero;
        set
        {
            Settings.Default.lastdinero = value;
            Settings.Default.Save();
            ekMetaforas.Text = value.ToString();
        }
    }

    public double NextDinero
    {
        get => Settings.Default.nextdinero;
        set
        {
            Settings.Default.nextdinero = value;
            Settings.Default.Save();
            eisMetaforan.Text = value.ToString();
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        if (Settings.Default.UpgradeV <= 1000)
        {
            var pathSql = @$"{Settings.Default.dailyFolder}\PC1db.sqlite";
            if (File.Exists(pathSql))
                try
                {
                    File.Copy(pathSql,
                        pathSql.Replace("PC1db.sqlite", $"backedup-{DateTime.Now.ToString("ddMMyy")}PC1db.sqlite"));
                }
                catch
                {
                }

            _context.Database.ExecuteSqlRaw(
                "CREATE TABLE IF NOT EXISTS Delivered (id INTEGER PRIMARY KEY AUTOINCREMENT,parcelno TEXT NOT NULL, general_numeration TEXT NOT NULL, procDate TEXT NOT NULL, name TEXT NOT NULL, price TEXT NOT NULL, dc_type TEXT NOT NULL, regDate TEXT NOT NULL)");
            _context.Database.ExecuteSqlRaw(
                "CREATE TABLE IF NOT EXISTS ReceivedParcels (id TEXT PRIMARY KEY,ParcelBarcode TEXT,InvBarcode TEXT,VoucherBarcode TEXT,Name TEXT,Address TEXT,Price TEXT,Phone TEXT,Phone2 TEXT,COMMENTS TEXT,ArrivalDate TEXT, IsCompleted INTEGER)");
            _context.Database.ExecuteSqlRaw(
                "CREATE TABLE IF NOT EXISTS Parcels (id INTEGER PRIMARY KEY AUTOINCREMENT, ParcelBarcode TEXT, InvBarcode TEXT, VoucherBarcode TEXT, Name TEXT, Address TEXT, Price TEXT, Driver TEXT, regDate TEXT);");
            Settings.Default.UpgradeV = 1001;
            Settings.Default.Save();
            MessageBox.Show(
                $"Έγινε αναβάθμιση της βάσης δεδομένων. Δημιουργήθηκε ένα αρχείο backup της προηγούμενης βάσης {pathSql.Replace("PC1db.sqlite", $"backedup-{DateTime.Now.ToString("ddMMyy")}PC1db.sqlite")}");
        }
    }

    private void submitBtn_Click(object sender, EventArgs e)
    {
        var contPerform = true;
        foreach (Control c in groupBox1.Controls)
            if (c is TextBox)
            {
                var textBox = c as TextBox;
                if (textBox.Text == "")
                {
                    textBox.Focus();
                    contPerform = false;
                }
            }

        if (contPerform)
        {
            var regex = new Regex("^[a-zA-Zα-ωΑ-Ω.,]+$");
            var hasOnlyAlpha = regex.IsMatch(txtPrice.Text);
            if (hasOnlyAlpha)
            {
                txtPrice.Text = txtPrice.Text.Replace('.', ' ');
                txtPrice.Text = txtPrice.Text.Replace(',', ' ');
                txtPrice.Text = txtPrice.Text.Replace(" ", string.Empty);
            }

            if (editOn == false)
            {
                listView1.Items.Add(
                    new ListViewItem(
                        new[]
                        {
                            txtParcelNo.Text,
                            txtGeneralNumeration.Text,
                            procDate.Value.ToString("dd/MM/yy"),
                            txtName.Text,
                            txtPrice.Text,
                            cmbType.Text,
                            deliveredDate.Value.ToString("dd/MM/yy")
                        })
                );
                _context.DeliveredModel.Add(new DeliveredModel
                {
                    parcelno = txtParcelNo.Text,
                    general_numeration = txtGeneralNumeration.Text,
                    procDate = procDate.Value.ToString("dd/MM/yy"),
                    name = txtName.Text,
                    price = txtPrice.Text,
                    dc_type = cmbType.Text,
                    regDate = deliveredDate.Value.ToString("dd/MM/yy")
                });
                _context.SaveChanges();
            }
            else
            {
                var rr = _context.DeliveredModel.FirstOrDefault(x =>
                    x.parcelno == listView1.SelectedItems[0].SubItems[0].Text ||
                    x.general_numeration == txtGeneralNumeration.Text);
                if (rr != null)
                {
                    listView1.SelectedItems[0].SubItems[0].Text = txtParcelNo.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = txtGeneralNumeration.Text;
                    listView1.SelectedItems[0].SubItems[2].Text = procDate.Value.ToString("dd/MM/yy");
                    listView1.SelectedItems[0].SubItems[3].Text = txtName.Text;
                    listView1.SelectedItems[0].SubItems[4].Text = txtPrice.Text.Replace(",", ".");
                    listView1.SelectedItems[0].SubItems[5].Text = cmbType.Text;
                    listView1.SelectedItems[0].SubItems[6].Text = deliveredDate.Value.ToString("dd/MM/yy");
                    rr.parcelno = txtParcelNo.Text;
                    rr.general_numeration = txtGeneralNumeration.Text;
                    rr.procDate = procDate.Value.ToString("dd/MM/yy");
                    rr.name = txtName.Text;
                    rr.price = txtPrice.Text;
                    rr.dc_type = cmbType.Text;
                    rr.regDate = deliveredDate.Value.ToString("dd/MM/yy");
                    _context.DeliveredModel.Update(rr);
                    _context.SaveChanges();
                    editOn = false;
                    listView1.SelectedIndices.Clear();
                }
            }

            txtParcelNo.Text = txtGeneralNumeration.Text = txtName.Text = txtPrice.Text = "";
            procDate.ResetText();
            txtParcelNo.Focus();
            txtParcelNo.BackColor = Color.White;
            cmbType.BackColor = Color.White;
        }
        else
        {
            MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtParcelNo.Text = txtGeneralNumeration.Text = txtName.Text = txtPrice.Text = "";
        procDate.ResetText();
        editOn = false;
        txtParcelNo.BackColor = Color.White;
        cmbType.BackColor = Color.White;
    }
    //EDIT FROM LISTVIEW
    private void toolStripMenuItem4_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems != null)
        {
            txtParcelNo.Text = listView1.SelectedItems[0].SubItems[0].Text;
            if (txtParcelNo.Text == "Add Manually")
            {
                txtParcelNo.BackColor = Color.Brown; 
                cmbType.BackColor = Color.Brown; 
                txtParcelNo.Clear();
                listView1.SelectedItems[0].BackColor = Color.White;
            }
            txtGeneralNumeration.Text = listView1.SelectedItems[0].SubItems[1].Text;
            procDate.Value = DateTime.Parse(listView1.SelectedItems[0].SubItems[2].Text);
            txtName.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtPrice.Text = listView1.SelectedItems[0].SubItems[4].Text;
            cmbType.Text = listView1.SelectedItems[0].SubItems[5].Text;
            deliveredDate.Value = DateTime.Parse(listView1.SelectedItems[0].SubItems[6].Text);
            editOn = true;
        }
    }
    //DELETE FROM LISTVIEW
    private void toolStripMenuItem5_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems != null) listView1.SelectedItems[0].Remove();
    }

    private void toolStripMenuItem6_Click(object sender, EventArgs e)
    {
        //save to file
        btnSaveExcel.PerformClick();
    }

    private void toolStripMenuItem7_Click(object sender, EventArgs e)
    {
        //open file
    }

    private void toolStripMenuItem8_Click(object sender, EventArgs e)
    {
        //save and send
    }

    private void button1_Click(object sender, EventArgs e)
    {
        UseWaitCursor = true;
        var path = Settings.Default.dailyFolder;
        //MessageBox.Show(path);
        var store = Settings.Default.storeName;
        fileStr = @$"{path}\PC1 ΗΜΕΡΗΣΙΟ {store} {DateTime.Now.ToString("MMMM yyyy").ToUpper()}.xlsx";
        var file = new FileInfo(fileStr);
        using (var package = new ExcelPackage(file))
        {
            try
            {
                package.Workbook.Worksheets.Add($"{DateTime.Now.ToString("dd-MM")}");
            }
            catch (InvalidOperationException)
            {
                package.Workbook.Worksheets.Delete($"{DateTime.Now.ToString("dd-MM")}");
                package.Workbook.Worksheets.Add($"{DateTime.Now.ToString("dd-MM")}");
            }

            var count = package.Workbook.Worksheets.Count;
            var ws = package.Workbook.Worksheets[count - 1];

            ws.Cells["A1:B1"].Merge = true;
            ws.Cells["C1"].Value = $"VFS {store}";
            ws.Cells["G1"].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            ws.Cells["G1"].Style.Font.Bold = true;
            ws.Cells["G1"].Value = DateTime.Now.ToString("dd/MM/yyyy");
            var range = ws.Cells["A1"].Value = "PC1 Ημερήσιο";
            ws.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["A1:G1"].Style.Font.Color.SetColor(Color.LightGray);
            ws.Cells["A1:G1"].Style.Fill.BackgroundColor.SetColor(Color.Firebrick);
            ws.Cells["A1"].AutoFitColumns();
            ws.Cells["A2"].Value = "ΦΥΛΛΟ ΣΥΝΑΛΛΑΓΩΝ";
            ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A2:G2"].Merge = true;
            ws.Cells["A3"].Value = "Εισπράξεις - ΠΑΡΑΔΟΣΕΙΣ";
            ws.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A3:G3"].Merge = true;
            ws.Cells["A4"].Value = "Αρ. Παραστατικού";
            ws.Cells["B4"].Value = "Γεν. Αρίθμιση";
            ws.Cells["C4"].Value = "Ημ τιμολόγισης";
            ws.Cells["D4"].Value = "Επωνυμία";
            ws.Cells["E4"].Value = "Ποσό";
            ws.Cells["F4"].Value = "Τύπος Παρ/κού";
            ws.Cells["G4"].Value = "Ημ/νία Καταχώρησης";
            ws.Cells["A2:G4"].Style.Font.Bold = true;
            ws.Cells["A2:G4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["A2:G4"].Style.Font.Color.SetColor(Color.LightGray);
            ws.Cells["A2:G4"].Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
            ws.Cells["A1:G4"].AutoFitColumns();
            var i = 5; // Αρχικό κελή
            var column = Convert.ToChar('A');
            double sum = 0;
            foreach (ListViewItem vitem in listView1.Items)
            {
                var line = "";
                var ii = 0;
                foreach (ListViewItem.ListViewSubItem eitem in vitem.SubItems)
                {
                    line += $"'{eitem.Text}',";
                    column = Convert.ToChar('A' + ii);
                    if (eitem.Text.Contains(".") || eitem.Text.Contains(","))
                    {
                        eitem.Text = eitem.Text.Replace('.', ',');
                        eitem.Text = eitem.Text.Replace(',', ',');
                        ws.Cells[$"{column}{i}"].Style.Numberformat.Format = "€#,##0.00";
                        ws.Cells[$"{column}{i}"].Value = Convert.ToDouble(eitem.Text);
                    }
                    else
                    {
                        ws.Cells[$"{column}{i}"].Value = eitem.Text;
                    }

                    if (ii == 4)
                        try
                        {
                            sum += Convert.ToDouble(eitem.Text);
                        }
                        catch
                        {
                        }

                    ii++;
                }

                i++;
                line = line.TrimEnd(',');
                //try
                //{
                //    db.AddDParcel(line);
                //}
                //catch
                //{
                //    //todo
                //    MessageBox.Show("Something went bad while trying to to insert into the db");
                //}
                ////richTextBox1.Text += line + "\r\n";
            }

            NextDinero = sum;
            ws.Cells[$"A5:{column}{i}"].AutoFitColumns();
            //ws.Cells[$"E{i + 1}"].Value = $"=SUM(E2:{column}{i})";
            ws.Cells[$"F{i + 1}"].Value = "ΣΥΝΟΛΟ";
            ws.Cells[$"F{i + 1}"].Style.Font.Bold = true;
            ws.Cells[$"G{i + 1}"].Style.Numberformat.Format = "€#,##0.00";
            ws.Cells[$"G{i + 1}"].Formula = $"=SUM(E5:E{i})";
            ws.Cells[$"A{i + 1}:G{i + 1}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[$"A{i + 1}:G{i + 1}"].Style.Font.Color.SetColor(Color.LightGray);
            ws.Cells[$"A{i + 1}:G{i + 1}"].Style.Fill.BackgroundColor.SetColor(Color.Firebrick);
            ws.Cells[$"A{i + 3}"].Value = "ΠΑΡΑΔΟΣΗ ΧΡΗΜΑΤΩΝ ΣΕ ΟΔΗΓΟ Ή ΚΑΤΑΘΕΣΗ";
            ws.Cells[$"A{i + 3}:G{i + 3}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[$"A{i + 3}:G{i + 3}"].Style.Font.Color.SetColor(Color.LightGray);
            ws.Cells[$"A{i + 3}:G{i + 3}"].Style.Fill.BackgroundColor.SetColor(Color.Firebrick);
            ws.Cells[$"A{i + 3}:G{i + 3}"].Merge = true;
            ws.Cells[$"A{i + 4}"].Value = "Ημερομηνία Παραλαβής:";
            ws.Cells[$"C{i + 4}"].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            ws.Cells[$"C{i + 4}"].Value = DateTime.Now.ToString("dd/MM/yyyy");
            ws.Cells[$"C{i + 4}"].AddComment("Αλλάξτε Ημερομηνία αν διαφέρει...", "Αλέξανδρος");
            ws.Cells[$"D{i + 4}"].Value = "Σύνολο Μετρητών:";
            ws.Cells[$"G{i + 4}"].Style.Numberformat.Format = "€#,##0.00";
            ws.Cells[$"G{i + 4}"].Value = $"{LastDinero}";
            ws.Cells[$"A{i + 4}:G{i + 4}"].Style.Font.Bold = true;
            ws.Cells[$"A{i + 5}:G{i + 5}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[$"A{i + 5}:G{i + 5}"].Style.Font.Color.SetColor(Color.LightGray);
            ws.Cells[$"A{i + 5}:G{i + 5}"].Style.Fill.BackgroundColor.SetColor(Color.Firebrick);

            ws.Cells[$"A{i + 7}:G{i + 10}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[$"A{i + 7}:G{i + 10}"].Style.Font.Color.SetColor(Color.LightGray);
            ws.Cells[$"A{i + 7}:G{i + 10}"].Style.Fill.BackgroundColor.SetColor(Color.Firebrick);
            ws.Cells[$"A{i + 7}:G{i + 10}"].Style.Font.Bold = true;
            ws.Cells[$"A{i + 7}:G{i + 10}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[$"A{i + 7}"].Value = "Υπόλοιπο ταμείου     (εκ μεταφοράς)";
            ws.Cells[$"G{i + 7}"].Style.Numberformat.Format = "€#,##0.00";
            ws.Cells[$"G{i + 7}"].Value = LastDinero;
            ws.Cells[$"A{i + 8}"].Value = "Εισπράξεις ημέρας:";
            ws.Cells[$"G{i + 8}"].Style.Numberformat.Format = "€#,##0.00";
            ws.Cells[$"G{i + 8}"].Value = NextDinero;
            ws.Cells[$"A{i + 9}"].Value = "Πληρωμές ημέρας:";
            ws.Cells[$"G{i + 9}"].Style.Numberformat.Format = "€#,##0.00";
            ws.Cells[$"G{i + 9}"].Value = LastDinero;
            ws.Cells[$"A{i + 10}"].Value = "Υπόλοιπο ημέρας     (εις μεταφοράν)";
            //ws.Cells[$"G{i + 10}"].Value = this.NextDinero;
            ws.Cells[$"G{i + 10}"].Style.Numberformat.Format = "€#,##0.00";
            ws.Cells[$"G{i + 10}"].Formula = $"=G{i + 7}+G{i + 8}-G{i + 9}";
            NextDinero = ws.Cells[$"G{i + 10}"].GetValue<float>();
            NextDinero = sum;
            ws.Cells[$"A{i + 7}:F{i + 7}"].Merge = true;
            ws.Cells[$"A{i + 8}:F{i + 8}"].Merge = true;
            ws.Cells[$"A{i + 9}:F{i + 9}"].Merge = true;
            ws.Cells[$"A{i + 10}:F{i + 10}"].Merge = true;

            var worksheet = ws.Workbook.Worksheets[ws.Workbook.Worksheets.Count - 1];
            ws.PrinterSettings.Orientation = eOrientation.Landscape;
            worksheet.Workbook.Properties.Author = "d3sync";

            try
            {
                package.Save();
                //FileInfo excel = new FileInfo($"{file}");
                eisMetaforan.Text = NextDinero.ToString();
                ekMetaforas.Text = LastDinero.ToString();
                LastDinero = NextDinero;
                NextDinero = 0;
                Settings.Default.lastdinero = LastDinero;
                Settings.Default.nextdinero = NextDinero;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning Issue!");
            }
        }

        UseWaitCursor = false;
    }

    private void toolStripMenuItem9_Click(object sender, EventArgs e)
    {
        var settings = new PC1Settings();
        settings.Show();
    }

    private void txtParcelNo_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;

        // only allow one decimal point
        if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) e.Handled = true;
    }

    private void txtGeneralNumeration_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;

        // only allow one decimal point
        if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) e.Handled = true;
    }

    private void openExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Process.Start("explorer.exe", fileStr);
        }
        catch
        {
            MessageBox.Show("Possible 404 (Not Found) situation!");
        }
    }

    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        var current = (TextBox)sender;
        if (e.KeyChar == '.')
        {
            e.Handled = true;
            current.Text += ",";
            current.SelectionStart = current.Text.Length;
            current.SelectionLength = 0;
        }

        if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1) e.Handled = true;
    }

    private void toolStripMenuItem11_Click(object sender, EventArgs e)
    {
        var dvForm = new DataViewer(_context);
        dvForm.Show();
    }

    private void assignDriverToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_context != null)
        {
            DriversLoad drvForm = new(_context);
            drvForm.Show();
        }
    }

    private void eisMetaforan_TextChanged(object sender, EventArgs e)
    {
        try
        {
            NextDinero = Convert.ToDouble(eisMetaforan.Text);
        }
        catch
        {
        }
    }

    private void ekMetaforas_TextChanged(object sender, EventArgs e)
    {
        try
        {
            LastDinero = Convert.ToDouble(ekMetaforas.Text);
        }
        catch
        {
        }
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        var currentContainer = (TextBox)sender;
        var caretPosition = currentContainer.SelectionStart;
        currentContainer.Text = currentContainer.Text.ToUpper();
        currentContainer.SelectionStart = caretPosition++;
    }

    public void AddToLV(ReceivedParcels rp)
    {
        
            var lvi = new ListViewItem(
                new[]
                {
                    "Add Manually",
                    rp.InvBarcode,
                    DateTime.ParseExact(rp.ArrivalDate, "dd/MM/yy", CultureInfo.InvariantCulture).AddDays(-1)
                        .ToString(),
                    rp.Name,
                    rp.Price,
                    "ΑΛΠ-ΔΑ",
                    DateTime.Now.ToString("dd/MM/yy")
                });
            lvi.BackColor = Color.Lavender;
            listView1.Items.Add(lvi);
    }

    private void παραλαβήΔεμάτωνToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ReceiveParcels rpForm = new(_context, this);
        rpForm.Show();
    }
}