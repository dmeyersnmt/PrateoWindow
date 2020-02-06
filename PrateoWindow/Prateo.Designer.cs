namespace PrateoWindow
{
    partial class Prateo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Build = new System.Windows.Forms.Button();
            this.comboBoxConnectedServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPiPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.textBoxEndTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(221, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_Build
            // 
            this.button_Build.Location = new System.Drawing.Point(12, 282);
            this.button_Build.Name = "button_Build";
            this.button_Build.Size = new System.Drawing.Size(75, 23);
            this.button_Build.TabIndex = 1;
            this.button_Build.Text = "Build";
            this.button_Build.UseVisualStyleBackColor = true;
            this.button_Build.Click += new System.EventHandler(this.button_Build_Click);
            // 
            // comboBoxConnectedServers
            // 
            this.comboBoxConnectedServers.FormattingEnabled = true;
            this.comboBoxConnectedServers.Location = new System.Drawing.Point(12, 67);
            this.comboBoxConnectedServers.Name = "comboBoxConnectedServers";
            this.comboBoxConnectedServers.Size = new System.Drawing.Size(121, 21);
            this.comboBoxConnectedServers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected PI Server:";
            // 
            // textBoxPiPoint
            // 
            this.textBoxPiPoint.Location = new System.Drawing.Point(12, 118);
            this.textBoxPiPoint.Name = "textBoxPiPoint";
            this.textBoxPiPoint.Size = new System.Drawing.Size(148, 20);
            this.textBoxPiPoint.TabIndex = 4;
            this.textBoxPiPoint.Text = "N_MML12001LastTrip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter PI Point:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Time:";
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.Location = new System.Drawing.Point(12, 187);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(148, 20);
            this.textBoxStartTime.TabIndex = 7;
            this.textBoxStartTime.Text = "*-7d";
            // 
            // textBoxEndTime
            // 
            this.textBoxEndTime.Location = new System.Drawing.Point(12, 235);
            this.textBoxEndTime.Name = "textBoxEndTime";
            this.textBoxEndTime.Size = new System.Drawing.Size(148, 20);
            this.textBoxEndTime.TabIndex = 9;
            this.textBoxEndTime.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "End Time:";
            // 
            // Prateo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 450);
            this.Controls.Add(this.textBoxEndTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStartTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPiPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxConnectedServers);
            this.Controls.Add(this.button_Build);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Prateo";
            this.Text = "Prateo";
            this.Load += new System.EventHandler(this.Prateo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Build;
        private System.Windows.Forms.ComboBox comboBoxConnectedServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPiPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.Label label4;
    }
}

