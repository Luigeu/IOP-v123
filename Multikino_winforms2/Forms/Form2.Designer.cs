namespace Multikino_Winforms
{
    partial class CEokno_Glowne
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
            this.Ldata = new System.Windows.Forms.Label();
            this.Bwyloguj = new System.Windows.Forms.Button();
            this.Bwybor_miejsc = new System.Windows.Forms.Button();
            this.Bzrealizuj_rezerwacje = new System.Windows.Forms.Button();
            this.Bprzyjmij_zwrot = new System.Windows.Forms.Button();
            this.Lista_seansow = new System.Windows.Forms.ListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDzien = new System.Windows.Forms.Label();
            this.comboNormalne = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboStudenckie = new System.Windows.Forms.ComboBox();
            this.combo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ldata
            // 
            this.Ldata.AutoSize = true;
            this.Ldata.Location = new System.Drawing.Point(36, 28);
            this.Ldata.Name = "Ldata";
            this.Ldata.Size = new System.Drawing.Size(79, 17);
            this.Ldata.TabIndex = 1;
            this.Ldata.Text = "Zmien date";
            // 
            // Bwyloguj
            // 
            this.Bwyloguj.Location = new System.Drawing.Point(78, 396);
            this.Bwyloguj.Name = "Bwyloguj";
            this.Bwyloguj.Size = new System.Drawing.Size(141, 42);
            this.Bwyloguj.TabIndex = 2;
            this.Bwyloguj.Text = "Wyloguj";
            this.Bwyloguj.UseVisualStyleBackColor = true;
            // 
            // Bwybor_miejsc
            // 
            this.Bwybor_miejsc.Location = new System.Drawing.Point(514, 396);
            this.Bwybor_miejsc.Name = "Bwybor_miejsc";
            this.Bwybor_miejsc.Size = new System.Drawing.Size(141, 42);
            this.Bwybor_miejsc.TabIndex = 3;
            this.Bwybor_miejsc.Text = "Wybor Miejsc";
            this.Bwybor_miejsc.UseVisualStyleBackColor = true;
            this.Bwybor_miejsc.Click += new System.EventHandler(this.Bwybor_miejsc_Click);
            // 
            // Bzrealizuj_rezerwacje
            // 
            this.Bzrealizuj_rezerwacje.Location = new System.Drawing.Point(459, 28);
            this.Bzrealizuj_rezerwacje.Name = "Bzrealizuj_rezerwacje";
            this.Bzrealizuj_rezerwacje.Size = new System.Drawing.Size(141, 42);
            this.Bzrealizuj_rezerwacje.TabIndex = 4;
            this.Bzrealizuj_rezerwacje.Text = "Zrealizuj rezerwacje";
            this.Bzrealizuj_rezerwacje.UseVisualStyleBackColor = true;
            // 
            // Bprzyjmij_zwrot
            // 
            this.Bprzyjmij_zwrot.Location = new System.Drawing.Point(459, 101);
            this.Bprzyjmij_zwrot.Name = "Bprzyjmij_zwrot";
            this.Bprzyjmij_zwrot.Size = new System.Drawing.Size(141, 42);
            this.Bprzyjmij_zwrot.TabIndex = 5;
            this.Bprzyjmij_zwrot.Text = "Przyjmij Zwrot";
            this.Bprzyjmij_zwrot.UseVisualStyleBackColor = true;
            // 
            // Lista_seansow
            // 
            this.Lista_seansow.FormattingEnabled = true;
            this.Lista_seansow.ItemHeight = 16;
            this.Lista_seansow.Location = new System.Drawing.Point(36, 101);
            this.Lista_seansow.Name = "Lista_seansow";
            this.Lista_seansow.Size = new System.Drawing.Size(355, 260);
            this.Lista_seansow.TabIndex = 6;
            this.Lista_seansow.SelectedIndexChanged += new System.EventHandler(this.Lista_seansow_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(272, 22);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelDzien
            // 
            this.labelDzien.AutoSize = true;
            this.labelDzien.Location = new System.Drawing.Point(426, 9);
            this.labelDzien.Name = "labelDzien";
            this.labelDzien.Size = new System.Drawing.Size(12, 17);
            this.labelDzien.TabIndex = 8;
            this.labelDzien.Text = " ";
            // 
            // comboNormalne
            // 
            this.comboNormalne.FormattingEnabled = true;
            this.comboNormalne.Location = new System.Drawing.Point(534, 220);
            this.comboNormalne.Name = "comboNormalne";
            this.comboNormalne.Size = new System.Drawing.Size(121, 24);
            this.comboNormalne.TabIndex = 9;
            this.comboNormalne.Text = "1";
            this.comboNormalne.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(443, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wybor biletow";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboStudenckie
            // 
            this.comboStudenckie.FormattingEnabled = true;
            this.comboStudenckie.Location = new System.Drawing.Point(534, 263);
            this.comboStudenckie.Name = "comboStudenckie";
            this.comboStudenckie.Size = new System.Drawing.Size(121, 24);
            this.comboStudenckie.TabIndex = 11;
            this.comboStudenckie.Text = "0";
            // 
            // combo
            // 
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(534, 308);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(121, 24);
            this.combo.TabIndex = 12;
            this.combo.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Normalne";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Studenckie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Seniorskie";
            // 
            // CEokno_Glowne
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.comboStudenckie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboNormalne);
            this.Controls.Add(this.labelDzien);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Lista_seansow);
            this.Controls.Add(this.Bprzyjmij_zwrot);
            this.Controls.Add(this.Bzrealizuj_rezerwacje);
            this.Controls.Add(this.Bwybor_miejsc);
            this.Controls.Add(this.Bwyloguj);
            this.Controls.Add(this.Ldata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CEokno_Glowne";
            this.Text = "Okno Glowne Kasjera";
            this.Load += new System.EventHandler(this.CEokno_Glowne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Ldata;
        private System.Windows.Forms.Button Bwyloguj;
        private System.Windows.Forms.Button Bwybor_miejsc;
        private System.Windows.Forms.Button Bzrealizuj_rezerwacje;
        private System.Windows.Forms.Button Bprzyjmij_zwrot;
        private System.Windows.Forms.ListBox Lista_seansow;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDzien;
        private System.Windows.Forms.ComboBox comboNormalne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboStudenckie;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}