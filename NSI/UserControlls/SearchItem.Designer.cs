namespace NSI.UserControlls
{
    partial class SearchItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.oid_l = new System.Windows.Forms.Label();
            this.version_l = new System.Windows.Forms.Label();
            this.fullName_l = new System.Windows.Forms.Label();
            this.description_l = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.createDate_l = new System.Windows.Forms.Label();
            this.publishDate_l = new System.Windows.Forms.Label();
            this.lastUpdate_l = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.fullName_l);
            this.flowLayoutPanel1.Controls.Add(this.description_l);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(568, 150);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.oid_l);
            this.flowLayoutPanel3.Controls.Add(this.version_l);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(10, 7);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(159, 23);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.Orange;
            this.flowLayoutPanel4.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel4.Controls.Add(this.label8);
            this.flowLayoutPanel4.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 2);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(74, 18);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NSI.Properties.Resources.archive_b;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 14);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Архивный";
            // 
            // oid_l
            // 
            this.oid_l.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.oid_l.AutoSize = true;
            this.oid_l.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.oid_l.ForeColor = System.Drawing.Color.Gray;
            this.oid_l.Location = new System.Drawing.Point(79, 5);
            this.oid_l.Margin = new System.Windows.Forms.Padding(5);
            this.oid_l.Name = "oid_l";
            this.oid_l.Size = new System.Drawing.Size(22, 13);
            this.oid_l.TabIndex = 0;
            this.oid_l.Text = "OID";
            // 
            // version_l
            // 
            this.version_l.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.version_l.AutoSize = true;
            this.version_l.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.version_l.ForeColor = System.Drawing.Color.Gray;
            this.version_l.Location = new System.Drawing.Point(111, 5);
            this.version_l.Margin = new System.Windows.Forms.Padding(5);
            this.version_l.Name = "version_l";
            this.version_l.Size = new System.Drawing.Size(43, 13);
            this.version_l.TabIndex = 1;
            this.version_l.Text = "VERSION";
            // 
            // fullName_l
            // 
            this.fullName_l.AutoEllipsis = true;
            this.fullName_l.AutoSize = true;
            this.fullName_l.Font = new System.Drawing.Font("Calibri", 11.3F, System.Drawing.FontStyle.Bold);
            this.fullName_l.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.fullName_l.Location = new System.Drawing.Point(10, 34);
            this.fullName_l.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.fullName_l.MaximumSize = new System.Drawing.Size(549, 40);
            this.fullName_l.MinimumSize = new System.Drawing.Size(192, 36);
            this.fullName_l.Name = "fullName_l";
            this.fullName_l.Size = new System.Drawing.Size(318, 36);
            this.fullName_l.TabIndex = 2;
            this.fullName_l.Text = "Поиск будет внутри временного диапазона";
            this.fullName_l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fullName_l.Click += new System.EventHandler(this.fullName_l_Click);
            // 
            // description_l
            // 
            this.description_l.AutoEllipsis = true;
            this.description_l.AutoSize = true;
            this.description_l.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.description_l.ForeColor = System.Drawing.Color.Black;
            this.description_l.Location = new System.Drawing.Point(10, 74);
            this.description_l.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.description_l.MaximumSize = new System.Drawing.Size(0, 40);
            this.description_l.MinimumSize = new System.Drawing.Size(192, 40);
            this.description_l.Name = "description_l";
            this.description_l.Size = new System.Drawing.Size(214, 40);
            this.description_l.TabIndex = 3;
            this.description_l.Text = "Поиск будет внутри временного диапазона";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.createDate_l);
            this.flowLayoutPanel2.Controls.Add(this.publishDate_l);
            this.flowLayoutPanel2.Controls.Add(this.lastUpdate_l);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(10, 118);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(209, 23);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // createDate_l
            // 
            this.createDate_l.AutoSize = true;
            this.createDate_l.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.createDate_l.ForeColor = System.Drawing.Color.Gray;
            this.createDate_l.Location = new System.Drawing.Point(5, 5);
            this.createDate_l.Margin = new System.Windows.Forms.Padding(5);
            this.createDate_l.Name = "createDate_l";
            this.createDate_l.Size = new System.Drawing.Size(58, 13);
            this.createDate_l.TabIndex = 0;
            this.createDate_l.Text = "DATECREATE";
            // 
            // publishDate_l
            // 
            this.publishDate_l.AutoSize = true;
            this.publishDate_l.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.publishDate_l.ForeColor = System.Drawing.Color.Gray;
            this.publishDate_l.Location = new System.Drawing.Point(73, 5);
            this.publishDate_l.Margin = new System.Windows.Forms.Padding(5);
            this.publishDate_l.Name = "publishDate_l";
            this.publishDate_l.Size = new System.Drawing.Size(61, 13);
            this.publishDate_l.TabIndex = 1;
            this.publishDate_l.Text = "DATEPUBLISH";
            // 
            // lastUpdate_l
            // 
            this.lastUpdate_l.AutoSize = true;
            this.lastUpdate_l.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.lastUpdate_l.ForeColor = System.Drawing.Color.Gray;
            this.lastUpdate_l.Location = new System.Drawing.Point(144, 5);
            this.lastUpdate_l.Margin = new System.Windows.Forms.Padding(5);
            this.lastUpdate_l.Name = "lastUpdate_l";
            this.lastUpdate_l.Size = new System.Drawing.Size(60, 13);
            this.lastUpdate_l.TabIndex = 2;
            this.lastUpdate_l.Text = "DATEUPDATE";
            // 
            // SearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Name = "SearchItem";
            this.Size = new System.Drawing.Size(568, 150);
            this.Load += new System.EventHandler(this.SearchItem_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label oid_l;
        private System.Windows.Forms.Label version_l;
        private System.Windows.Forms.Label fullName_l;
        private System.Windows.Forms.Label description_l;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label createDate_l;
        private System.Windows.Forms.Label publishDate_l;
        private System.Windows.Forms.Label lastUpdate_l;
    }
}
