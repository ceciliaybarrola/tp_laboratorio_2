namespace FormVentasZapateria
{
    partial class FormAgregarProductos
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
            this.BotonAgregarZapatilla = new System.Windows.Forms.Button();
            this.BotonAgregarZapato = new System.Windows.Forms.Button();
            this.CategoriasProductos = new System.Windows.Forms.GroupBox();
            this.BotonCancelar = new System.Windows.Forms.Button();
            this.BotonAceptar = new System.Windows.Forms.Button();
            this.CategoriasProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotonAgregarZapatilla
            // 
            this.BotonAgregarZapatilla.Location = new System.Drawing.Point(196, 29);
            this.BotonAgregarZapatilla.Name = "BotonAgregarZapatilla";
            this.BotonAgregarZapatilla.Size = new System.Drawing.Size(184, 37);
            this.BotonAgregarZapatilla.TabIndex = 0;
            this.BotonAgregarZapatilla.Text = "Agregar Zapatilla";
            this.BotonAgregarZapatilla.UseVisualStyleBackColor = true;
            this.BotonAgregarZapatilla.Click += new System.EventHandler(this.BotonAgregarZapatilla_Click);
            // 
            // BotonAgregarZapato
            // 
            this.BotonAgregarZapato.Location = new System.Drawing.Point(6, 29);
            this.BotonAgregarZapato.Name = "BotonAgregarZapato";
            this.BotonAgregarZapato.Size = new System.Drawing.Size(184, 37);
            this.BotonAgregarZapato.TabIndex = 1;
            this.BotonAgregarZapato.Text = "Agregar Zapato";
            this.BotonAgregarZapato.UseVisualStyleBackColor = true;
            this.BotonAgregarZapato.Click += new System.EventHandler(this.BotonAgregarZapato_Click);
            // 
            // CategoriasProductos
            // 
            this.CategoriasProductos.Controls.Add(this.BotonAgregarZapato);
            this.CategoriasProductos.Controls.Add(this.BotonAgregarZapatilla);
            this.CategoriasProductos.Location = new System.Drawing.Point(12, 12);
            this.CategoriasProductos.Name = "CategoriasProductos";
            this.CategoriasProductos.Size = new System.Drawing.Size(401, 86);
            this.CategoriasProductos.TabIndex = 2;
            this.CategoriasProductos.TabStop = false;
            this.CategoriasProductos.Text = "Categoria Producto";
            // 
            // BotonCancelar
            // 
            this.BotonCancelar.Location = new System.Drawing.Point(218, 108);
            this.BotonCancelar.Name = "BotonCancelar";
            this.BotonCancelar.Size = new System.Drawing.Size(163, 33);
            this.BotonCancelar.TabIndex = 3;
            this.BotonCancelar.Text = "Cancelar";
            this.BotonCancelar.UseVisualStyleBackColor = true;
            this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // BotonAceptar
            // 
            this.BotonAceptar.Location = new System.Drawing.Point(30, 109);
            this.BotonAceptar.Name = "BotonAceptar";
            this.BotonAceptar.Size = new System.Drawing.Size(163, 33);
            this.BotonAceptar.TabIndex = 4;
            this.BotonAceptar.Text = "Aceptar";
            this.BotonAceptar.UseVisualStyleBackColor = true;
            this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // FormAgregarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 154);
            this.Controls.Add(this.BotonAceptar);
            this.Controls.Add(this.BotonCancelar);
            this.Controls.Add(this.CategoriasProductos);
            this.Name = "FormAgregarProductos";
            this.Text = "FormProductos";
            this.CategoriasProductos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BotonAgregarZapatilla;
        private System.Windows.Forms.Button BotonAgregarZapato;
        private System.Windows.Forms.GroupBox CategoriasProductos;
        private System.Windows.Forms.Button BotonCancelar;
        private System.Windows.Forms.Button BotonAceptar;
    }
}