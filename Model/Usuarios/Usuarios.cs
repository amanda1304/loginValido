using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace loginValido.Model.Usuarios
{
    internal class usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha_hash { get; set; }
        public bool status { get; set; }

        public static usuarios UserFromDataReader(MySqlDataReader reader)
        {

            return new usuarios
            {
                id = Convert.ToInt32(reader["id_usuario"].ToString()),
                nome = reader["nome"].ToString(),
                email = reader["email"].ToString(),
                senha_hash = reader["senha_hash"].ToString(),
                status = Convert.ToBoolean(reader["status"].ToString()),


            };

        }
    }
}
