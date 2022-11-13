namespace PC1
{
    partial class ReceiveParcels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveParcels));
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVoucherBC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGeneralNumBC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParcelBC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.mCalLoad = new System.Windows.Forms.MonthCalendar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.parcelno = new System.Windows.Forms.ColumnHeader();
            this.invCode = new System.Windows.Forms.ColumnHeader();
            this.voucherCode = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.Address = new System.Windows.Forms.ColumnHeader();
            this.Price = new System.Windows.Forms.ColumnHeader();
            this.Phone = new System.Windows.Forms.ColumnHeader();
            this.Phone2 = new System.Windows.Forms.ColumnHeader();
            this.Comments = new System.Windows.Forms.ColumnHeader();
            this.ArrivalDate = new System.Windows.Forms.ColumnHeader();
            this.cMenuLV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmlv_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmlv_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmlv_Assign = new System.Windows.Forms.ToolStripMenuItem();
            this.cmlv_Status = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmlv_SendToForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cMenuLV.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(112, 186);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "6941231234";
            this.txtPhone.Size = new System.Drawing.Size(172, 23);
            this.txtPhone.TabIndex = 27;
            this.toolTip1.SetToolTip(this.txtPhone, "Τηλέφωνο επικοινωνίας");
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigits_KeyPress);
            this.txtPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtPhone.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Τηλέφωνο";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(112, 157);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "23,30 ή ΠΚ";
            this.txtPrice.Size = new System.Drawing.Size(172, 23);
            this.txtPrice.TabIndex = 25;
            this.toolTip1.SetToolTip(this.txtPrice, "Ποσό ή Τρόπος πληρωμής");
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtPrice.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Ποσό";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(112, 128);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "Εθνάρχου Μακαρίου 22 85100";
            this.txtAddress.Size = new System.Drawing.Size(172, 23);
            this.txtAddress.TabIndex = 23;
            this.toolTip1.SetToolTip(this.txtAddress, "Διεύθυνση παράδοσης");
            this.txtAddress.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtAddress.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Διεύθυνση";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 99);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Κλεομένης Μπετόβεν";
            this.txtName.Size = new System.Drawing.Size(172, 23);
            this.txtName.TabIndex = 21;
            this.toolTip1.SetToolTip(this.txtName, "Ονοματεπώνυμο");
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtName.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Όνομα";
            // 
            // txtVoucherBC
            // 
            this.txtVoucherBC.Location = new System.Drawing.Point(112, 70);
            this.txtVoucherBC.Name = "txtVoucherBC";
            this.txtVoucherBC.PlaceholderText = "22111318300123456";
            this.txtVoucherBC.Size = new System.Drawing.Size(172, 23);
            this.txtVoucherBC.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtVoucherBC, "Κωδικός barcode Voucher VFS");
            this.txtVoucherBC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigits_KeyPress);
            this.txtVoucherBC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtVoucherBC.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Voucher Barcode";
            // 
            // txtGeneralNumBC
            // 
            this.txtGeneralNumBC.Location = new System.Drawing.Point(112, 41);
            this.txtGeneralNumBC.Name = "txtGeneralNumBC";
            this.txtGeneralNumBC.PlaceholderText = "5601234567";
            this.txtGeneralNumBC.Size = new System.Drawing.Size(172, 23);
            this.txtGeneralNumBC.TabIndex = 17;
            this.toolTip1.SetToolTip(this.txtGeneralNumBC, "Γενική Αρίθμιση Παραστατικού (barcode)");
            this.txtGeneralNumBC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigits_KeyPress);
            this.txtGeneralNumBC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtGeneralNumBC.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "R/Inv Barcode";
            // 
            // txtParcelBC
            // 
            this.txtParcelBC.Location = new System.Drawing.Point(112, 12);
            this.txtParcelBC.Name = "txtParcelBC";
            this.txtParcelBC.PlaceholderText = "520221113123456";
            this.txtParcelBC.Size = new System.Drawing.Size(172, 23);
            this.txtParcelBC.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtParcelBC, "Κωδικός Δέματος");
            this.txtParcelBC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigits_KeyPress);
            this.txtParcelBC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtParcelBC.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Parcel Barcode";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(112, 215);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.PlaceholderText = "2101231234";
            this.txtPhone2.Size = new System.Drawing.Size(172, 23);
            this.txtPhone2.TabIndex = 29;
            this.toolTip1.SetToolTip(this.txtPhone2, "Δεύτερο τηλέφωνο επικοινωνίας");
            this.txtPhone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigits_KeyPress);
            this.txtPhone2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtPhone2.MouseHover += new System.EventHandler(this.txtParcelBC_MouseHover);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Τηλέφωνο 2";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::PC1.Properties.Resources.refresh_1_;
            this.btnRefresh.Location = new System.Drawing.Point(9, 244);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 60);
            this.btnRefresh.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnRefresh, "Φόρτωμα ενεργών δεμάτων");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // mCalLoad
            // 
            this.mCalLoad.Location = new System.Drawing.Point(71, 316);
            this.mCalLoad.MaxSelectionCount = 1;
            this.mCalLoad.Name = "mCalLoad";
            this.mCalLoad.TabIndex = 31;
            this.mCalLoad.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mCalLoad_DateSelected);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.Image = global::PC1.Properties.Resources.icons8_enter_key_50;
            this.btnSubmit.Location = new System.Drawing.Point(112, 244);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(172, 60);
            this.btnSubmit.TabIndex = 30;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.parcelno,
            this.invCode,
            this.voucherCode,
            this.name,
            this.Address,
            this.Price,
            this.Phone,
            this.Phone2,
            this.Comments,
            this.ArrivalDate});
            this.listView1.ContextMenuStrip = this.cMenuLV;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(290, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1007, 466);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 30;
            // 
            // parcelno
            // 
            this.parcelno.Text = "Barcode Δεμ.";
            this.parcelno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parcelno.Width = 80;
            // 
            // invCode
            // 
            this.invCode.Text = "Γεν. Αρίθμηση";
            this.invCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.invCode.Width = 90;
            // 
            // voucherCode
            // 
            this.voucherCode.Text = "Vοucher Code";
            this.voucherCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.voucherCode.Width = 100;
            // 
            // name
            // 
            this.name.Text = "Όνομα";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 200;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            // 
            // Price
            // 
            this.Price.Text = "Τιμή/Τ.Π.";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Price.Width = 80;
            // 
            // Phone
            // 
            this.Phone.Text = "Phone";
            this.Phone.Width = 70;
            // 
            // Phone2
            // 
            this.Phone2.Text = "Phone2";
            this.Phone2.Width = 70;
            // 
            // Comments
            // 
            this.Comments.Text = "Comments";
            this.Comments.Width = 150;
            // 
            // ArrivalDate
            // 
            this.ArrivalDate.Text = "Arrival Date";
            // 
            // cMenuLV
            // 
            this.cMenuLV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmlv_Edit,
            this.cmlv_Delete,
            this.toolStripSeparator1,
            this.cmlv_Assign,
            this.cmlv_Status,
            this.toolStripSeparator2,
            this.cmlv_SendToForm});
            this.cMenuLV.Name = "cMenuLV";
            this.cMenuLV.Size = new System.Drawing.Size(214, 126);
            // 
            // cmlv_Edit
            // 
            this.cmlv_Edit.Name = "cmlv_Edit";
            this.cmlv_Edit.Size = new System.Drawing.Size(213, 22);
            this.cmlv_Edit.Text = "Edit";
            this.cmlv_Edit.Click += new System.EventHandler(this.cmlv_Edit_Click);
            // 
            // cmlv_Delete
            // 
            this.cmlv_Delete.Name = "cmlv_Delete";
            this.cmlv_Delete.Size = new System.Drawing.Size(213, 22);
            this.cmlv_Delete.Text = "Delete";
            this.cmlv_Delete.Click += new System.EventHandler(this.cmlv_Delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // cmlv_Assign
            // 
            this.cmlv_Assign.Name = "cmlv_Assign";
            this.cmlv_Assign.Size = new System.Drawing.Size(213, 22);
            this.cmlv_Assign.Text = "Ανάθεση προς Παράδοση";
            this.cmlv_Assign.Click += new System.EventHandler(this.cmlv_Assign_Click);
            // 
            // cmlv_Status
            // 
            this.cmlv_Status.AutoToolTip = true;
            this.cmlv_Status.Name = "cmlv_Status";
            this.cmlv_Status.Size = new System.Drawing.Size(213, 22);
            this.cmlv_Status.Text = "Κατάσταση / Σχόλια";
            this.cmlv_Status.ToolTipText = "Κατάστημα, παραδομένο, ακυρωμένο";
            this.cmlv_Status.Click += new System.EventHandler(this.cmlv_Status_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // cmlv_SendToForm
            // 
            this.cmlv_SendToForm.Name = "cmlv_SendToForm";
            this.cmlv_SendToForm.Size = new System.Drawing.Size(213, 22);
            this.cmlv_SendToForm.Text = "Προς Απόδοση";
            this.cmlv_SendToForm.Click += new System.EventHandler(this.cmlv_SendToForm_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1309, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(12, 17);
            this.tssLabel.Text = "-";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Location = new System.Drawing.Point(9, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 22);
            this.panel1.TabIndex = 35;
            this.toolTip1.SetToolTip(this.panel1, "Προς ακύρωση");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(9, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 22);
            this.panel2.TabIndex = 36;
            this.toolTip1.SetToolTip(this.panel2, "Ακυρωμένα Δέματα");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Chartreuse;
            this.panel4.Location = new System.Drawing.Point(9, 387);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(25, 22);
            this.panel4.TabIndex = 36;
            this.toolTip1.SetToolTip(this.panel4, "Παραδομένα");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(0, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Ακυρωμένα";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(0, 412);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Προς ακύρ.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(0, 371);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Παραδ.";
            // 
            // ReceiveParcels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 518);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.mCalLoad);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVoucherBC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGeneralNumBC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParcelBC);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceiveParcels";
            this.Text = "PC1: Καταχώρηση και παραλαβή δεμάτων";
            this.Load += new System.EventHandler(this.ReceiveParcels_Load);
            this.MouseHover += new System.EventHandler(this.ReceiveParcels_MouseHover);
            this.cMenuLV.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhone;
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
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.MonthCalendar mCalLoad;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader parcelno;
        private System.Windows.Forms.ColumnHeader invCode;
        private System.Windows.Forms.ColumnHeader voucherCode;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Phone;
        private System.Windows.Forms.ColumnHeader Phone2;
        private System.Windows.Forms.ColumnHeader Comments;
        private System.Windows.Forms.ColumnHeader ArrivalDate;
        private System.Windows.Forms.ContextMenuStrip cMenuLV;
        private System.Windows.Forms.ToolStripMenuItem cmlv_Edit;
        private System.Windows.Forms.ToolStripMenuItem cmlv_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmlv_Assign;
        private System.Windows.Forms.ToolStripMenuItem cmlv_Status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmlv_SendToForm;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}