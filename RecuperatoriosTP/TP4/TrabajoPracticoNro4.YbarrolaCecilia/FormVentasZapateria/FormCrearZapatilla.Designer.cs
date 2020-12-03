namespace FormVentasZapateria
{
    partial class FormCrearZapatilla
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
            this.comboBoxMateriales = new System.Windows.Forms.ComboBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.comboBoxUsoRecomendado = new System.Windows.Forms.ComboBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.Precio = new System.Windows.Forms.Label();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.labelUsoRecomendado = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxMateriales
            // 
            this.comboBoxMateriales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriales.FormattingEnabled = true;
            this.comboBoxMateriales.Items.AddRange(new object[] {
            "Cuero",
            "EcoCuero",
            "Lona",
            "Gamuza",
            "Tela",
            "Otro"});
            this.comboBoxMateriales.Location = new System.Drawing.Point(12, 163);
            this.comboBoxMateriales.Name = "comboBoxMateriales";
            this.comboBoxMateriales.Size = new System.Drawing.Size(246, 21);
            this.comboBoxMateriales.TabIndex = 0;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(12, 45);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(246, 20);
            this.textBoxNombre.TabIndex = 1;
            this.textBoxNombre.Text = "Ingrese nombre del articulo aquí";
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Location = new System.Drawing.Point(12, 85);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(246, 20);
            this.textBoxCantidad.TabIndex = 2;
            this.textBoxCantidad.Text = "Ingrese cantidad de inventario aquí";
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(12, 124);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(246, 20);
            this.textBoxPrecio.TabIndex = 3;
            this.textBoxPrecio.Text = "Ingrese precio aquí";
            // 
            // comboBoxUsoRecomendado
            // 
            this.comboBoxUsoRecomendado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsoRecomendado.FormattingEnabled = true;
            this.comboBoxUsoRecomendado.Items.AddRange(new object[] {
            "Trainning",
            "Running",
            "Yoga",
            "Crossfit",
            "UsoCotidiano"});
            this.comboBoxUsoRecomendado.Location = new System.Drawing.Point(12, 203);
            this.comboBoxUsoRecomendado.Name = "comboBoxUsoRecomendado";
            this.comboBoxUsoRecomendado.Size = new System.Drawing.Size(246, 21);
            this.comboBoxUsoRecomendado.TabIndex = 4;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(14, 26);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 5;
            this.labelNombre.Text = "Nombre";
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Location = new System.Drawing.Point(14, 69);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(49, 13);
            this.labelCantidad.TabIndex = 6;
            this.labelCantidad.Text = "Cantidad";
            // 
            // Precio
            // 
            this.Precio.AutoSize = true;
            this.Precio.Location = new System.Drawing.Point(14, 108);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(37, 13);
            this.Precio.TabIndex = 7;
            this.Precio.Text = "Precio";
            // 
            // labelMaterial
            // 
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Location = new System.Drawing.Point(14, 147);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(44, 13);
            this.labelMaterial.TabIndex = 8;
            this.labelMaterial.Text = "Material";
            // 
            // labelUsoRecomendado
            // 
            this.labelUsoRecomendado.AutoSize = true;
            this.labelUsoRecomendado.Location = new System.Drawing.Point(14, 187);
            this.labelUsoRecomendado.Name = "labelUsoRecomendado";
            this.labelUsoRecomendado.Size = new System.Drawing.Size(96, 13);
            this.labelUsoRecomendado.TabIndex = 9;
            this.labelUsoRecomendado.Text = "UsoRecomendado";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 248);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 248);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormCrearZapatilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 283);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.labelUsoRecomendado);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.Precio);
            this.Controls.Add(this.labelCantidad);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.comboBoxUsoRecomendado);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.comboBoxMateriales);
            this.Name = "FormCrearZapatilla";
            this.Text = "Crear zapatilla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMateriales;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.ComboBox comboBoxUsoRecomendado;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.Label Precio;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.Label labelUsoRecomendado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}