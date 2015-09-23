namespace ChatClient
{
    partial class ClientForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.joinBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.nickLbl = new System.Windows.Forms.Label();
            this.nickBox = new System.Windows.Forms.TextBox();
            this.nickBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // joinBtn
            // 
            this.joinBtn.Location = new System.Drawing.Point(2, 277);
            this.joinBtn.Name = "joinBtn";
            this.joinBtn.Size = new System.Drawing.Size(110, 32);
            this.joinBtn.TabIndex = 0;
            this.joinBtn.TabStop = false;
            this.joinBtn.Text = "Join";
            this.joinBtn.UseVisualStyleBackColor = true;
            this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(-1, 317);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(109, 13);
            this.statusLbl.TabIndex = 3;
            this.statusLbl.Text = "Press \"Join\" to begin.";
            // 
            // nickLbl
            // 
            this.nickLbl.AutoSize = true;
            this.nickLbl.Location = new System.Drawing.Point(20, 14);
            this.nickLbl.Name = "nickLbl";
            this.nickLbl.Size = new System.Drawing.Size(78, 13);
            this.nickLbl.TabIndex = 4;
            this.nickLbl.Text = "Your nickname";
            // 
            // nickBox
            // 
            this.nickBox.Location = new System.Drawing.Point(2, 30);
            this.nickBox.Name = "nickBox";
            this.nickBox.Size = new System.Drawing.Size(110, 20);
            this.nickBox.TabIndex = 1;
            this.nickBox.Text = "Rezenbekk";
            this.nickBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nickBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nickBox_KeyDown);
            // 
            // nickBtn
            // 
            this.nickBtn.Location = new System.Drawing.Point(2, 57);
            this.nickBtn.Name = "nickBtn";
            this.nickBtn.Size = new System.Drawing.Size(110, 23);
            this.nickBtn.TabIndex = 6;
            this.nickBtn.Text = "Change (off)";
            this.nickBtn.UseVisualStyleBackColor = true;
            this.nickBtn.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 254);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Write logs (off)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(118, 258);
            this.sendBox.Multiline = true;
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(345, 72);
            this.sendBox.TabIndex = 2;
            this.sendBox.Text = "Enter your message";
            this.sendBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendBox_KeyDown);
            this.sendBox.Leave += new System.EventHandler(this.sendBox_Leave);
            this.sendBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sendBox_MouseUp);
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(470, 257);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(68, 73);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.Window;
            this.chatBox.Location = new System.Drawing.Point(118, 11);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(420, 240);
            this.chatBox.TabIndex = 8;
            this.chatBox.TabStop = false;
            this.chatBox.Text = "Hi there!";
            this.chatBox.TextChanged += new System.EventHandler(this.chatBox_TextChanged);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 335);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.nickBtn);
            this.Controls.Add(this.nickBox);
            this.Controls.Add(this.nickLbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.joinBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button joinBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label nickLbl;
        private System.Windows.Forms.TextBox nickBox;
        private System.Windows.Forms.Button nickBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.RichTextBox chatBox;
    }
}

