namespace InfoBez
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
            this.key = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.selectedMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lengh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textInput.Location = new System.Drawing.Point(0, 0);
            this.textInput.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(374, 256);
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
            this.splitContainer1.Size = new System.Drawing.Size(750, 256);
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
            this.textOutput.Size = new System.Drawing.Size(372, 256);
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
            this.splitContainer2.Panel1.Controls.Add(this.lengh);
            this.splitContainer2.Panel1.Controls.Add(this.key);
            this.splitContainer2.Panel1.Controls.Add(this.button);
            this.splitContainer2.Panel1.Controls.Add(this.progressBar);
            this.splitContainer2.Panel1.Controls.Add(this.selectedMode);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(750, 473);
            this.splitContainer2.SplitterDistance = 213;
            this.splitContainer2.TabIndex = 2;
            // 
            // key
            // 
            this.key.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.key.Location = new System.Drawing.Point(25, 58);
            this.key.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(350, 23);
            this.key.TabIndex = 8;
            this.key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_KeyPress);
            this.key.MouseEnter += new System.EventHandler(this.key_MouseEnter);
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button.Location = new System.Drawing.Point(0, 158);
            this.button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.progressBar.Location = new System.Drawing.Point(0, 205);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.selectedMode.Location = new System.Drawing.Point(25, 121);
            this.selectedMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectedMode.Name = "selectedMode";
            this.selectedMode.Size = new System.Drawing.Size(92, 21);
            this.selectedMode.TabIndex = 6;
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
            // lengh
            // 
            this.lengh.AutoSize = true;
            this.lengh.Location = new System.Drawing.Point(25, 87);
            this.lengh.Name = "lengh";
            this.lengh.Size = new System.Drawing.Size(80, 13);
            this.lengh.TabIndex = 9;
            this.lengh.Text = "(длина текста)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 473);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(454, 494);
            this.Name = "Form1";
            this.Text = "Шифр перестановки";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectedMode;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.Label lengh;
    }
}

