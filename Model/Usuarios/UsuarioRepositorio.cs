using loginValido.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;
using loginValido.Model.Usuarios;
using MySql.Data.MySqlClient;

namespace loginValido.Model.Usuarios
{

    public class UsuarioRepositorio
    {

        private readonly DatabaseService _dbService;

        public UsuarioRepositorio()
        {
            _dbService = new DatabaseService();
        }
        public static class Criptografia
        {
            public static string GerarHash(string senha)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                    StringBuilder builder = new StringBuilder();
                    foreach (var b in bytes)
                        builder.Append(b.ToString("x2"));
                    return builder.ToString();
                }
            }
        }
        public bool UsuarioExiste(string email)
        {
            using (MySqlConnection conn = _dbService.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void RegistrarUsuario(string nome, string email, string senha)
        {
            if (UsuarioExiste(email))
            {
                MessageBox.Show("Usuário já registrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string senhaHash = Criptografia.GerarHash(senha);

            using (MySqlConnection conn = _dbService.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO usuarios (nome, email, senha_hash, status) VALUES (@Nome, @Email, @SenhaHash, true)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Usuário registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool FazerLogin(string email, string senha)
        {
            string senhaHash = UsuarioRepositorio.Criptografia.GerarHash(senha);

            using (MySqlConnection conn = _dbService.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM usuarios WHERE email = @Email AND senha_hash = @SenhaHash";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Aqui pode usar o método UserFromDataReader
                            usuarios usuario = usuarios.UserFromDataReader(reader);
                            return usuario.status; // ou usuario.ativo
                        }
                    }
                }
            }

            return false;
        }
    }
}
