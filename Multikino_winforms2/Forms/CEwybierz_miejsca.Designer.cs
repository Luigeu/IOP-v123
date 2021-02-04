using System;
using System.Drawing;
using System.Windows.Forms;

namespace Multikino_Winforms.Forms
{
    partial class CEwybierz_miejsca
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cofnij = new System.Windows.Forms.Button();
            this.btn_dalej = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWprowadzIDklienta = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(39, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(614, 277);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wybierz miejsce";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_cofnij
            // 
            this.btn_cofnij.BackColor = System.Drawing.SystemColors.Control;
            this.btn_cofnij.Location = new System.Drawing.Point(12, 550);
            this.btn_cofnij.Name = "btn_cofnij";
            this.btn_cofnij.Size = new System.Drawing.Size(224, 44);
            this.btn_cofnij.TabIndex = 4;
            this.btn_cofnij.Text = "Cofnij";
            this.btn_cofnij.UseVisualStyleBackColor = false;
            this.btn_cofnij.Click += new System.EventHandler(this.btn_cofnij_Click);
            // 
            // btn_dalej
            // 
            this.btn_dalej.Location = new System.Drawing.Point(454, 550);
            this.btn_dalej.Name = "btn_dalej";
            this.btn_dalej.Size = new System.Drawing.Size(224, 44);
            this.btn_dalej.TabIndex = 5;
            this.btn_dalej.Text = "Zrealizuj Platnosc";
            this.btn_dalej.UseVisualStyleBackColor = true;
            this.btn_dalej.Click += new System.EventHandler(this.btn_dalej_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(265, 508);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID Klienta";
            // 
            // btnWprowadzIDklienta
            // 
            this.btnWprowadzIDklienta.Location = new System.Drawing.Point(503, 501);
            this.btnWprowadzIDklienta.Name = "btnWprowadzIDklienta";
            this.btnWprowadzIDklienta.Size = new System.Drawing.Size(150, 36);
            this.btnWprowadzIDklienta.TabIndex = 10;
            this.btnWprowadzIDklienta.Text = "Wprowadz";
            this.btnWprowadzIDklienta.UseVisualStyleBackColor = true;
            this.btnWprowadzIDklienta.Click += new System.EventHandler(this.btnWprowadzIDklienta_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(39, 364);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(322, 125);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cena biletow";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Pozostala liczba miejsc do wybrania:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 15;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CEwybierz_miejsca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 606);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnWprowadzIDklienta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dalej);
            this.Controls.Add(this.btn_cofnij);
            this.Name = "CEwybierz_miejsca";
            this.Text = "CEwybierz_miejsca";
            this.Load += new System.EventHandler(this.CEwybierz_miejsca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Button btn_cofnij;
        private Button btn_dalej;
        private TextBox textBox1;
        private Label label2;
        private Button btnWprowadzIDklienta;
        private RichTextBox richTextBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}