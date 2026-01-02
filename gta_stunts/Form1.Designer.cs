namespace gta_stunts
{
    partial class Form1
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
            this.bt_convert = new System.Windows.Forms.Button();
            this.tb_start = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_x = new System.Windows.Forms.TextBox();
            this.tb_y = new System.Windows.Forms.TextBox();
            this.tb_z = new System.Windows.Forms.TextBox();
            this.tb_road = new System.Windows.Forms.TextBox();
            this.tb_fini = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_about = new System.Windows.Forms.Button();
            this.ch_vc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bt_convert
            // 
            this.bt_convert.Location = new System.Drawing.Point(12, 12);
            this.bt_convert.Name = "bt_convert";
            this.bt_convert.Size = new System.Drawing.Size(370, 24);
            this.bt_convert.TabIndex = 0;
            this.bt_convert.Text = "Convert Track";
            this.bt_convert.UseVisualStyleBackColor = true;
            this.bt_convert.Click += new System.EventHandler(this.bt_convert_Click);
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(90, 72);
            this.tb_start.Name = "tb_start";
            this.tb_start.ReadOnly = true;
            this.tb_start.Size = new System.Drawing.Size(292, 20);
            this.tb_start.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Generation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Road";
            // 
            // tb_x
            // 
            this.tb_x.Location = new System.Drawing.Point(90, 160);
            this.tb_x.Name = "tb_x";
            this.tb_x.Size = new System.Drawing.Size(91, 20);
            this.tb_x.TabIndex = 4;
            // 
            // tb_y
            // 
            this.tb_y.Location = new System.Drawing.Point(90, 186);
            this.tb_y.Name = "tb_y";
            this.tb_y.Size = new System.Drawing.Size(91, 20);
            this.tb_y.TabIndex = 5;
            // 
            // tb_z
            // 
            this.tb_z.Location = new System.Drawing.Point(90, 212);
            this.tb_z.Name = "tb_z";
            this.tb_z.Size = new System.Drawing.Size(91, 20);
            this.tb_z.TabIndex = 6;
            // 
            // tb_road
            // 
            this.tb_road.Location = new System.Drawing.Point(90, 238);
            this.tb_road.Name = "tb_road";
            this.tb_road.Size = new System.Drawing.Size(91, 20);
            this.tb_road.TabIndex = 7;
            // 
            // tb_fini
            // 
            this.tb_fini.Location = new System.Drawing.Point(90, 98);
            this.tb_fini.Name = "tb_fini";
            this.tb_fini.Size = new System.Drawing.Size(91, 20);
            this.tb_fini.TabIndex = 3;
            // 
            // ofd
            // 
            this.ofd.Filter = "TRK files|*.trk";
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(254, 235);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(128, 24);
            this.bt_save.TabIndex = 8;
            this.bt_save.Text = "Save Settings";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_about
            // 
            this.bt_about.Location = new System.Drawing.Point(254, 204);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(128, 24);
            this.bt_about.TabIndex = 8;
            this.bt_about.Text = "About";
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // ch_vc
            // 
            this.ch_vc.AutoSize = true;
            this.ch_vc.Enabled = false;
            this.ch_vc.Location = new System.Drawing.Point(12, 42);
            this.ch_vc.Name = "ch_vc";
            this.ch_vc.Size = new System.Drawing.Size(67, 17);
            this.ch_vc.TabIndex = 9;
            this.ch_vc.Text = "Vice City";
            this.ch_vc.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 271);
            this.Controls.Add(this.ch_vc);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.tb_road);
            this.Controls.Add(this.tb_z);
            this.Controls.Add(this.tb_y);
            this.Controls.Add(this.tb_fini);
            this.Controls.Add(this.tb_x);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_start);
            this.Controls.Add(this.bt_convert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA: VC/SA Stunts Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_convert;
        private System.Windows.Forms.TextBox tb_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_x;
        private System.Windows.Forms.TextBox tb_y;
        private System.Windows.Forms.TextBox tb_z;
        private System.Windows.Forms.TextBox tb_road;
        private System.Windows.Forms.TextBox tb_fini;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_about;
        private System.Windows.Forms.CheckBox ch_vc;
    }
}

