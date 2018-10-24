namespace KUTSearchEngine
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.startIndex = new System.Windows.Forms.Label();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.InfoNeedInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.firstPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.previousPage = new System.Windows.Forms.Button();
            this.lastPage = new System.Windows.Forms.Button();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.queryIdentificationReminder = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startIndex
            // 
            this.startIndex.AutoSize = true;
            this.startIndex.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startIndex.Location = new System.Drawing.Point(69, 82);
            this.startIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startIndex.Name = "startIndex";
            this.startIndex.Size = new System.Drawing.Size(237, 23);
            this.startIndex.TabIndex = 2;
            this.startIndex.Text = "Adding Documents to Index...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Document added...";
            // 
            // InfoNeedInput
            // 
            this.InfoNeedInput.AutoCompleteCustomSource.AddRange(new string[] {
            "what \"similarity laws\" must be obeyed when constructing aeroelastic models of hea" +
                "ted high speed aircraft .",
            "",
            "what are the structural and aeroelastic problems associated with flight of high s" +
                "peed aircraft .",
            "",
            "how can the aerodynamic performance of channel flow ground effect machines be cal" +
                "culated .",
            "",
            "in summarizing theoretical and experimental work on the behaviour of a typical ai" +
                "rcraft structure in a noise environment is it possible to develop a design proce" +
                "dure .",
            "",
            "has anyone developed an analysis which accurately establishes the large deflectio" +
                "n behaviour of \"conical shells\" ."});
            this.InfoNeedInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.InfoNeedInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.InfoNeedInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoNeedInput.Location = new System.Drawing.Point(219, 12);
            this.InfoNeedInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InfoNeedInput.Name = "InfoNeedInput";
            this.InfoNeedInput.Size = new System.Drawing.Size(639, 30);
            this.InfoNeedInput.TabIndex = 9;
            this.InfoNeedInput.TextChanged += new System.EventHandler(this.InfoNeedInput_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Information needs:";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.submitButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submitButton.Location = new System.Drawing.Point(866, 10);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(174, 31);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Search";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridView1.Location = new System.Drawing.Point(567, 154);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = "Unknown";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(503, 460);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // firstPage
            // 
            this.firstPage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.firstPage.Location = new System.Drawing.Point(618, 633);
            this.firstPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstPage.Name = "firstPage";
            this.firstPage.Size = new System.Drawing.Size(85, 26);
            this.firstPage.TabIndex = 24;
            this.firstPage.Text = "First Page";
            this.firstPage.UseVisualStyleBackColor = false;
            this.firstPage.Click += new System.EventHandler(this.firstPage_Click_1);
            // 
            // nextPage
            // 
            this.nextPage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nextPage.Location = new System.Drawing.Point(868, 632);
            this.nextPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(80, 28);
            this.nextPage.TabIndex = 25;
            this.nextPage.Text = "Next Page";
            this.nextPage.UseVisualStyleBackColor = false;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click_1);
            // 
            // previousPage
            // 
            this.previousPage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.previousPage.Location = new System.Drawing.Point(711, 633);
            this.previousPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.previousPage.Name = "previousPage";
            this.previousPage.Size = new System.Drawing.Size(96, 26);
            this.previousPage.TabIndex = 26;
            this.previousPage.Text = "Previous Page";
            this.previousPage.UseVisualStyleBackColor = false;
            this.previousPage.Click += new System.EventHandler(this.previousPage_Click_1);
            // 
            // lastPage
            // 
            this.lastPage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lastPage.Location = new System.Drawing.Point(956, 632);
            this.lastPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lastPage.Name = "lastPage";
            this.lastPage.Size = new System.Drawing.Size(80, 28);
            this.lastPage.TabIndex = 27;
            this.lastPage.Text = "Last Page";
            this.lastPage.UseVisualStyleBackColor = false;
            this.lastPage.Click += new System.EventHandler(this.lastPage_Click_1);
            // 
            // saveResultButton
            // 
            this.saveResultButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveResultButton.Font = new System.Drawing.Font("Calibri", 11F);
            this.saveResultButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveResultButton.Location = new System.Drawing.Point(437, 630);
            this.saveResultButton.Name = "saveResultButton";
            this.saveResultButton.Size = new System.Drawing.Size(123, 30);
            this.saveResultButton.TabIndex = 30;
            this.saveResultButton.Text = "Save Result";
            this.saveResultButton.UseVisualStyleBackColor = false;
            this.saveResultButton.Click += new System.EventHandler(this.saveResultButton_Click_2);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(50, 154);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(510, 463);
            this.textBox2.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(827, 639);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "page";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(359, 630);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(58, 30);
            this.textBox3.TabIndex = 33;
            // 
            // queryIdentificationReminder
            // 
            this.queryIdentificationReminder.AutoSize = true;
            this.queryIdentificationReminder.Font = new System.Drawing.Font("Calibri", 11F);
            this.queryIdentificationReminder.Location = new System.Drawing.Point(49, 630);
            this.queryIdentificationReminder.Name = "queryIdentificationReminder";
            this.queryIdentificationReminder.Size = new System.Drawing.Size(304, 23);
            this.queryIdentificationReminder.TabIndex = 35;
            this.queryIdentificationReminder.Text = "Please enter your query identification:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 11F);
            this.checkBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox1.Location = new System.Drawing.Point(219, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 27);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "Search \"as is\"";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Query:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "query expansion",
            "weighted query"});
            this.comboBox1.Location = new System.Drawing.Point(116, 114);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 29);
            this.comboBox1.TabIndex = 39;
            this.comboBox1.Text = "Query Process";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.checkBox2.Location = new System.Drawing.Point(595, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(62, 25);
            this.checkBox2.TabIndex = 49;
            this.checkBox2.Text = "Title";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(595, 67);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(81, 25);
            this.checkBox3.TabIndex = 50;
            this.checkBox3.Text = "Author";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(568, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "Results:";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(734, 48);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(127, 20);
            this.checkBox4.TabIndex = 53;
            this.checkBox4.Text = "Query Expansion";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(734, 70);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(121, 20);
            this.checkBox5.TabIndex = 54;
            this.checkBox5.Text = "Weighted Query";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1096, 25);
            this.statusStrip1.TabIndex = 57;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(540, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Indexing Time";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(540, 20);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Searching Time";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1096, 695);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.queryIdentificationReminder);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.saveResultButton);
            this.Controls.Add(this.lastPage);
            this.Controls.Add(this.previousPage);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.firstPage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InfoNeedInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startIndex);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "AVOCADO searching";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label startIndex;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InfoNeedInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button firstPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Button previousPage;
        private System.Windows.Forms.Button lastPage;
        private System.Windows.Forms.Button saveResultButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label queryIdentificationReminder;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

