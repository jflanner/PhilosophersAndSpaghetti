namespace PhilosophersAndSpaghetti
{
    partial class ProgramUI
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
            this.ButtonStart = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(1030, 688);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(95, 23);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // Table
            // 
            this.Table.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Table.BackColor = System.Drawing.Color.LightBlue;
            this.Table.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Table.Location = new System.Drawing.Point(454, 235);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(300, 232);
            this.Table.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Table.TabIndex = 1;
            this.Table.TabStop = false;
            // 
            // ProgramUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1269, 763);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.ButtonStart);
            this.Name = "ProgramUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PhilosophersAndSpaghetti";
            this.Load += new System.EventHandler(this.ProgramUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.PictureBox Table;
    }
}

