namespace BatchConverter
{
    partial class MainWindow
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
            this.Step2MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Output = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Web_Scale_Label = new System.Windows.Forms.Label();
            this.WebSizeEntryBox = new System.Windows.Forms.TextBox();
            this.verbose = new System.Windows.Forms.CheckBox();
            this.ui = new System.Windows.Forms.CheckBox();
            this.overwrite = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SubstancePathLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Label_Substance = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Label_TbScene = new System.Windows.Forms.Label();
            this.SelectTBScene = new System.Windows.Forms.Button();
            this.Progress_Output = new System.Windows.Forms.TextBox();
            this.ProgressLabel = new System.Windows.Forms.TextBox();
            this.SubDirectories_Output = new System.Windows.Forms.TextBox();
            this.SubDirectories = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label_Readme = new System.Windows.Forms.Label();
            this.Readme = new System.Windows.Forms.Button();
            this.Batch_Process = new System.Windows.Forms.Button();
            this.ProcessSingleDirectory = new System.Windows.Forms.Button();
            this.text_ActiveDirectory = new System.Windows.Forms.TextBox();
            this.button_ChooseActiveDirectory = new System.Windows.Forms.Button();
            this.Step2Header = new System.Windows.Forms.Panel();
            this.Step2Footer = new System.Windows.Forms.Panel();
            this.InitializeDir = new System.Windows.Forms.Button();
            this.Halt = new System.Windows.Forms.Button();
            this.StepTwoPanel = new System.Windows.Forms.Panel();
            this.Step2MainTable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Step2Header.SuspendLayout();
            this.Step2Footer.SuspendLayout();
            this.StepTwoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Step2MainTable
            // 
            this.Step2MainTable.ColumnCount = 3;
            this.Step2MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.20903F));
            this.Step2MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.79097F));
            this.Step2MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.Step2MainTable.Controls.Add(this.panel1, 0, 0);
            this.Step2MainTable.Controls.Add(this.panel5, 2, 0);
            this.Step2MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Step2MainTable.Location = new System.Drawing.Point(0, 40);
            this.Step2MainTable.Name = "Step2MainTable";
            this.Step2MainTable.RowCount = 1;
            this.Step2MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Step2MainTable.Size = new System.Drawing.Size(925, 419);
            this.Step2MainTable.TabIndex = 2;
            // 
            // panel1
            // 
            this.Step2MainTable.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.Output);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 413);
            this.panel1.TabIndex = 6;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.ControlText;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.ForeColor = System.Drawing.Color.Lime;
            this.Output.Location = new System.Drawing.Point(0, 0);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(478, 413);
            this.Output.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Web_Scale_Label);
            this.panel5.Controls.Add(this.WebSizeEntryBox);
            this.panel5.Controls.Add(this.verbose);
            this.panel5.Controls.Add(this.ui);
            this.panel5.Controls.Add(this.overwrite);
            this.panel5.Controls.Add(this.tableLayoutPanel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(487, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(435, 413);
            this.panel5.TabIndex = 7;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // Web_Scale_Label
            // 
            this.Web_Scale_Label.AutoSize = true;
            this.Web_Scale_Label.Location = new System.Drawing.Point(302, 172);
            this.Web_Scale_Label.Name = "Web_Scale_Label";
            this.Web_Scale_Label.Size = new System.Drawing.Size(48, 13);
            this.Web_Scale_Label.TabIndex = 10;
            this.Web_Scale_Label.Text = "web size";
            // 
            // WebSizeEntryBox
            // 
            this.WebSizeEntryBox.Location = new System.Drawing.Point(356, 168);
            this.WebSizeEntryBox.MaxLength = 4;
            this.WebSizeEntryBox.Name = "WebSizeEntryBox";
            this.WebSizeEntryBox.Size = new System.Drawing.Size(42, 20);
            this.WebSizeEntryBox.TabIndex = 9;
            this.WebSizeEntryBox.Text = "1024";
            this.WebSizeEntryBox.TextChanged += new System.EventHandler(this.WebScale_TextChanged);
            // 
            // verbose
            // 
            this.verbose.AutoSize = true;
            this.verbose.Location = new System.Drawing.Point(159, 171);
            this.verbose.Name = "verbose";
            this.verbose.Size = new System.Drawing.Size(65, 17);
            this.verbose.TabIndex = 8;
            this.verbose.Text = "Verbose";
            this.verbose.UseVisualStyleBackColor = true;
            this.verbose.CheckedChanged += new System.EventHandler(this.Verbose_Clicked);
            // 
            // ui
            // 
            this.ui.AutoSize = true;
            this.ui.Location = new System.Drawing.Point(80, 171);
            this.ui.Name = "ui";
            this.ui.Size = new System.Drawing.Size(73, 17);
            this.ui.TabIndex = 7;
            this.ui.Text = "UI Effects";
            this.ui.UseVisualStyleBackColor = true;
            this.ui.CheckedChanged += new System.EventHandler(this.UI_Clicked);
            // 
            // overwrite
            // 
            this.overwrite.AutoSize = true;
            this.overwrite.Location = new System.Drawing.Point(3, 171);
            this.overwrite.Name = "overwrite";
            this.overwrite.Size = new System.Drawing.Size(71, 17);
            this.overwrite.TabIndex = 6;
            this.overwrite.Text = "Overwrite";
            this.overwrite.UseVisualStyleBackColor = true;
            this.overwrite.CheckedChanged += new System.EventHandler(this.overwrite_CheckedChanged_1);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.7006F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.2994F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Progress_Output, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.ProgressLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.SubDirectories_Output, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.SubDirectories, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(435, 165);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.SubstancePathLabel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(219, 126);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(213, 36);
            this.panel6.TabIndex = 16;
            // 
            // SubstancePathLabel
            // 
            this.SubstancePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubstancePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubstancePathLabel.Location = new System.Drawing.Point(0, 0);
            this.SubstancePathLabel.Name = "SubstancePathLabel";
            this.SubstancePathLabel.Size = new System.Drawing.Size(213, 36);
            this.SubstancePathLabel.TabIndex = 12;
            this.SubstancePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Label_Substance);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(219, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(213, 35);
            this.panel4.TabIndex = 15;
            // 
            // Label_Substance
            // 
            this.Label_Substance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Substance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Substance.Location = new System.Drawing.Point(97, 0);
            this.Label_Substance.Name = "Label_Substance";
            this.Label_Substance.Size = new System.Drawing.Size(116, 35);
            this.Label_Substance.TabIndex = 12;
            this.Label_Substance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Path To sbrender.exe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Substance_Button);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Label_TbScene);
            this.panel3.Controls.Add(this.SelectTBScene);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 36);
            this.panel3.TabIndex = 14;
            // 
            // Label_TbScene
            // 
            this.Label_TbScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_TbScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_TbScene.Location = new System.Drawing.Point(97, 0);
            this.Label_TbScene.Name = "Label_TbScene";
            this.Label_TbScene.Size = new System.Drawing.Size(113, 36);
            this.Label_TbScene.TabIndex = 13;
            this.Label_TbScene.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectTBScene
            // 
            this.SelectTBScene.Dock = System.Windows.Forms.DockStyle.Left;
            this.SelectTBScene.Location = new System.Drawing.Point(0, 0);
            this.SelectTBScene.Name = "SelectTBScene";
            this.SelectTBScene.Size = new System.Drawing.Size(97, 36);
            this.SelectTBScene.TabIndex = 12;
            this.SelectTBScene.Text = "Select tbscene";
            this.SelectTBScene.UseVisualStyleBackColor = true;
            this.SelectTBScene.Click += new System.EventHandler(this.SelectTBScene_Click);
            // 
            // Progress_Output
            // 
            this.Progress_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Progress_Output.Location = new System.Drawing.Point(219, 44);
            this.Progress_Output.Multiline = true;
            this.Progress_Output.Name = "Progress_Output";
            this.Progress_Output.ReadOnly = true;
            this.Progress_Output.Size = new System.Drawing.Size(213, 35);
            this.Progress_Output.TabIndex = 4;
            this.Progress_Output.Text = "0";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressLabel.Location = new System.Drawing.Point(3, 44);
            this.ProgressLabel.Multiline = true;
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.ReadOnly = true;
            this.ProgressLabel.Size = new System.Drawing.Size(210, 35);
            this.ProgressLabel.TabIndex = 3;
            this.ProgressLabel.Text = "Progress";
            // 
            // SubDirectories_Output
            // 
            this.SubDirectories_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubDirectories_Output.Location = new System.Drawing.Point(219, 3);
            this.SubDirectories_Output.Multiline = true;
            this.SubDirectories_Output.Name = "SubDirectories_Output";
            this.SubDirectories_Output.ReadOnly = true;
            this.SubDirectories_Output.Size = new System.Drawing.Size(213, 35);
            this.SubDirectories_Output.TabIndex = 2;
            this.SubDirectories_Output.Text = "0";
            // 
            // SubDirectories
            // 
            this.SubDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubDirectories.Location = new System.Drawing.Point(3, 3);
            this.SubDirectories.Multiline = true;
            this.SubDirectories.Name = "SubDirectories";
            this.SubDirectories.ReadOnly = true;
            this.SubDirectories.Size = new System.Drawing.Size(210, 35);
            this.SubDirectories.TabIndex = 1;
            this.SubDirectories.Text = "SubDirectories";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Label_Readme);
            this.panel2.Controls.Add(this.Readme);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 35);
            this.panel2.TabIndex = 13;
            // 
            // Label_Readme
            // 
            this.Label_Readme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Readme.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Readme.Location = new System.Drawing.Point(97, 0);
            this.Label_Readme.Name = "Label_Readme";
            this.Label_Readme.Size = new System.Drawing.Size(113, 35);
            this.Label_Readme.TabIndex = 12;
            this.Label_Readme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Readme
            // 
            this.Readme.Dock = System.Windows.Forms.DockStyle.Left;
            this.Readme.Location = new System.Drawing.Point(0, 0);
            this.Readme.Name = "Readme";
            this.Readme.Size = new System.Drawing.Size(97, 35);
            this.Readme.TabIndex = 11;
            this.Readme.Text = "Included Readme";
            this.Readme.UseVisualStyleBackColor = true;
            this.Readme.Click += new System.EventHandler(this.Readme_Click);
            // 
            // Batch_Process
            // 
            this.Batch_Process.BackColor = System.Drawing.SystemColors.Control;
            this.Batch_Process.Location = new System.Drawing.Point(204, 3);
            this.Batch_Process.Name = "Batch_Process";
            this.Batch_Process.Size = new System.Drawing.Size(77, 34);
            this.Batch_Process.TabIndex = 4;
            this.Batch_Process.Text = "Batch Process GT";
            this.Batch_Process.UseVisualStyleBackColor = false;
            this.Batch_Process.Click += new System.EventHandler(this.Batch_Process_Click);
            // 
            // ProcessSingleDirectory
            // 
            this.ProcessSingleDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.ProcessSingleDirectory.Location = new System.Drawing.Point(86, 3);
            this.ProcessSingleDirectory.Name = "ProcessSingleDirectory";
            this.ProcessSingleDirectory.Size = new System.Drawing.Size(112, 34);
            this.ProcessSingleDirectory.TabIndex = 3;
            this.ProcessSingleDirectory.Text = "Process GT Directory";
            this.ProcessSingleDirectory.UseVisualStyleBackColor = false;
            this.ProcessSingleDirectory.Click += new System.EventHandler(this.Process_Single_Directopry_Clicked);
            // 
            // text_ActiveDirectory
            // 
            this.text_ActiveDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_ActiveDirectory.Location = new System.Drawing.Point(112, 0);
            this.text_ActiveDirectory.Multiline = true;
            this.text_ActiveDirectory.Name = "text_ActiveDirectory";
            this.text_ActiveDirectory.ReadOnly = true;
            this.text_ActiveDirectory.Size = new System.Drawing.Size(813, 40);
            this.text_ActiveDirectory.TabIndex = 2;
            // 
            // button_ChooseActiveDirectory
            // 
            this.button_ChooseActiveDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.button_ChooseActiveDirectory.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_ChooseActiveDirectory.Location = new System.Drawing.Point(0, 0);
            this.button_ChooseActiveDirectory.Name = "button_ChooseActiveDirectory";
            this.button_ChooseActiveDirectory.Size = new System.Drawing.Size(112, 40);
            this.button_ChooseActiveDirectory.TabIndex = 1;
            this.button_ChooseActiveDirectory.Text = "Pick Directory";
            this.button_ChooseActiveDirectory.UseVisualStyleBackColor = false;
            this.button_ChooseActiveDirectory.Click += new System.EventHandler(this.button_ChooseActiveDirectory_Click);
            // 
            // Step2Header
            // 
            this.Step2Header.Controls.Add(this.text_ActiveDirectory);
            this.Step2Header.Controls.Add(this.button_ChooseActiveDirectory);
            this.Step2Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Step2Header.Location = new System.Drawing.Point(0, 0);
            this.Step2Header.Name = "Step2Header";
            this.Step2Header.Size = new System.Drawing.Size(925, 40);
            this.Step2Header.TabIndex = 5;
            // 
            // Step2Footer
            // 
            this.Step2Footer.Controls.Add(this.InitializeDir);
            this.Step2Footer.Controls.Add(this.Halt);
            this.Step2Footer.Controls.Add(this.Batch_Process);
            this.Step2Footer.Controls.Add(this.ProcessSingleDirectory);
            this.Step2Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Step2Footer.Location = new System.Drawing.Point(0, 459);
            this.Step2Footer.Name = "Step2Footer";
            this.Step2Footer.Size = new System.Drawing.Size(925, 40);
            this.Step2Footer.TabIndex = 6;
            // 
            // InitializeDir
            // 
            this.InitializeDir.Location = new System.Drawing.Point(3, 3);
            this.InitializeDir.Name = "InitializeDir";
            this.InitializeDir.Size = new System.Drawing.Size(77, 34);
            this.InitializeDir.TabIndex = 6;
            this.InitializeDir.Text = "Initialize GT Directory";
            this.InitializeDir.UseVisualStyleBackColor = true;
            this.InitializeDir.Click += new System.EventHandler(this.InitializeGTDir_Click);
            // 
            // Halt
            // 
            this.Halt.BackColor = System.Drawing.SystemColors.Control;
            this.Halt.Location = new System.Drawing.Point(850, 3);
            this.Halt.Name = "Halt";
            this.Halt.Size = new System.Drawing.Size(69, 34);
            this.Halt.TabIndex = 5;
            this.Halt.Text = "Stop Batch";
            this.Halt.UseVisualStyleBackColor = false;
            this.Halt.Click += new System.EventHandler(this.Halt_Click);
            // 
            // StepTwoPanel
            // 
            this.StepTwoPanel.Controls.Add(this.Step2MainTable);
            this.StepTwoPanel.Controls.Add(this.Step2Footer);
            this.StepTwoPanel.Controls.Add(this.Step2Header);
            this.StepTwoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepTwoPanel.Location = new System.Drawing.Point(0, 0);
            this.StepTwoPanel.Name = "StepTwoPanel";
            this.StepTwoPanel.Size = new System.Drawing.Size(925, 499);
            this.StepTwoPanel.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(925, 499);
            this.Controls.Add(this.StepTwoPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(175, 175);
            this.Name = "MainWindow";
            this.Text = "TextureBatcher";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Step2MainTable.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.Step2Header.ResumeLayout(false);
            this.Step2Header.PerformLayout();
            this.Step2Footer.ResumeLayout(false);
            this.StepTwoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Step2MainTable;
        private System.Windows.Forms.TextBox text_ActiveDirectory;
        private System.Windows.Forms.Button button_ChooseActiveDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button ProcessSingleDirectory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox Progress_Output;
        private System.Windows.Forms.TextBox ProgressLabel;
        private System.Windows.Forms.TextBox SubDirectories_Output;
        private System.Windows.Forms.TextBox SubDirectories;
        private System.Windows.Forms.Button Batch_Process;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox verbose;
        private System.Windows.Forms.CheckBox ui;
        private System.Windows.Forms.CheckBox overwrite;
        private System.Windows.Forms.Panel Step2Header;
        private System.Windows.Forms.Label Web_Scale_Label;
        private System.Windows.Forms.TextBox WebSizeEntryBox;
        private System.Windows.Forms.Panel Step2Footer;
        private System.Windows.Forms.Button Halt;
        private System.Windows.Forms.Panel StepTwoPanel;
        private System.Windows.Forms.Button InitializeDir;
        private System.Windows.Forms.Button SelectTBScene;
        private System.Windows.Forms.Button Readme;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label SubstancePathLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Label_Substance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Label_TbScene;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Label_Readme;
    }
}

