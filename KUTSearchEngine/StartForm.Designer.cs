namespace KUTSearchEngine
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.continueButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.browswShow = new System.Windows.Forms.TextBox();
            this.indexPathShow = new System.Windows.Forms.TextBox();
            this.createIndexButton = new System.Windows.Forms.Button();
            this.openSourceCollectionFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openIndexFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(535, 347);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(201, 31);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Contibue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(572, 178);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(163, 30);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // browswShow
            // 
            this.browswShow.Location = new System.Drawing.Point(112, 178);
            this.browswShow.Multiline = true;
            this.browswShow.Name = "browswShow";
            this.browswShow.Size = new System.Drawing.Size(421, 30);
            this.browswShow.TabIndex = 2;
            // 
            // indexPathShow
            // 
            this.indexPathShow.Location = new System.Drawing.Point(112, 262);
            this.indexPathShow.Multiline = true;
            this.indexPathShow.Name = "indexPathShow";
            this.indexPathShow.Size = new System.Drawing.Size(421, 30);
            this.indexPathShow.TabIndex = 3;
            // 
            // createIndexButton
            // 
            this.createIndexButton.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createIndexButton.Location = new System.Drawing.Point(572, 262);
            this.createIndexButton.Name = "createIndexButton";
            this.createIndexButton.Size = new System.Drawing.Size(163, 30);
            this.createIndexButton.TabIndex = 4;
            this.createIndexButton.Text = "Create Index";
            this.createIndexButton.UseVisualStyleBackColor = true;
            this.createIndexButton.Click += new System.EventHandler(this.createIndexButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please choose a directory to save the index:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Please choose the source collection:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(631, 69);
            this.label3.TabIndex = 7;
            this.label3.Text = "Thanks for your selection of our product. Whenyou try this search engine, \r\nthe f" +
    "irst step is to create index. You need to choose two directory path, including: " +
    "\r\n\r\n";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createIndexButton);
            this.Controls.Add(this.indexPathShow);
            this.Controls.Add(this.browswShow);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.continueButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "Create Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox browswShow;
        private System.Windows.Forms.TextBox indexPathShow;
        private System.Windows.Forms.Button createIndexButton;
        private System.Windows.Forms.FolderBrowserDialog openSourceCollectionFileDialog;
        private System.Windows.Forms.FolderBrowserDialog openIndexFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
    }
}