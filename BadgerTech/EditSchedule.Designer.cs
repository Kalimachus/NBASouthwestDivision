namespace BadgerTech
{
    partial class EditSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSchedule));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvEdit = new System.Windows.Forms.DataGridView();
            this.radSchedule = new System.Windows.Forms.RadioButton();
            this.radCoach = new System.Windows.Forms.RadioButton();
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.radPlayer = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtEdit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).BeginInit();
            this.grpSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Location = new System.Drawing.Point(308, 261);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 29);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dgvEdit
            // 
            this.dgvEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvEdit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvEdit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEdit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEdit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEdit.EnableHeadersVisualStyles = false;
            this.dgvEdit.GridColor = System.Drawing.Color.DarkRed;
            this.dgvEdit.Location = new System.Drawing.Point(469, 299);
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEdit.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEdit.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvEdit.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEdit.Size = new System.Drawing.Size(473, 163);
            this.dgvEdit.TabIndex = 1;
            this.dgvEdit.SelectionChanged += new System.EventHandler(this.dgvEdit_SelectionChanged);
            // 
            // radSchedule
            // 
            this.radSchedule.AutoSize = true;
            this.radSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radSchedule.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.radSchedule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.radSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radSchedule.Location = new System.Drawing.Point(6, 19);
            this.radSchedule.Name = "radSchedule";
            this.radSchedule.Size = new System.Drawing.Size(90, 20);
            this.radSchedule.TabIndex = 2;
            this.radSchedule.TabStop = true;
            this.radSchedule.Text = "Schedule";
            this.radSchedule.UseVisualStyleBackColor = true;
            // 
            // radCoach
            // 
            this.radCoach.AutoSize = true;
            this.radCoach.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.radCoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radCoach.Location = new System.Drawing.Point(6, 43);
            this.radCoach.Name = "radCoach";
            this.radCoach.Size = new System.Drawing.Size(69, 20);
            this.radCoach.TabIndex = 3;
            this.radCoach.TabStop = true;
            this.radCoach.Text = "Coach";
            this.radCoach.UseVisualStyleBackColor = true;
            // 
            // grpSelection
            // 
            this.grpSelection.BackColor = System.Drawing.Color.Transparent;
            this.grpSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grpSelection.Controls.Add(this.radPlayer);
            this.grpSelection.Controls.Add(this.radCoach);
            this.grpSelection.Controls.Add(this.radSchedule);
            this.grpSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSelection.ForeColor = System.Drawing.Color.SandyBrown;
            this.grpSelection.Location = new System.Drawing.Point(12, 12);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(119, 100);
            this.grpSelection.TabIndex = 4;
            this.grpSelection.TabStop = false;
            this.grpSelection.Visible = false;
            // 
            // radPlayer
            // 
            this.radPlayer.AutoSize = true;
            this.radPlayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.radPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radPlayer.Location = new System.Drawing.Point(6, 66);
            this.radPlayer.Name = "radPlayer";
            this.radPlayer.Size = new System.Drawing.Size(78, 20);
            this.radPlayer.TabIndex = 4;
            this.radPlayer.TabStop = true;
            this.radPlayer.Text = "Players";
            this.radPlayer.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnDelete.Location = new System.Drawing.Point(308, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 37);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Delete Row";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnExit.Location = new System.Drawing.Point(1266, 595);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 41);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEdit
            // 
            this.txtEdit.BackColor = System.Drawing.Color.SandyBrown;
            this.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdit.Location = new System.Drawing.Point(442, 268);
            this.txtEdit.Multiline = true;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEdit.Size = new System.Drawing.Size(540, 220);
            this.txtEdit.TabIndex = 7;
            this.txtEdit.Visible = false;
            // 
            // EditSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1378, 637);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpSelection);
            this.Controls.Add(this.dgvEdit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtEdit);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSchedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EditSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdit)).EndInit();
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.DataGridView dgvEdit;
        public System.Windows.Forms.RadioButton radSchedule;
        public System.Windows.Forms.RadioButton radCoach;
        public System.Windows.Forms.RadioButton radPlayer;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.GroupBox grpSelection;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.TextBox txtEdit;
    }
}