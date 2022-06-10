namespace SignalRClientDesktopApp
{
    partial class SignalRClientForm
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
            this.connection_status = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // connection_status
            // 
            this.connection_status.AutoSize = true;
            this.connection_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connection_status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connection_status.Location = new System.Drawing.Point(273, 22);
            this.connection_status.Name = "connection_status";
            this.connection_status.Size = new System.Drawing.Size(113, 23);
            this.connection_status.TabIndex = 0;
            this.connection_status.Text = "Not connected";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(110, 22);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(147, 21);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Connection status";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(110, 79);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(276, 96);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // SignalRClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 403);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.connection_status);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SignalRClientForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SignalRClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label connection_status;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
