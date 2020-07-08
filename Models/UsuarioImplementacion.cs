using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UsuarioImplementacion
    {
        private MySqlConnection con;
        private void Conectar()
        {

            con = new MySqlConnection
            {
                ConnectionString = "server=localhost;database=tp_ti; user id= root; password=Arieljose10;port=3306"
            };
        }
        public int Alta(Usuario usr)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand("insert into usuario(nombreUsuario,contraseña) values (@nombreUsuario,@contraseña)", con);
            comando.Parameters.Add("@nombreUsuario", MySqlDbType.VarChar);
            comando.Parameters.Add("@contraseña", MySqlDbType.VarChar);
            comando.Parameters["@nombreUsuario"].Value = usr.nombreUsuario;
            comando.Parameters["@contraseña"].Value = usr.contraseña;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public Boolean LogIn(Usuario usr)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand("select * from usuario where nombreUsuario=@nombreUsuario and contraseña=@contraseña", con);
            comando.Parameters.Add("@nombreUsuario", MySqlDbType.VarChar);
            comando.Parameters.Add("@contraseña", MySqlDbType.VarChar);
            comando.Parameters["@nombreUsuario"].Value = usr.nombreUsuario;
            comando.Parameters["@contraseña"].Value = usr.contraseña;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i==1) { return true; }
            return false;
        }
    }
}