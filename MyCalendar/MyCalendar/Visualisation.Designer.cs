namespace MyCalendar
{
    partial class Visualisation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualisation));
            this.genCalendar = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // genCalendar
            // 
            this.genCalendar.AutoSize = true;
            this.genCalendar.BackColor = System.Drawing.Color.Yellow;
            this.genCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.genCalendar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.genCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genCalendar.Location = new System.Drawing.Point(56, 203);
            this.genCalendar.Name = "genCalendar";
            this.genCalendar.Size = new System.Drawing.Size(292, 72);
            this.genCalendar.TabIndex = 1;
            this.genCalendar.Text = "Build calendar page";
            this.genCalendar.UseVisualStyleBackColor = false;
            this.genCalendar.Click += new System.EventHandler(this.genCalendar_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(83, 77);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(233, 42);
            this.label.TabIndex = 2;
            this.label.Text = " Enter date :";
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date.Location = new System.Drawing.Point(56, 145);
            this.date.Multiline = true;
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(290, 36);
            this.date.TabIndex = 3;
            // 
            // Visualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label);
            this.Controls.Add(this.genCalendar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visualisation";
            this.Text = "CalendarPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button genCalendar;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox date;
    }
}