namespace MMMMTrainer
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.formTimer = new System.Windows.Forms.Timer(this.components);
            this.screenShot = new System.Windows.Forms.Button();
            this.sstest = new System.Windows.Forms.PictureBox();
            this.roomName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sstest)).BeginInit();
            this.SuspendLayout();
            // 
            // formTimer
            // 
            this.formTimer.Enabled = true;
            this.formTimer.Interval = 50;
            this.formTimer.Tick += new System.EventHandler(this.formTimer_Tick);
            // 
            // screenShot
            // 
            this.screenShot.Location = new System.Drawing.Point(0, 12);
            this.screenShot.Name = "screenShot";
            this.screenShot.Size = new System.Drawing.Size(75, 23);
            this.screenShot.TabIndex = 0;
            this.screenShot.Text = "Screenshot";
            this.screenShot.UseVisualStyleBackColor = true;
            this.screenShot.Visible = false;
            this.screenShot.Click += new System.EventHandler(this.screenShot_Click);
            // 
            // sstest
            // 
            this.sstest.BackColor = System.Drawing.Color.Transparent;
            this.sstest.Location = new System.Drawing.Point(0, 0);
            this.sstest.Name = "sstest";
            this.sstest.Size = new System.Drawing.Size(862, 583);
            this.sstest.TabIndex = 1;
            this.sstest.TabStop = false;
            this.sstest.Click += new System.EventHandler(this.sstest_Click);
            // 
            // roomName
            // 
            this.roomName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.roomName.Location = new System.Drawing.Point(-3, 38);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(75, 23);
            this.roomName.TabIndex = 2;
            this.roomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.roomName.Visible = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(942, 595);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.screenShot);
            this.Controls.Add(this.sstest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sstest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer formTimer;
        private System.Windows.Forms.Button screenShot;
        private System.Windows.Forms.PictureBox sstest;
        private System.Windows.Forms.Label roomName;
    }
}