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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportView));
            this.startButton = new System.Windows.Forms.Button();
            this.dataLoader = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.oid_l = new System.Windows.Forms.Label();
            this.version_l = new System.Windows.Forms.Label();
            this.statis = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.convertToCSV = new System.ComponentModel.BackgroundWorker();
            this.convertToSQL = new System.ComponentModel.BackgroundWorker();
            this.uploadLoader = new System.ComponentModel.BackgroundWorker();
            this.loadsqlButton = new System.Windows.Forms.Button();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.versionLoader = new System.ComponentModel.BackgroundWorker();
            this.infoDataLoader = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.archivePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.createDate = new System.Windows.Forms.Label();
            this.lastUpdate = new System.Windows.Forms.Label();
            this.publishDate = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.releaseNotes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.structureNotes = new System.Windows.Forms.Label();
            this.demoLoader = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.shema_l = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.archivePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Calibri", 8F);
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(2, 3);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 25);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Запуск";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataLoader
            // 
            this.dataLoader.WorkerSupportsCancellation = true;
            this.dataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dataLoader_DoWork);
            this.dataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dataLoader_RunWorkerCompleted);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(2, 76);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDown1.Size = new System.Drawing.Size(132, 21);
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
            this.oid_l.Font = new System.Drawing.Font("Calibri", 7F);
            this.oid_l.Location = new System.Drawing.Point(2, 0);
            this.oid_l.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.oid_l.Name = "oid_l";
            this.oid_l.Size = new System.Drawing.Size(31, 13);
            this.oid_l.TabIndex = 6;
            this.oid_l.Text = "label1";
            // 
            // version_l
            // 
            this.version_l.AutoSize = true;
            this.version_l.Font = new System.Drawing.Font("Calibri", 7F);
            this.version_l.Location = new System.Drawing.Point(37, 0);
            this.version_l.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.version_l.Name = "version_l";
            this.version_l.Size = new System.Drawing.Size(31, 13);
            this.version_l.TabIndex = 7;
            this.version_l.Text = "label2";
            // 
            // statis
            // 
            this.statis.AutoSize = true;
            this.statis.Location = new System.Drawing.Point(4, 422);
            this.statis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statis.MaximumSize = new System.Drawing.Size(138, 0);
            this.statis.Name = "statis";
            this.statis.Size = new System.Drawing.Size(32, 13);
            this.statis.TabIndex = 8;
            this.statis.Text = "Готов";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(2, 53);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 156);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(132, 21);
            this.progressBar1.TabIndex = 10;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(2, 116);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(132, 21);
            this.progressBar2.TabIndex = 11;
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.buttonPauseResume.Enabled = false;
            this.buttonPauseResume.FlatAppearance.BorderSize = 0;
            this.buttonPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPauseResume.ForeColor = System.Drawing.Color.White;
            this.buttonPauseResume.Location = new System.Drawing.Point(2, 34);
            this.buttonPauseResume.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(132, 25);
            this.buttonPauseResume.TabIndex = 12;
            this.buttonPauseResume.Text = "Пауза";
            this.buttonPauseResume.UseVisualStyleBackColor = false;
            this.buttonPauseResume.Click += new System.EventHandler(this.button4_Click);
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
            // uploadLoader
            // 
            this.uploadLoader.WorkerSupportsCancellation = true;
            this.uploadLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uploadLoader_DoWork);
            this.uploadLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uploadLoader_RunWorkerCompleted);
            // 
            // loadsqlButton
            // 
            this.loadsqlButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.loadsqlButton.Enabled = false;
            this.loadsqlButton.FlatAppearance.BorderSize = 0;
            this.loadsqlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadsqlButton.ForeColor = System.Drawing.Color.White;
            this.loadsqlButton.Location = new System.Drawing.Point(2, 96);
            this.loadsqlButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.loadsqlButton.Name = "loadsqlButton";
            this.loadsqlButton.Size = new System.Drawing.Size(132, 25);
            this.loadsqlButton.TabIndex = 16;
            this.loadsqlButton.Text = "Загрузить в бд";
            this.loadsqlButton.UseVisualStyleBackColor = false;
            this.loadsqlButton.Click += new System.EventHandler(this.loadsqlButton_Click_1);
            // 
            // versionBox
            // 
            this.versionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionBox.FormattingEnabled = true;
            this.versionBox.Location = new System.Drawing.Point(2, 16);
            this.versionBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(132, 21);
            this.versionBox.TabIndex = 17;
            this.versionBox.SelectedIndexChanged += new System.EventHandler(this.versionBox_SelectedIndexChanged);
            // 
            // versionLoader
            // 
            this.versionLoader.WorkerSupportsCancellation = true;
            this.versionLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.versionLoader_DoWork);
            this.versionLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.versionLoader_RunWorkerCompleted);
            // 
            // infoDataLoader
            // 
            this.infoDataLoader.WorkerSupportsCancellation = true;
            this.infoDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.infoDataLoader_DoWork);
            this.infoDataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.infoDataLoader_RunWorkerCompleted);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.fullName);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.description);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.releaseNotes);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.structureNotes);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(576, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(574, 235);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.archivePanel);
            this.flowLayoutPanel2.Controls.Add(this.createDate);
            this.flowLayoutPanel2.Controls.Add(this.lastUpdate);
            this.flowLayoutPanel2.Controls.Add(this.publishDate);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 3);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(226, 23);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // archivePanel
            // 
            this.archivePanel.AutoSize = true;
            this.archivePanel.BackColor = System.Drawing.Color.Orange;
            this.archivePanel.Controls.Add(this.pictureBox5);
            this.archivePanel.Controls.Add(this.label11);
            this.archivePanel.Location = new System.Drawing.Point(2, 3);
            this.archivePanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.archivePanel.Name = "archivePanel";
            this.archivePanel.Padding = new System.Windows.Forms.Padding(2);
            this.archivePanel.Size = new System.Drawing.Size(55, 17);
            this.archivePanel.TabIndex = 5;
            this.archivePanel.WrapContents = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::NSI.Properties.Resources.archive_b;
            this.pictureBox5.Location = new System.Drawing.Point(2, 2);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(13, 13);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(15, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "АРХИВ";
            // 
            // createDate
            // 
            this.createDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.createDate.AutoSize = true;
            this.createDate.Font = new System.Drawing.Font("Calibri", 7F);
            this.createDate.Location = new System.Drawing.Point(61, 5);
            this.createDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(51, 13);
            this.createDate.TabIndex = 2;
            this.createDate.Text = "createDate";
            // 
            // lastUpdate
            // 
            this.lastUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastUpdate.AutoSize = true;
            this.lastUpdate.Font = new System.Drawing.Font("Calibri", 7F);
            this.lastUpdate.Location = new System.Drawing.Point(116, 5);
            this.lastUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastUpdate.Name = "lastUpdate";
            this.lastUpdate.Size = new System.Drawing.Size(50, 13);
            this.lastUpdate.TabIndex = 3;
            this.lastUpdate.Text = "lastUpdate";
            // 
            // publishDate
            // 
            this.publishDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.publishDate.AutoSize = true;
            this.publishDate.Font = new System.Drawing.Font("Calibri", 7F);
            this.publishDate.Location = new System.Drawing.Point(170, 5);
            this.publishDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.publishDate.Name = "publishDate";
            this.publishDate.Size = new System.Drawing.Size(54, 13);
            this.publishDate.TabIndex = 4;
            this.publishDate.Text = "publishDate";
            // 
            // fullName
            // 
            this.fullName.AutoSize = true;
            this.fullName.Font = new System.Drawing.Font("Calibri", 11.3F, System.Drawing.FontStyle.Bold);
            this.fullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.fullName.Location = new System.Drawing.Point(2, 29);
            this.fullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fullName.MaximumSize = new System.Drawing.Size(570, 0);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(71, 19);
            this.fullName.TabIndex = 0;
            this.fullName.Text = "fullName";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.oid_l);
            this.flowLayoutPanel3.Controls.Add(this.version_l);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 51);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(70, 13);
            this.flowLayoutPanel3.TabIndex = 5;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(2, 77);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 10, 2, 5);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2);
            this.label9.Size = new System.Drawing.Size(133, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Описание справочника";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.BackColor = System.Drawing.Color.White;
            this.description.Location = new System.Drawing.Point(2, 100);
            this.description.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.description.MaximumSize = new System.Drawing.Size(570, 0);
            this.description.MinimumSize = new System.Drawing.Size(570, 20);
            this.description.Name = "description";
            this.description.Padding = new System.Windows.Forms.Padding(5);
            this.description.Size = new System.Drawing.Size(570, 23);
            this.description.TabIndex = 1;
            this.description.Text = "description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(2, 133);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 10, 2, 5);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2);
            this.label10.Size = new System.Drawing.Size(169, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "Изменения в текущей версии";
            // 
            // releaseNotes
            // 
            this.releaseNotes.AutoSize = true;
            this.releaseNotes.BackColor = System.Drawing.Color.White;
            this.releaseNotes.Location = new System.Drawing.Point(2, 156);
            this.releaseNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.releaseNotes.MaximumSize = new System.Drawing.Size(570, 0);
            this.releaseNotes.MinimumSize = new System.Drawing.Size(570, 20);
            this.releaseNotes.Name = "releaseNotes";
            this.releaseNotes.Padding = new System.Windows.Forms.Padding(5);
            this.releaseNotes.Size = new System.Drawing.Size(570, 23);
            this.releaseNotes.TabIndex = 9;
            this.releaseNotes.Text = "releaseNotes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(2, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 10, 2, 5);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(190, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Описание структуры справочника";
            // 
            // structureNotes
            // 
            this.structureNotes.AutoSize = true;
            this.structureNotes.BackColor = System.Drawing.Color.White;
            this.structureNotes.Location = new System.Drawing.Point(2, 212);
            this.structureNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.structureNotes.MaximumSize = new System.Drawing.Size(570, 0);
            this.structureNotes.MinimumSize = new System.Drawing.Size(570, 20);
            this.structureNotes.Name = "structureNotes";
            this.structureNotes.Padding = new System.Windows.Forms.Padding(5);
            this.structureNotes.Size = new System.Drawing.Size(570, 23);
            this.structureNotes.TabIndex = 7;
            this.structureNotes.Text = "structureNotes";
            // 
            // demoLoader
            // 
            this.demoLoader.WorkerSupportsCancellation = true;
            this.demoLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.demoLoader_DoWork);
            this.demoLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.demoLoader_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 489);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel9);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel6.Controls.Add(this.statis);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(40, 0);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(160, 489);
            this.flowLayoutPanel6.TabIndex = 2;
            this.flowLayoutPanel6.WrapContents = false;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.AutoSize = true;
            this.flowLayoutPanel9.Controls.Add(this.label7);
            this.flowLayoutPanel9.Controls.Add(this.versionBox);
            this.flowLayoutPanel9.Controls.Add(this.label8);
            this.flowLayoutPanel9.Controls.Add(this.label23);
            this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(4, 6);
            this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(136, 66);
            this.flowLayoutPanel9.TabIndex = 21;
            this.flowLayoutPanel9.WrapContents = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(2, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Версия справочника";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(2, 40);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Значений в справочнике";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.AutoSize = true;
            this.flowLayoutPanel7.Controls.Add(this.label3);
            this.flowLayoutPanel7.Controls.Add(this.label13);
            this.flowLayoutPanel7.Controls.Add(this.shema_l);
            this.flowLayoutPanel7.Controls.Add(this.label4);
            this.flowLayoutPanel7.Controls.Add(this.numericUpDown1);
            this.flowLayoutPanel7.Controls.Add(this.label5);
            this.flowLayoutPanel7.Controls.Add(this.progressBar2);
            this.flowLayoutPanel7.Controls.Add(this.label6);
            this.flowLayoutPanel7.Controls.Add(this.progressBar1);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(4, 78);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(152, 180);
            this.flowLayoutPanel7.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Схема";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 7F, System.Drawing.FontStyle.Italic);
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(2, 13);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 26);
            this.label13.TabIndex = 27;
            this.label13.Text = "Схема редактируется только в настройках конфигурации";
            // 
            // shema_l
            // 
            this.shema_l.Location = new System.Drawing.Point(2, 39);
            this.shema_l.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.shema_l.Name = "shema_l";
            this.shema_l.Size = new System.Drawing.Size(132, 21);
            this.shema_l.TabIndex = 26;
            this.shema_l.Text = "label1";
            this.shema_l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(2, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Наполнение тома";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(2, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Одиночный прогресс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri Light", 7F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(2, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Общий прогресс";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.AutoSize = true;
            this.flowLayoutPanel8.Controls.Add(this.startButton);
            this.flowLayoutPanel8.Controls.Add(this.buttonPauseResume);
            this.flowLayoutPanel8.Controls.Add(this.button1);
            this.flowLayoutPanel8.Controls.Add(this.loadsqlButton);
            this.flowLayoutPanel8.Controls.Add(this.button2);
            this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(4, 264);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(136, 155);
            this.flowLayoutPanel8.TabIndex = 21;
            this.flowLayoutPanel8.WrapContents = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(2, 65);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "В фон";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Crimson;
            this.button2.Location = new System.Drawing.Point(2, 127);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 25);
            this.button2.TabIndex = 18;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(200, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(600, 489);
            this.flowLayoutPanel4.TabIndex = 0;
            this.flowLayoutPanel4.WrapContents = false;
            this.flowLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel4_Paint);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.flowLayoutPanel5.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel5.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel5.Controls.Add(this.pictureBox3);
            this.flowLayoutPanel5.Controls.Add(this.pictureBox4);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(40, 489);
            this.flowLayoutPanel5.TabIndex = 1;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NSI.Properties.Resources.qlogo;
            this.pictureBox1.Location = new System.Drawing.Point(4, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::NSI.Properties.Resources.home_b;
            this.pictureBox2.Location = new System.Drawing.Point(9, 42);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.Image = global::NSI.Properties.Resources.files_b;
            this.pictureBox3.Location = new System.Drawing.Point(9, 75);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.Image = global::NSI.Properties.Resources.serv_b;
            this.pictureBox4.Location = new System.Drawing.Point(9, 108);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 10);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // notify
            // 
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "notifyIcon1";
            this.notify.Visible = true;
            this.notify.BalloonTipClicked += new System.EventHandler(this.notify_BalloonTipClicked);
            this.notify.Click += new System.EventHandler(this.notify_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.Size = new System.Drawing.Size(570, 264);
            this.dataGridView1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Демо-просмотр";
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.AutoSize = true;
            this.flowLayoutPanel11.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel11.Controls.Add(this.label1);
            this.flowLayoutPanel11.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(5, 247);
            this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel11.MaximumSize = new System.Drawing.Size(576, 270);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(574, 270);
            this.flowLayoutPanel11.TabIndex = 21;
            // 
            // ExportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "ExportView";
            this.Text = "NSI | ...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportView_FormClosed);
            this.Load += new System.EventHandler(this.ExportView_Load);
            this.Resize += new System.EventHandler(this.ExportView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.archivePanel.ResumeLayout(false);
            this.archivePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.ComponentModel.BackgroundWorker dataLoader;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label oid_l;
        private System.Windows.Forms.Label version_l;
        private System.Windows.Forms.Label statis;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button buttonPauseResume;
        private System.ComponentModel.BackgroundWorker convertToCSV;
        private System.ComponentModel.BackgroundWorker convertToSQL;
        private System.ComponentModel.BackgroundWorker uploadLoader;
        private System.Windows.Forms.Button loadsqlButton;
        private System.Windows.Forms.ComboBox versionBox;
        private System.ComponentModel.BackgroundWorker versionLoader;
        private System.ComponentModel.BackgroundWorker infoDataLoader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label fullName;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label createDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lastUpdate;
        private System.Windows.Forms.Label publishDate;
        private System.ComponentModel.BackgroundWorker demoLoader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label structureNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label releaseNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.FlowLayoutPanel archivePanel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label shema_l;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

