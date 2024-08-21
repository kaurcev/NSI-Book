namespace NSI
{
    partial class ExportView
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataLoader = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.oid_l = new System.Windows.Forms.Label();
            this.version_l = new System.Windows.Forms.Label();
            this.statis = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.recov = new System.Windows.Forms.Label();
            this.convertToCSV = new System.ComponentModel.BackgroundWorker();
            this.convertToSQL = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadLoader = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataLoader
            // 
            this.dataLoader.WorkerSupportsCancellation = true;
            this.dataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dataLoader_DoWork);
            this.dataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dataLoader_RunWorkerCompleted);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(257, 67);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // oid_l
            // 
            this.oid_l.AutoSize = true;
            this.oid_l.Location = new System.Drawing.Point(12, 37);
            this.oid_l.Name = "oid_l";
            this.oid_l.Size = new System.Drawing.Size(35, 13);
            this.oid_l.TabIndex = 6;
            this.oid_l.Text = "label1";
            // 
            // version_l
            // 
            this.version_l.AutoSize = true;
            this.version_l.Location = new System.Drawing.Point(12, 50);
            this.version_l.Name = "version_l";
            this.version_l.Size = new System.Drawing.Size(35, 13);
            this.version_l.TabIndex = 7;
            this.version_l.Text = "label2";
            // 
            // statis
            // 
            this.statis.AutoSize = true;
            this.statis.Location = new System.Drawing.Point(383, 76);
            this.statis.Name = "statis";
            this.statis.Size = new System.Drawing.Size(35, 13);
            this.statis.TabIndex = 8;
            this.statis.Text = "label1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(257, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(120, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(257, 93);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(120, 23);
            this.progressBar2.TabIndex = 11;
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.Enabled = false;
            this.buttonPauseResume.Location = new System.Drawing.Point(15, 122);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(100, 23);
            this.buttonPauseResume.TabIndex = 12;
            this.buttonPauseResume.Text = "PAUSE";
            this.buttonPauseResume.UseVisualStyleBackColor = true;
            this.buttonPauseResume.Click += new System.EventHandler(this.button4_Click);
            // 
            // recov
            // 
            this.recov.AutoSize = true;
            this.recov.Location = new System.Drawing.Point(383, 63);
            this.recov.Name = "recov";
            this.recov.Size = new System.Drawing.Size(35, 13);
            this.recov.TabIndex = 13;
            this.recov.Text = "label1";
            // 
            // convertToCSV
            // 
            this.convertToCSV.WorkerSupportsCancellation = true;
            this.convertToCSV.DoWork += new System.ComponentModel.DoWorkEventHandler(this.convertToCSV_DoWork);
            this.convertToCSV.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.convertToCSV_RunWorkerCompleted);
            // 
            // convertToSQL
            // 
            this.convertToSQL.WorkerSupportsCancellation = true;
            this.convertToSQL.DoWork += new System.ComponentModel.DoWorkEventHandler(this.convertToSQL_DoWork);
            this.convertToSQL.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.convertToSQL_RunWorkerCompleted);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // uploadLoader
            // 
            this.uploadLoader.WorkerSupportsCancellation = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "UPLOAD DB";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ExportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.recov);
            this.Controls.Add(this.buttonPauseResume);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.statis);
            this.Controls.Add(this.version_l);
            this.Controls.Add(this.oid_l);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Name = "ExportView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker dataLoader;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label oid_l;
        private System.Windows.Forms.Label version_l;
        private System.Windows.Forms.Label statis;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button buttonPauseResume;
        private System.Windows.Forms.Label recov;
        private System.ComponentModel.BackgroundWorker convertToCSV;
        private System.ComponentModel.BackgroundWorker convertToSQL;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker uploadLoader;
        private System.Windows.Forms.Button button2;
    }
}

