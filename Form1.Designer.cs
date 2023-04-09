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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.status = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.closeKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.genKey1 = new System.Windows.Forms.Button();
            this.openKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.genPublic1 = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.status);
            this.splitContainer2.Panel1.Controls.Add(this.port);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.closeKey);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.genKey1);
            this.splitContainer2.Panel1.Controls.Add(this.openKey);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.genPublic1);
            this.splitContainer2.Panel1.Controls.Add(this.ip);
            this.splitContainer2.Panel1.Controls.Add(this.button);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textOutput);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(725, 459);
            this.splitContainer2.SplitterDistance = 298;
            this.splitContainer2.TabIndex = 2;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.status.Location = new System.Drawing.Point(22, 115);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(159, 17);
            this.status.TabIndex = 20;
            this.status.Text = "Что-то пошло не так :(";
            // 
            // port
            // 
            this.port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.port.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.port.Location = new System.Drawing.Point(171, 58);
            this.port.Margin = new System.Windows.Forms.Padding(2);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(104, 23);
            this.port.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(168, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Порт адресата";
            // 
            // closeKey
            // 
            this.closeKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.closeKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.closeKey.Location = new System.Drawing.Point(546, 58);
            this.closeKey.Margin = new System.Windows.Forms.Padding(2);
            this.closeKey.Name = "closeKey";
            this.closeKey.Size = new System.Drawing.Size(168, 23);
            this.closeKey.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(543, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Личный секретный ключ";
            // 
            // genKey1
            // 
            this.genKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genKey1.Location = new System.Drawing.Point(546, 86);
            this.genKey1.Name = "genKey1";
            this.genKey1.Size = new System.Drawing.Size(116, 30);
            this.genKey1.TabIndex = 15;
            this.genKey1.Text = "Генерировать";
            this.genKey1.UseVisualStyleBackColor = true;
            this.genKey1.Click += new System.EventHandler(this.genKey_Click);
            // 
            // openKey
            // 
            this.openKey.BackColor = System.Drawing.SystemColors.Window;
            this.openKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.openKey.Location = new System.Drawing.Point(338, 58);
            this.openKey.Margin = new System.Windows.Forms.Padding(2);
            this.openKey.Name = "openKey";
            this.openKey.Size = new System.Drawing.Size(172, 23);
            this.openKey.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(335, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Открытое простое число";
            // 
            // genPublic1
            // 
            this.genPublic1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genPublic1.Location = new System.Drawing.Point(338, 86);
            this.genPublic1.Name = "genPublic1";
            this.genPublic1.Size = new System.Drawing.Size(116, 30);
            this.genPublic1.TabIndex = 11;
            this.genPublic1.Text = "Генерировать";
            this.genPublic1.UseVisualStyleBackColor = true;
            this.genPublic1.Click += new System.EventHandler(this.genPublic_Click);
            // 
            // ip
            // 
            this.ip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ip.Location = new System.Drawing.Point(25, 58);
            this.ip.Margin = new System.Windows.Forms.Padding(2);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(128, 23);
            this.ip.TabIndex = 8;
            this.ip.Text = "127.0.0.1";
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button.Location = new System.Drawing.Point(0, 251);
            this.button.Margin = new System.Windows.Forms.Padding(2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(725, 47);
            this.button.TabIndex = 0;
            this.button.Text = "Сделать";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP адресата";
            // 
            // textOutput
            // 
            this.textOutput.BackColor = System.Drawing.SystemColors.Control;
            this.textOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textOutput.Location = new System.Drawing.Point(0, 0);
            this.textOutput.MaxLength = 1048544;
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(725, 157);
            this.textOutput.TabIndex = 0;
            this.textOutput.DoubleClick += new System.EventHandler(this.textOutput_Clear);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(725, 459);
            this.Controls.Add(this.splitContainer2);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(741, 494);
            this.Name = "Form1";
            this.Text = "Алгоритм Диффи-Хеллмана";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Button genPublic1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.TextBox closeKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button genKey1;
        private System.Windows.Forms.TextBox openKey;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label status;
    }
}

