namespace HoneyPotScreenSaver
{
	partial class ScreenBackdropForm
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
			this.lblWarning = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblWarning
			// 
			this.lblWarning.AutoSize = true;
			this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWarning.ForeColor = System.Drawing.Color.Red;
			this.lblWarning.Location = new System.Drawing.Point(12, 19);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(744, 117);
			this.lblWarning.TabIndex = 0;
			this.lblWarning.Text = "Warning!\r\nYou are attempting to access a restricted PC!!! \r\nSTEP AWAY FROM THE CO" +
    "MPUTER!";
			this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(12, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 39);
			this.label3.TabIndex = 2;
			// 
			// ScreenBackdropForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(763, 149);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblWarning);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "ScreenBackdropForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScreenBackdropForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblWarning;
		private System.Windows.Forms.Label label3;
	}
}