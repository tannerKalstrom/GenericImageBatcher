﻿namespace BatchConverter
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Output = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Web_Scale_Label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.overwrite = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Progress_Output = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SubDirectories_Output = new System.Windows.Forms.TextBox();
            this.SubDirectories = new System.Windows.Forms.TextBox();
            this.Batch_Process = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.text_ActiveDirectory = new System.Windows.Forms.TextBox();
            this.button_ChooseActiveDirectory = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Panel();
            this.Footer = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.Halt = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Header.SuspendLayout();
            this.Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.20903F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.79097F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 221);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.Output);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 215);
            this.panel1.TabIndex = 6;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.Location = new System.Drawing.Point(0, 0);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(261, 215);
            this.Output.TabIndex = 4;
            this.Output.WordWrap = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Web_Scale_Label);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.overwrite);
            this.panel5.Controls.Add(this.tableLayoutPanel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(270, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(147, 215);
            this.panel5.TabIndex = 7;
            // 
            // Web_Scale_Label
            // 
            this.Web_Scale_Label.AutoSize = true;
            this.Web_Scale_Label.Location = new System.Drawing.Point(51, 133);
            this.Web_Scale_Label.Name = "Web_Scale_Label";
            this.Web_Scale_Label.Size = new System.Drawing.Size(48, 13);
            this.Web_Scale_Label.TabIndex = 10;
            this.Web_Scale_Label.Text = "web size";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 126);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "1024";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 106);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(65, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Verbose";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 83);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "UI Effects";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // overwrite
            // 
            this.overwrite.AutoSize = true;
            this.overwrite.Location = new System.Drawing.Point(3, 60);
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
            this.tableLayoutPanel3.Controls.Add(this.Progress_Output, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.SubDirectories_Output, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.SubDirectories, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(147, 57);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // Progress_Output
            // 
            this.Progress_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Progress_Output.Location = new System.Drawing.Point(76, 31);
            this.Progress_Output.Multiline = true;
            this.Progress_Output.Name = "Progress_Output";
            this.Progress_Output.ReadOnly = true;
            this.Progress_Output.Size = new System.Drawing.Size(68, 23);
            this.Progress_Output.TabIndex = 4;
            this.Progress_Output.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(3, 31);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(67, 23);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Progress";
            // 
            // SubDirectories_Output
            // 
            this.SubDirectories_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubDirectories_Output.Location = new System.Drawing.Point(76, 3);
            this.SubDirectories_Output.Multiline = true;
            this.SubDirectories_Output.Name = "SubDirectories_Output";
            this.SubDirectories_Output.ReadOnly = true;
            this.SubDirectories_Output.Size = new System.Drawing.Size(68, 22);
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
            this.SubDirectories.Size = new System.Drawing.Size(67, 22);
            this.SubDirectories.TabIndex = 1;
            this.SubDirectories.Text = "SubDirectories";
            // 
            // Batch_Process
            // 
            this.Batch_Process.Location = new System.Drawing.Point(121, 3);
            this.Batch_Process.Name = "Batch_Process";
            this.Batch_Process.Size = new System.Drawing.Size(112, 34);
            this.Batch_Process.TabIndex = 4;
            this.Batch_Process.Text = "Recursive Process Directories";
            this.Batch_Process.UseVisualStyleBackColor = true;
            this.Batch_Process.Click += new System.EventHandler(this.Batch_Process_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Process Single Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_ActiveDirectory
            // 
            this.text_ActiveDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_ActiveDirectory.Location = new System.Drawing.Point(112, 0);
            this.text_ActiveDirectory.Multiline = true;
            this.text_ActiveDirectory.Name = "text_ActiveDirectory";
            this.text_ActiveDirectory.ReadOnly = true;
            this.text_ActiveDirectory.Size = new System.Drawing.Size(308, 40);
            this.text_ActiveDirectory.TabIndex = 2;
            // 
            // button_ChooseActiveDirectory
            // 
            this.button_ChooseActiveDirectory.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_ChooseActiveDirectory.Location = new System.Drawing.Point(0, 0);
            this.button_ChooseActiveDirectory.Name = "button_ChooseActiveDirectory";
            this.button_ChooseActiveDirectory.Size = new System.Drawing.Size(112, 40);
            this.button_ChooseActiveDirectory.TabIndex = 1;
            this.button_ChooseActiveDirectory.Text = "Pick Directory";
            this.button_ChooseActiveDirectory.UseVisualStyleBackColor = true;
            this.button_ChooseActiveDirectory.Click += new System.EventHandler(this.button_ChooseActiveDirectory_Click);
            // 
            // Header
            // 
            this.Header.Controls.Add(this.text_ActiveDirectory);
            this.Header.Controls.Add(this.button_ChooseActiveDirectory);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(420, 40);
            this.Header.TabIndex = 5;
            // 
            // Footer
            // 
            this.Footer.Controls.Add(this.Exit);
            this.Footer.Controls.Add(this.Halt);
            this.Footer.Controls.Add(this.Batch_Process);
            this.Footer.Controls.Add(this.button1);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(0, 261);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(420, 40);
            this.Footer.TabIndex = 6;
            // 
            // Exit
            // 
            this.Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Exit.Location = new System.Drawing.Point(377, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(43, 40);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "Close";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Halt
            // 
            this.Halt.Location = new System.Drawing.Point(239, 3);
            this.Halt.Name = "Halt";
            this.Halt.Size = new System.Drawing.Size(69, 34);
            this.Halt.TabIndex = 5;
            this.Halt.Text = "Stop Batch";
            this.Halt.UseVisualStyleBackColor = true;
            this.Halt.Click += new System.EventHandler(this.Halt_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 301);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.Footer);
            this.MinimumSize = new System.Drawing.Size(175, 175);
            this.Name = "MainWindow";
            this.Text = "TextureBatcher";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.Footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox text_ActiveDirectory;
        private System.Windows.Forms.Button button_ChooseActiveDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox Progress_Output;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox SubDirectories_Output;
        private System.Windows.Forms.TextBox SubDirectories;
        private System.Windows.Forms.Button Batch_Process;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox overwrite;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label Web_Scale_Label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel Footer;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Halt;
    }
}

