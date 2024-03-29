﻿namespace InfoBez
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textInput = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.selectedMode = new System.Windows.Forms.ComboBox();
            this.keyInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyInput)).BeginInit();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textInput.Location = new System.Drawing.Point(0, 0);
            this.textInput.Margin = new System.Windows.Forms.Padding(30);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInput.Size = new System.Drawing.Size(374, 269);
            this.textInput.TabIndex = 0;
            this.textInput.Text = "Какой-то текст";
            this.textInput.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textOutput);
            this.splitContainer1.Size = new System.Drawing.Size(750, 269);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // textOutput
            // 
            this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textOutput.Location = new System.Drawing.Point(0, 0);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOutput.Size = new System.Drawing.Size(372, 269);
            this.textOutput.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button);
            this.splitContainer2.Panel1.Controls.Add(this.progressBar);
            this.splitContainer2.Panel1.Controls.Add(this.selectedMode);
            this.splitContainer2.Panel1.Controls.Add(this.keyInput);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(750, 473);
            this.splitContainer2.SplitterDistance = 200;
            this.splitContainer2.TabIndex = 2;
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button.Location = new System.Drawing.Point(0, 145);
            this.button.Margin = new System.Windows.Forms.Padding(2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(750, 47);
            this.button.TabIndex = 0;
            this.button.Text = "Сделать";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 192);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(750, 8);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 7;
            // 
            // selectedMode
            // 
            this.selectedMode.FormattingEnabled = true;
            this.selectedMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectedMode.Items.AddRange(new object[] {
            "Кодировать",
            "Декодировать"});
            this.selectedMode.Location = new System.Drawing.Point(25, 101);
            this.selectedMode.Margin = new System.Windows.Forms.Padding(2);
            this.selectedMode.Name = "selectedMode";
            this.selectedMode.Size = new System.Drawing.Size(92, 21);
            this.selectedMode.TabIndex = 6;
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(25, 58);
            this.keyInput.Margin = new System.Windows.Forms.Padding(2);
            this.keyInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.keyInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(55, 20);
            this.keyInput.TabIndex = 5;
            this.keyInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ключ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 473);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(454, 413);
            this.Name = "Form1";
            this.Text = "Шифр Цезаря";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keyInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown keyInput;
        private System.Windows.Forms.ComboBox selectedMode;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

