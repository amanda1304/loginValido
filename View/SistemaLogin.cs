
using MySql.Data.MySqlClient;
using loginValido.Model.Usuarios;
using loginValido.Services;
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
       // AuthController authController;
        public SistemaLogin()
        {
            InitializeComponent();
            DatabaseService databaseService = new DatabaseService();
          
            // AuthService authService = new AuthService(databaseService);
            // UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(databaseService);
            // authController = new AuthController(authService, usuarioRepositorio);

        }

        private void labelSenha_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = textUsuario.Text.Trim();
            string senha = textSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioRepositorio usuarioRef = new UsuarioRepositorio();
                bool loginValido = usuarioRef.FazerLogin(email, senha);

                if (loginValido)
                {
                    MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Aqui você pode abrir o próximo form, por exemplo:
                     FormPrincipal formPrincipal = new FormPrincipal();
                     formPrincipal.Show();
                     this.Hide();
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* ValidacaoLogin validacao = new ValidacaoLogin();
             if (validacao.Validar(textUsuario.Text, textSenha.Text))
             {
                 this.Hide();
                 FormPrincipal formPrincipal = new FormPrincipal();
                 formPrincipal.Show();
             }
             else{
                 lblMensagem.Text = "Usuário ou senha inválidos";
             }*/
            /*  Usuario user = authController.Login(textUsuario.Text, textSenha.Text);

              if (user == null)
              {
                  MessageBox.Show("Usuário não encontrado");
                  return;
              }

              MessageBox.Show($"Usuario: {user.nome} \nEmail: {user.email}");
              SessionUsers.Login(user);
              FormPrincipal formPrincipal = new FormPrincipal();
              formPrincipal.ShowDialog();
            */
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            /* Usuario usuario = new Usuario();
             usuario.nome = textBox1.Text;
             usuario.email = textUsuario.Text;

             bool result = authController.Register(usuario, textSenha.Text);

             if (result)
             {
                 MessageBox.Show("Usuario inserido");
             }
             else
             {

                 MessageBox.Show("Usuario não inserido");
             }*/
            string nome = textBox1.Text.Trim();
            string email = textUsuario.Text.Trim();
            string senha = textSenha.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioRepositorio usuarioRep = new UsuarioRepositorio();
                usuarioRep.RegistrarUsuario(nome, email, senha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
