namespace k163810_Q2
{
    partial class Email_Composer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Email_Composer));
            this.title_label = new System.Windows.Forms.Label();
            this.to_label = new System.Windows.Forms.Label();
            this.to_textbox = new System.Windows.Forms.TextBox();
            this.sub_label = new System.Windows.Forms.Label();
            this.sub_textbox = new System.Windows.Forms.TextBox();
            this.msg_textbox = new System.Windows.Forms.RichTextBox();
            this.Msg_label = new System.Windows.Forms.Label();
            this.Send_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Papyrus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(208, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(316, 58);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "Email Composer";
            // 
            // to_label
            // 
            this.to_label.AutoSize = true;
            this.to_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_label.Location = new System.Drawing.Point(68, 81);
            this.to_label.Name = "to_label";
            this.to_label.Size = new System.Drawing.Size(47, 25);
            this.to_label.TabIndex = 1;
            this.to_label.Text = "To :";
            // 
            // to_textbox
            // 
            this.to_textbox.BackColor = System.Drawing.SystemColors.Window;
            this.to_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_textbox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.to_textbox.Location = new System.Drawing.Point(73, 109);
            this.to_textbox.Name = "to_textbox";
            this.to_textbox.Size = new System.Drawing.Size(517, 30);
            this.to_textbox.TabIndex = 2;
            // 
            // sub_label
            // 
            this.sub_label.AutoSize = true;
            this.sub_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub_label.Location = new System.Drawing.Point(68, 158);
            this.sub_label.Name = "sub_label";
            this.sub_label.Size = new System.Drawing.Size(89, 25);
            this.sub_label.TabIndex = 3;
            this.sub_label.Text = "Subject :";
            // 
            // sub_textbox
            // 
            this.sub_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub_textbox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.sub_textbox.Location = new System.Drawing.Point(73, 186);
            this.sub_textbox.Name = "sub_textbox";
            this.sub_textbox.Size = new System.Drawing.Size(517, 30);
            this.sub_textbox.TabIndex = 4;
            // 
            // msg_textbox
            // 
            this.msg_textbox.AcceptsTab = true;
            this.msg_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_textbox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.msg_textbox.Location = new System.Drawing.Point(73, 257);
            this.msg_textbox.Name = "msg_textbox";
            this.msg_textbox.Size = new System.Drawing.Size(517, 279);
            this.msg_textbox.TabIndex = 6;
            this.msg_textbox.Text = "";
            // 
            // Msg_label
            // 
            this.Msg_label.AutoSize = true;
            this.Msg_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg_label.Location = new System.Drawing.Point(68, 229);
            this.Msg_label.Name = "Msg_label";
            this.Msg_label.Size = new System.Drawing.Size(104, 25);
            this.Msg_label.TabIndex = 5;
            this.Msg_label.Text = "Message :";
            // 
            // Send_Button
            // 
            this.Send_Button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Send_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Send_Button.Location = new System.Drawing.Point(426, 542);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(164, 58);
            this.Send_Button.TabIndex = 7;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = false;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // Email_Composer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(684, 611);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.to_label);
            this.Controls.Add(this.to_textbox);
            this.Controls.Add(this.sub_label);
            this.Controls.Add(this.sub_textbox);
            this.Controls.Add(this.Msg_label);
            this.Controls.Add(this.msg_textbox);
            this.Controls.Add(this.Send_Button);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Email_Composer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Composer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Email_Composer_FormClosing);
            this.Load += new System.EventHandler(this.Email_Composer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label to_label;
        private System.Windows.Forms.TextBox to_textbox;
        private System.Windows.Forms.Label sub_label;
        private System.Windows.Forms.TextBox sub_textbox;
        private System.Windows.Forms.Label Msg_label;
        private System.Windows.Forms.RichTextBox msg_textbox;
        private System.Windows.Forms.Button Send_Button;
    }

}

