namespace FormVentasZapateria
{
    partial class FormCrearZapato
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
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.Precio = new System.Windows.Forms.Label();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.comboBoxMateriales = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoDeTaco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(21, 30);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 6;
            this.labelNombre.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(15, 46);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(246, 20);
            this.textBoxNombre.TabIndex = 7;
            this.textBoxNombre.Text = "Ingrese nombre del articulo aquí";
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Location = new System.Drawing.Point(21, 69);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(49, 13);
            this.labelCantidad.TabIndex = 8;
            this.labelCantidad.Text = "Cantidad";
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Location = new System.Drawing.Point(15, 85);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(246, 20);
            this.textBoxCantidad.TabIndex = 9;
            this.textBoxCantidad.Text = "Ingrese cantidad de inventario aquí";
            // 
            // Precio
            // 
            this.Precio.AutoSize = true;
            this.Precio.Location = new System.Drawing.Point(21, 108);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(37, 13);
            this.Precio.TabIndex = 10;
            this.Precio.Text = "Precio";
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(15, 124);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(246, 20);
            this.textBoxPrecio.TabIndex = 11;
            this.textBoxPrecio.Text = "Ingrese precio aquí";
            // 
            // labelMaterial
            // 
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Location = new System.Drawing.Point(21, 147);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(44, 13);
            this.labelMaterial.TabIndex = 12;
            this.labelMaterial.Text = "Material";
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
            this.comboBoxMateriales.TabIndex = 13;
            // 
            // comboBoxTipoDeTaco
            // 
            this.comboBoxTipoDeTaco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDeTaco.FormattingEnabled = true;
            this.comboBoxTipoDeTaco.Items.AddRange(new object[] {
            "Stiletto",
            "Plataforma",
            "Cuña",
            "TacoBajo",
            "SinTaco"});
            this.comboBoxTipoDeTaco.Location = new System.Drawing.Point(12, 202);
            this.comboBoxTipoDeTaco.Name = "comboBoxTipoDeTaco";
            this.comboBoxTipoDeTaco.Size = new System.Drawing.Size(246, 21);
            this.comboBoxTipoDeTaco.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tipo de taco";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 249);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 249);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormCrearZapato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 284);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoDeTaco);
            this.Controls.Add(this.comboBoxMateriales);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.Precio);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.labelCantidad);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelNombre);
            this.Name = "FormCrearZapato";
            this.Text = "Crear zapato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Label Precio;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.ComboBox comboBoxMateriales;
        private System.Windows.Forms.ComboBox comboBoxTipoDeTaco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}