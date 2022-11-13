
namespace PC1
{
    partial class DataViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewer));
            this.btnSearch = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.parcelno = new System.Windows.Forms.ColumnHeader();
            this.genPop = new System.Windows.Forms.ColumnHeader();
            this.procDate = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.price = new System.Windows.Forms.ColumnHeader();
            this.dcType = new System.Windows.Forms.ColumnHeader();
            this.regDate = new System.Windows.Forms.ColumnHeader();
            this.mCalLoad = new System.Windows.Forms.MonthCalendar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(788, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(301, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd/MM/yy";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(788, 6);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(301, 23);
            this.datePicker.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.parcelno,
            this.genPop,
            this.procDate,
            this.name,
            this.price,
            this.dcType,
            this.regDate});
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 397);
            this.listView1.TabIndex = 4;
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
            this.parcelno.Text = "Parcel No.";
            this.parcelno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parcelno.Width = 80;
            // 
            // genPop
            // 
            this.genPop.Text = "Γεν. Αρίθμιση";
            this.genPop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genPop.Width = 90;
            // 
            // procDate
            // 
            this.procDate.Text = "Ημ/νία Τιμολ.";
            this.procDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.procDate.Width = 100;
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
            // dcType
            // 
            this.dcType.Text = "Τύπος";
            // 
            // regDate
            // 
            this.regDate.Text = "Ημ/νία Καταχώρησης";
            this.regDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.regDate.Width = 130;
            // 
            // mCalLoad
            // 
            this.mCalLoad.Location = new System.Drawing.Point(876, 70);
            this.mCalLoad.MaxSelectionCount = 1;
            this.mCalLoad.Name = "mCalLoad";
            this.mCalLoad.TabIndex = 5;
            this.mCalLoad.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mCalLoad_DateSelected);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::PC1.Properties.Resources.refresh_1_;
            this.btnRefresh.Location = new System.Drawing.Point(788, 70);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(76, 41);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 412);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.mCalLoad);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataViewer";
            this.Text = "DataViewer";
            this.Load += new System.EventHandler(this.DataViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader parcelno;
        private System.Windows.Forms.ColumnHeader genPop;
        private System.Windows.Forms.ColumnHeader procDate;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader regDate;
        private System.Windows.Forms.ColumnHeader dcType;
        private System.Windows.Forms.MonthCalendar mCalLoad;
        private System.Windows.Forms.Button btnRefresh;
    }
}