using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormVentasZapateria
{
    public partial class FormTicketera : Form
    {
        public FormTicketera(string tickets)
        {
            InitializeComponent();
            this.rtbListaTickets.Text = tickets;
        }
    }
}
