namespace BadgerTech
{
    partial class Commissioner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Commissioner));
            this.tmrImage = new System.Windows.Forms.Timer(this.components);
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnDivision = new System.Windows.Forms.Button();
            this.btnCoach = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnTeam = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrImage
            // 
            this.tmrImage.Enabled = true;
            this.tmrImage.Interval = 750;
            this.tmrImage.Tick += new System.EventHandler(this.tmrImage_Tick);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSchedule.BackgroundImage")));
            this.btnSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSchedule.Location = new System.Drawing.Point(45, 435);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(185, 175);
            this.btnSchedule.TabIndex = 0;
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
           
            // 
            // btnDivision
            // 
            this.btnDivision.BackColor = System.Drawing.Color.White;
            this.btnDivision.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDivision.BackgroundImage")));
            this.btnDivision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDivision.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDivision.FlatAppearance.BorderSize = 0;
            this.btnDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivision.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivision.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDivision.Location = new System.Drawing.Point(312, 164);
            this.btnDivision.Name = "btnDivision";
            this.btnDivision.Size = new System.Drawing.Size(175, 165);
            this.btnDivision.TabIndex = 1;
            this.btnDivision.UseVisualStyleBackColor = false;
            this.btnDivision.Click += new System.EventHandler(this.btnDivision_Click);
            // 
            // btnCoach
            // 
            this.btnCoach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCoach.BackColor = System.Drawing.Color.Transparent;
            this.btnCoach.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCoach.BackgroundImage")));
            this.btnCoach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCoach.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCoach.FlatAppearance.BorderSize = 0;
            this.btnCoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoach.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoach.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnCoach.Location = new System.Drawing.Point(675, 27);
            this.btnCoach.Name = "btnCoach";
            this.btnCoach.Size = new System.Drawing.Size(165, 150);
            this.btnCoach.TabIndex = 2;
            this.btnCoach.UseVisualStyleBackColor = false;
            this.btnCoach.Click += new System.EventHandler(this.btnCoach_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogOut.BackColor = System.Drawing.Color.White;
            this.btnLogOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogOut.BackgroundImage")));
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLogOut.Location = new System.Drawing.Point(1284, 358);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(102, 96);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnTeam
            // 
            this.btnTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTeam.BackColor = System.Drawing.Color.White;
            this.btnTeam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTeam.BackgroundImage")));
            this.btnTeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTeam.FlatAppearance.BorderSize = 0;
            this.btnTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeam.ForeColor = System.Drawing.Color.White;
            this.btnTeam.Location = new System.Drawing.Point(1042, 52);
            this.btnTeam.Name = "btnTeam";
            this.btnTeam.Size = new System.Drawing.Size(140, 125);
            this.btnTeam.TabIndex = 3;
            this.btnTeam.UseVisualStyleBackColor = false;
            this.btnTeam.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1159, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 221);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnMessage
            // 
            this.btnMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMessage.BackgroundImage")));
            this.btnMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMessage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMessage.FlatAppearance.BorderSize = 0;
            this.btnMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessage.Location = new System.Drawing.Point(1246, 673);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(161, 104);
            this.btnMessage.TabIndex = 5;
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // Commissioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.btnLogOut;
            this.ClientSize = new System.Drawing.Size(1407, 774);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnDivision);
            this.Controls.Add(this.btnCoach);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnTeam);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Commissioner";
            this.Text = "Commissioner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Commissioner_FormClosed);
            this.Load += new System.EventHandler(this.Commissioner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTeam;
        private System.Windows.Forms.Button btnDivision;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Timer tmrImage;
        private System.Windows.Forms.Button btnCoach;
        private System.Windows.Forms.Button btnMessage;
    }
}