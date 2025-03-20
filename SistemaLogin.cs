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
    public partial class SistemaLogin : Form
    {
        public SistemaLogin()
        {
            InitializeComponent();
        }

        private void labelSenha_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidacaoLogin validacao = new ValidacaoLogin();
            if (validacao.Validar(textUsuario.Text, textSenha.Text))
            {
                this.Hide();
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
            }
            else{
                lblMensagem.Text = "Usuário ou senha inválidos";
            }
        }
    }
}
