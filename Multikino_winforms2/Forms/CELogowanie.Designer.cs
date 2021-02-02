namespace Multikino_Winforms
{
    partial class CELogowanie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.BLogowanie = new System.Windows.Forms.Button();
            this.ID_kasjera = new System.Windows.Forms.Label();
            this.LHaslo = new System.Windows.Forms.Label();
            this.TID_Kasjera = new System.Windows.Forms.TextBox();
            this.THaslo = new System.Windows.Forms.TextBox();
            this.LInformacje_logowania = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BLogowanie
            // 
            this.BLogowanie.Location = new System.Drawing.Point(415, 71);
            this.BLogowanie.Name = "BLogowanie";
            this.BLogowanie.Size = new System.Drawing.Size(115, 34);
            this.BLogowanie.TabIndex = 0;
            this.BLogowanie.Text = "Zaloguj";
            this.BLogowanie.UseVisualStyleBackColor = true;
            this.BLogowanie.Click += new System.EventHandler(this.BLogowanie_Click);
            // 
            // ID_kasjera
            // 
            this.ID_kasjera.AutoSize = true;
            this.ID_kasjera.Location = new System.Drawing.Point(40, 49);
            this.ID_kasjera.Name = "ID_kasjera";
            this.ID_kasjera.Size = new System.Drawing.Size(77, 17);
            this.ID_kasjera.TabIndex = 1;
            this.ID_kasjera.Text = "ID Kasjera:";
            this.ID_kasjera.Click += new System.EventHandler(this.ID_kasjera_Click);
            // 
            // LHaslo
            // 
            this.LHaslo.AutoSize = true;
            this.LHaslo.Location = new System.Drawing.Point(40, 103);
            this.LHaslo.Name = "LHaslo";
            this.LHaslo.Size = new System.Drawing.Size(48, 17);
            this.LHaslo.TabIndex = 2;
            this.LHaslo.Text = "Hasło:";
            this.LHaslo.Click += new System.EventHandler(this.LHaslo_Click);
            // 
            // TID_Kasjera
            // 
            this.TID_Kasjera.Location = new System.Drawing.Point(160, 49);
            this.TID_Kasjera.Name = "TID_Kasjera";
            this.TID_Kasjera.Size = new System.Drawing.Size(156, 22);
            this.TID_Kasjera.TabIndex = 3;
            this.TID_Kasjera.TextChanged += new System.EventHandler(this.TID_Kasjera_TextChanged);
            // 
            // THaslo
            // 
            this.THaslo.Location = new System.Drawing.Point(160, 103);
            this.THaslo.Name = "THaslo";
            this.THaslo.Size = new System.Drawing.Size(156, 22);
            this.THaslo.TabIndex = 4;
            this.THaslo.UseSystemPasswordChar = true;
            this.THaslo.TextChanged += new System.EventHandler(this.THaslo_TextChanged);
            // 
            // LInformacje_logowania
            // 
            this.LInformacje_logowania.AutoSize = true;
            this.LInformacje_logowania.Location = new System.Drawing.Point(43, 13);
            this.LInformacje_logowania.Name = "LInformacje_logowania";
            this.LInformacje_logowania.Size = new System.Drawing.Size(16, 17);
            this.LInformacje_logowania.TabIndex = 5;
            this.LInformacje_logowania.Text = "  ";
            // 
            // CELogowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 159);
            this.Controls.Add(this.LInformacje_logowania);
            this.Controls.Add(this.THaslo);
            this.Controls.Add(this.TID_Kasjera);
            this.Controls.Add(this.LHaslo);
            this.Controls.Add(this.ID_kasjera);
            this.Controls.Add(this.BLogowanie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CELogowanie";
            this.Text = "Logowanie";
            this.Load += new System.EventHandler(this.CELogowanie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BLogowanie;
        private System.Windows.Forms.Label ID_kasjera;
        private System.Windows.Forms.Label LHaslo;
        private System.Windows.Forms.TextBox TID_Kasjera;
        private System.Windows.Forms.TextBox THaslo;
        private System.Windows.Forms.Label LInformacje_logowania;
    }
}

