namespace FormVentasZapateria
{
    partial class FormTicketera
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
            this.rtbListaTickets = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbListaTickets
            // 
            this.rtbListaTickets.Location = new System.Drawing.Point(2, 2);
            this.rtbListaTickets.Name = "rtbListaTickets";
            this.rtbListaTickets.Size = new System.Drawing.Size(304, 358);
            this.rtbListaTickets.TabIndex = 0;
            this.rtbListaTickets.Text = "";
            // 
            // FormTicketera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 361);
            this.Controls.Add(this.rtbListaTickets);
            this.Name = "FormTicketera";
            this.Text = "FormTicketera";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbListaTickets;
    }
}