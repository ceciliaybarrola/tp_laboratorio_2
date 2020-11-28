namespace FormVentasZapateria
{
    partial class FormularioPrincipalZapateria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewDataTable = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Salir = new System.Windows.Forms.Button();
            this.GuardarCambios = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CancelarCompra = new System.Windows.Forms.Button();
            this.AñadirAlCarro = new System.Windows.Forms.Button();
            this.labelVentas = new System.Windows.Forms.Label();
            this.labelGanancias = new System.Windows.Forms.Label();
            this.Ticket = new System.Windows.Forms.Button();
            this.Venta = new System.Windows.Forms.Button();
            this.rtbListaChanguito = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDataTable
            // 
            this.dataGridViewDataTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDataTable.Location = new System.Drawing.Point(489, 1);
            this.dataGridViewDataTable.MultiSelect = false;
            this.dataGridViewDataTable.Name = "dataGridViewDataTable";
            this.dataGridViewDataTable.Size = new System.Drawing.Size(409, 501);
            this.dataGridViewDataTable.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.BackColor = System.Drawing.Color.MistyRose;
            this.labelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelTitulo.Location = new System.Drawing.Point(7, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(471, 36);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Zapateria";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // botonEliminar
            // 
            this.botonEliminar.BackColor = System.Drawing.Color.Red;
            this.botonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botonEliminar.Location = new System.Drawing.Point(314, 28);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(126, 39);
            this.botonEliminar.TabIndex = 2;
            this.botonEliminar.Text = "Eliminar Producto";
            this.botonEliminar.UseVisualStyleBackColor = false;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // Modificar
            // 
            this.Modificar.BackColor = System.Drawing.Color.Gold;
            this.Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Modificar.Location = new System.Drawing.Point(170, 28);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(126, 39);
            this.Modificar.TabIndex = 3;
            this.Modificar.Text = "Modificar Producto";
            this.Modificar.UseVisualStyleBackColor = false;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.Color.YellowGreen;
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Agregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Agregar.Location = new System.Drawing.Point(26, 28);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(126, 39);
            this.Agregar.TabIndex = 4;
            this.Agregar.Text = "Agregar Producto";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonEliminar);
            this.groupBox1.Controls.Add(this.Modificar);
            this.groupBox1.Controls.Add(this.Agregar);
            this.groupBox1.Location = new System.Drawing.Point(12, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock Zapateria";
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.Red;
            this.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.Salir.Location = new System.Drawing.Point(276, 459);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(201, 32);
            this.Salir.TabIndex = 6;
            this.Salir.Text = "SALIR";
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // GuardarCambios
            // 
            this.GuardarCambios.BackColor = System.Drawing.Color.YellowGreen;
            this.GuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GuardarCambios.Location = new System.Drawing.Point(12, 459);
            this.GuardarCambios.Name = "GuardarCambios";
            this.GuardarCambios.Size = new System.Drawing.Size(212, 32);
            this.GuardarCambios.TabIndex = 7;
            this.GuardarCambios.Text = "Guardar zapateria XML";
            this.GuardarCambios.UseVisualStyleBackColor = false;
            this.GuardarCambios.Click += new System.EventHandler(this.GuardarCambios_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.CancelarCompra);
            this.groupBox2.Controls.Add(this.AñadirAlCarro);
            this.groupBox2.Controls.Add(this.labelVentas);
            this.groupBox2.Controls.Add(this.labelGanancias);
            this.groupBox2.Controls.Add(this.Ticket);
            this.groupBox2.Controls.Add(this.Venta);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox2.Location = new System.Drawing.Point(12, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 113);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ventas";
            // 
            // CancelarCompra
            // 
            this.CancelarCompra.BackColor = System.Drawing.Color.LightPink;
            this.CancelarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelarCompra.Location = new System.Drawing.Point(6, 80);
            this.CancelarCompra.Name = "CancelarCompra";
            this.CancelarCompra.Size = new System.Drawing.Size(96, 27);
            this.CancelarCompra.TabIndex = 5;
            this.CancelarCompra.Text = "Cancelar compra";
            this.CancelarCompra.UseVisualStyleBackColor = false;
            this.CancelarCompra.Click += new System.EventHandler(this.CancelarCompra_Click);
            // 
            // AñadirAlCarro
            // 
            this.AñadirAlCarro.BackColor = System.Drawing.Color.LightPink;
            this.AñadirAlCarro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AñadirAlCarro.Location = new System.Drawing.Point(6, 50);
            this.AñadirAlCarro.Name = "AñadirAlCarro";
            this.AñadirAlCarro.Size = new System.Drawing.Size(96, 27);
            this.AñadirAlCarro.TabIndex = 4;
            this.AñadirAlCarro.Text = "Añadir al carro";
            this.AñadirAlCarro.UseVisualStyleBackColor = false;
            this.AñadirAlCarro.Click += new System.EventHandler(this.AñadirAlCarro_Click);
            // 
            // labelVentas
            // 
            this.labelVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVentas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVentas.Location = new System.Drawing.Point(223, 19);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(242, 38);
            this.labelVentas.TabIndex = 3;
            this.labelVentas.Text = "Ventas del dia:";
            // 
            // labelGanancias
            // 
            this.labelGanancias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGanancias.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelGanancias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelGanancias.Location = new System.Drawing.Point(223, 69);
            this.labelGanancias.Name = "labelGanancias";
            this.labelGanancias.Size = new System.Drawing.Size(243, 38);
            this.labelGanancias.TabIndex = 2;
            this.labelGanancias.Text = "Ganancia Del Dia:";
            // 
            // Ticket
            // 
            this.Ticket.BackColor = System.Drawing.Color.Pink;
            this.Ticket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Ticket.Location = new System.Drawing.Point(116, 19);
            this.Ticket.Name = "Ticket";
            this.Ticket.Size = new System.Drawing.Size(96, 88);
            this.Ticket.TabIndex = 1;
            this.Ticket.Text = "Mostrar los registros de ventas";
            this.Ticket.UseVisualStyleBackColor = false;
            this.Ticket.Click += new System.EventHandler(this.Ticket_Click);
            // 
            // Venta
            // 
            this.Venta.BackColor = System.Drawing.Color.LightPink;
            this.Venta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Venta.Location = new System.Drawing.Point(6, 19);
            this.Venta.Name = "Venta";
            this.Venta.Size = new System.Drawing.Size(96, 27);
            this.Venta.TabIndex = 0;
            this.Venta.Text = "Realizar venta";
            this.Venta.UseVisualStyleBackColor = false;
            this.Venta.Click += new System.EventHandler(this.Venta_Click);
            // 
            // rtbListaChanguito
            // 
            this.rtbListaChanguito.Location = new System.Drawing.Point(18, 64);
            this.rtbListaChanguito.Name = "rtbListaChanguito";
            this.rtbListaChanguito.ReadOnly = true;
            this.rtbListaChanguito.Size = new System.Drawing.Size(444, 172);
            this.rtbListaChanguito.TabIndex = 9;
            this.rtbListaChanguito.Text = "";
            // 
            // FormularioPrincipalZapateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(900, 505);
            this.Controls.Add(this.rtbListaChanguito);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GuardarCambios);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dataGridViewDataTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormularioPrincipalZapateria";
            this.Text = "Ventas zapateria | TP4 Ybarrola Cecilia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentasZapateria_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDataTable;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Venta;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Button GuardarCambios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelGanancias;
        private System.Windows.Forms.Button Ticket;
        private System.Windows.Forms.Label labelVentas;
        private System.Windows.Forms.Button AñadirAlCarro;
        private System.Windows.Forms.RichTextBox rtbListaChanguito;
        private System.Windows.Forms.Button CancelarCompra;
    }
}

