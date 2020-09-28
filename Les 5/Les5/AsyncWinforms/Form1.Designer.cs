namespace AsyncWinforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_buttons = new System.Windows.Forms.GroupBox();
            this.btn_async = new System.Windows.Forms.Button();
            this.btn_nonAsync = new System.Windows.Forms.Button();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.gb_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_buttons
            // 
            this.gb_buttons.Controls.Add(this.btn_async);
            this.gb_buttons.Controls.Add(this.btn_nonAsync);
            this.gb_buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_buttons.Location = new System.Drawing.Point(0, 0);
            this.gb_buttons.Name = "gb_buttons";
            this.gb_buttons.Size = new System.Drawing.Size(800, 125);
            this.gb_buttons.TabIndex = 0;
            this.gb_buttons.TabStop = false;
            this.gb_buttons.Text = "Buttons";
            // 
            // btn_async
            // 
            this.btn_async.Location = new System.Drawing.Point(110, 28);
            this.btn_async.Name = "btn_async";
            this.btn_async.Size = new System.Drawing.Size(94, 29);
            this.btn_async.TabIndex = 1;
            this.btn_async.Text = "async";
            this.btn_async.UseVisualStyleBackColor = true;
            this.btn_async.Click += new System.EventHandler(this.btn_async_Click);
            // 
            // btn_nonAsync
            // 
            this.btn_nonAsync.Location = new System.Drawing.Point(7, 27);
            this.btn_nonAsync.Name = "btn_nonAsync";
            this.btn_nonAsync.Size = new System.Drawing.Size(94, 29);
            this.btn_nonAsync.TabIndex = 0;
            this.btn_nonAsync.Text = "No async";
            this.btn_nonAsync.UseVisualStyleBackColor = true;
            this.btn_nonAsync.Click += new System.EventHandler(this.btn_nonAsync_Click);
            // 
            // txt_Message
            // 
            this.txt_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Message.Location = new System.Drawing.Point(0, 125);
            this.txt_Message.Multiline = true;
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Message.Size = new System.Drawing.Size(800, 325);
            this.txt_Message.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Message);
            this.Controls.Add(this.gb_buttons);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gb_buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_buttons;
        private System.Windows.Forms.Button btn_nonAsync;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Button btn_async;
    }
}

