
namespace PC1
{
    partial class DriversLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversLoad));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.mCalLoad = new System.Windows.Forms.MonthCalendar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtVoucherBC = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtGeneralNumBC = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtParcelBC = new System.Windows.Forms.TextBox();
            this.assignedtoModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.parcelno = new System.Windows.Forms.ColumnHeader();
            this.invCode = new System.Windows.Forms.ColumnHeader();
            this.voucherCode = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.price = new System.Windows.Forms.ColumnHeader();
            this.Driver = new System.Windows.Forms.ColumnHeader();
            this.cntMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource)).BeginInit();
            this.cntMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.mCalLoad);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.txtDriver);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtVoucherBC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtGeneralNumBC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtParcelBC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 450);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::PC1.Properties.Resources.refresh_1_;
            this.button1.Location = new System.Drawing.Point(11, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 41);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mCalLoad
            // 
            this.mCalLoad.Location = new System.Drawing.Point(67, 270);
            this.mCalLoad.MaxSelectionCount = 1;
            this.mCalLoad.Name = "mCalLoad";
            this.mCalLoad.TabIndex = 15;
            this.mCalLoad.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mCalLoad_DateSelected);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.Image = global::PC1.Properties.Resources.icons8_enter_key_50;
            this.btnSubmit.Location = new System.Drawing.Point(114, 209);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(172, 49);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // txtDriver
            // 
            this.txtDriver.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource6, "Driver", true));
            this.txtDriver.Location = new System.Drawing.Point(114, 180);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(172, 23);
            this.txtDriver.TabIndex = 13;
            this.txtDriver.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtDriver.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource6
            // 
            this.assignedtoModelBindingSource6.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Οδηγός";
            // 
            // txtPrice
            // 
            this.txtPrice.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource5, "Price", true));
            this.txtPrice.Location = new System.Drawing.Point(114, 151);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(172, 23);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource5
            // 
            this.assignedtoModelBindingSource5.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ποσό";
            // 
            // txtAddress
            // 
            this.txtAddress.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource4, "Address", true));
            this.txtAddress.Location = new System.Drawing.Point(114, 122);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(172, 23);
            this.txtAddress.TabIndex = 9;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource4
            // 
            this.assignedtoModelBindingSource4.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Διεύθυνση";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource3, "Name", true));
            this.txtName.Location = new System.Drawing.Point(114, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 23);
            this.txtName.TabIndex = 7;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource3
            // 
            this.assignedtoModelBindingSource3.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Όνομα";
            // 
            // txtVoucherBC
            // 
            this.txtVoucherBC.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource2, "VoucherBarcode", true));
            this.txtVoucherBC.Location = new System.Drawing.Point(114, 64);
            this.txtVoucherBC.Name = "txtVoucherBC";
            this.txtVoucherBC.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherBC.TabIndex = 5;
            this.txtVoucherBC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource2
            // 
            this.assignedtoModelBindingSource2.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Voucher Barcode";
            // 
            // txtGeneralNumBC
            // 
            this.txtGeneralNumBC.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource1, "InvBarcode", true));
            this.txtGeneralNumBC.Location = new System.Drawing.Point(114, 35);
            this.txtGeneralNumBC.Name = "txtGeneralNumBC";
            this.txtGeneralNumBC.Size = new System.Drawing.Size(172, 23);
            this.txtGeneralNumBC.TabIndex = 3;
            this.txtGeneralNumBC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource1
            // 
            this.assignedtoModelBindingSource1.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "R/Inv Barcode";
            // 
            // txtParcelBC
            // 
            this.txtParcelBC.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.assignedtoModelBindingSource, "ParcelBarcode", true));
            this.txtParcelBC.Location = new System.Drawing.Point(114, 6);
            this.txtParcelBC.Name = "txtParcelBC";
            this.txtParcelBC.Size = new System.Drawing.Size(172, 23);
            this.txtParcelBC.TabIndex = 1;
            this.txtParcelBC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // assignedtoModelBindingSource
            // 
            this.assignedtoModelBindingSource.DataSource = typeof(PC1.Models.AssignedtoModel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parcel Barcode";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd/MM/yy";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(710, 24);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(166, 23);
            this.datePicker.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::PC1.Properties.Resources.icons8_search_50;
            this.btnSearch.Location = new System.Drawing.Point(884, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 55);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.parcelno,
            this.invCode,
            this.voucherCode,
            this.name,
            this.price,
            this.Driver});
            this.listView1.ContextMenuStrip = this.cntMenu;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(293, 67);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(667, 383);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 30;
            // 
            // parcelno
            // 
            this.parcelno.Text = "Parcel No.";
            this.parcelno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parcelno.Width = 80;
            // 
            // invCode
            // 
            this.invCode.Text = "R/Inv Barcode";
            this.invCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.invCode.Width = 90;
            // 
            // voucherCode
            // 
            this.voucherCode.Text = "V Code";
            this.voucherCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.voucherCode.Width = 100;
            // 
            // name
            // 
            this.name.Text = "Όνομα";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 200;
            // 
            // price
            // 
            this.price.Text = "Τιμή/Τ.Π.";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price.Width = 80;
            // 
            // Driver
            // 
            this.Driver.Text = "Driver";
            this.Driver.Width = 80;
            // 
            // cntMenu
            // 
            this.cntMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiDelete});
            this.cntMenu.Name = "cntMenu";
            this.cntMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(107, 22);
            this.tsmiEdit.Text = "Edit";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(107, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // DriversLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DriversLoad";
            this.Text = "PC1: Ανάθεση Δεμάτων";
            this.Load += new System.EventHandler(this.DriversLoad_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignedtoModelBindingSource)).EndInit();
            this.cntMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVoucherBC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGeneralNumBC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParcelBC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader parcelno;
        private System.Windows.Forms.ColumnHeader invCode;
        private System.Windows.Forms.ColumnHeader voucherCode;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ContextMenuStrip cntMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.MonthCalendar mCalLoad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource6;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource5;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource4;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource3;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource2;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource1;
        private System.Windows.Forms.BindingSource assignedtoModelBindingSource;
        private System.Windows.Forms.ColumnHeader Driver;
    }
}