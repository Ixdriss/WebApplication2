using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebApplication2.Models
{
    public class ProductoImplementacion
    {
        private MySqlConnection con;

        private void Conectar()
        {
            con = new MySqlConnection();
            con.ConnectionString = "server=localhost;database=tp_ti; user id= root; password=Arieljose10;port=3306";

        }
        public int Alta(Producto prod)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand("insert into Producto(id_Producto,nombreProducto,precioProducto,categoriaProducto) values (@id_Producto,@nombreProducto,@precioProducto,@categoriaProducto)", con);
            comando.Parameters.Add("@id_Producto", MySqlDbType.Int16);
            comando.Parameters.Add("@nombreProducto", MySqlDbType.VarChar);
            comando.Parameters.Add("@precioProducto", MySqlDbType.Float);
            comando.Parameters.Add("@categoriaProducto", MySqlDbType.VarChar);
            comando.Parameters["@id_Producto"].Value = prod.id_Producto;
            comando.Parameters["@nombreProducto"].Value = prod.nombreProducto;
            comando.Parameters["@precioProducto"].Value = prod.precioProducto;
            comando.Parameters["@categoriaProducto"].Value = prod.categoriaProducto;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Producto> RecuperarTodos()
        {
            Conectar();
            List<Producto> productos = new List<Producto>();

            MySqlCommand com = new MySqlCommand("select id_Producto,nombreProducto,precioProducto,categoriaProducto from Producto", con);
            con.Open();
            MySqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Producto prod = new Producto
                {
                    id_Producto = int.Parse(registros["id_Producto"].ToString()),
                    nombreProducto = registros["nombreProducto"].ToString(),
                    precioProducto = double.Parse(registros["precioProducto"].ToString()),
                    categoriaProducto = registros["categoriaProducto"].ToString()
                };
                productos.Add(prod);
            }
            con.Close();
            return productos;
        }
        public Producto Recuperar(int codigo)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand("select id_Producto,nombreProducto,precioProducto,categoriaProducto from Producto where id_Producto=@codigo", con);
            comando.Parameters.Add("@codigo", MySqlDbType.Int16);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            MySqlDataReader registros = comando.ExecuteReader();
            Producto producto = new Producto();
            if (registros.Read())
            {
                producto.id_Producto = int.Parse(registros["id_Producto"].ToString());
                producto.nombreProducto = registros["nombreProducto"].ToString();
                producto.precioProducto = double.Parse(registros["precioProducto"].ToString());
                producto.categoriaProducto = registros["categoriaProducto"].ToString();
            }
            con.Close();
            return producto;
        }
        public int Modificar(Producto prod)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand("update producto set nombreProducto=@nombreProducto,precioProducto=@precioProducto,categoriaProducto=@categoriaProducto where id_Producto=@id_Producto", con);
            comando.Parameters.Add("@nombreProducto", MySqlDbType.VarChar);
            comando.Parameters["@nombreProducto"].Value = prod.nombreProducto;
            comando.Parameters.Add("@precioProducto", MySqlDbType.Float);
            comando.Parameters["@precioProducto"].Value = prod.precioProducto;
            comando.Parameters.Add("@categoriaProducto", MySqlDbType.String);
            comando.Parameters["@categoriaProducto"].Value = prod.categoriaProducto;
            comando.Parameters.Add("@id_Producto", MySqlDbType.Int16);
            comando.Parameters["@id_Producto"].Value = prod.id_Producto;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int codigo)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand("delete from producto where id_Producto=@codigo", con);
            comando.Parameters.Add("@codigo", MySqlDbType.Int16);
            comando.Parameters["@codigo"].Value = codigo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}