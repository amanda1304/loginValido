using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginValido
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnPagina1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pagina1 pagina1 = new Pagina1();
            pagina1.Show();
        }

        private void btnPagina2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pagina2 pagina2 = new Pagina2();
            pagina2.Show();
        }
    }
}
