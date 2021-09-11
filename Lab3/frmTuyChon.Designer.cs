
namespace Lab3
{
    partial class frmTuyChon
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnDate = new System.Windows.Forms.RadioButton();
            this.rbnName = new System.Windows.Forms.RadioButton();
            this.rbnID = new System.Windows.Forms.RadioButton();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnDate);
            this.groupBox1.Controls.Add(this.rbnName);
            this.groupBox1.Controls.Add(this.rbnID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo";
            // 
            // rbnDate
            // 
            this.rbnDate.AutoSize = true;
            this.rbnDate.Location = new System.Drawing.Point(350, 29);
            this.rbnDate.Name = "rbnDate";
            this.rbnDate.Size = new System.Drawing.Size(125, 17);
            this.rbnDate.TabIndex = 2;
            this.rbnDate.TabStop = true;
            this.rbnDate.Text = "Ngày tháng năm sinh";
            this.rbnDate.UseVisualStyleBackColor = true;
            this.rbnDate.CheckedChanged += new System.EventHandler(this.rbnDate_CheckedChanged);
            // 
            // rbnName
            // 
            this.rbnName.AutoSize = true;
            this.rbnName.Location = new System.Drawing.Point(185, 29);
            this.rbnName.Name = "rbnName";
            this.rbnName.Size = new System.Drawing.Size(57, 17);
            this.rbnName.TabIndex = 1;
            this.rbnName.TabStop = true;
            this.rbnName.Text = "Họ tên";
            this.rbnName.UseVisualStyleBackColor = true;
            this.rbnName.CheckedChanged += new System.EventHandler(this.rbnName_CheckedChanged);
            // 
            // rbnID
            // 
            this.rbnID.AutoSize = true;
            this.rbnID.Location = new System.Drawing.Point(32, 29);
            this.rbnID.Name = "rbnID";
            this.rbnID.Size = new System.Drawing.Size(58, 17);
            this.rbnID.TabIndex = 0;
            this.rbnID.TabStop = true;
            this.rbnID.Text = "Mã GV";
            this.rbnID.UseVisualStyleBackColor = true;
            this.rbnID.CheckedChanged += new System.EventHandler(this.rbnID_CheckedChanged);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(67, 166);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(78, 23);
            this.btnSort.TabIndex = 8;
            this.btnSort.Text = "Sắp xếp";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(370, 166);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 62);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(358, 27);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Tìm";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(155, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(197, 20);
            this.txtSearch.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = ".";
            // 
            // frmTuyChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 201);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTuyChon";
            this.Text = "frmTuyChon";
            this.Load += new System.EventHandler(this.frmTuyChon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnDate;
        private System.Windows.Forms.RadioButton rbnName;
        private System.Windows.Forms.RadioButton rbnID;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}