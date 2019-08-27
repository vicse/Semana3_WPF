using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Semana3
{
    class ClsDatos
    {


        public SqlConnection LeerCadena()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5TMV4N9\\SQLEXPRESS;" + "Initial Catalog=Neptuno;Integrated Security=true");
            
            return connection;
        }

        //--------------Ejemplo1-----------------

        public DataTable ListaPedidoFechas(DateTime x, DateTime y)
        {
            using (SqlConnection connection = LeerCadena())
            {
                SqlDataAdapter sqlData = new SqlDataAdapter("USP_FECHAFECHA", connection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@FEC1", x);
                sqlData.SelectCommand.Parameters.AddWithValue("@FEC2", y);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);            
                return dataTable;
            }
                
        }

        public DataTable ListarDetalle(int x)
        {
            using (SqlConnection connection = LeerCadena())
            {
                SqlDataAdapter sqlData = new SqlDataAdapter("USP_DETALLE", connection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", x);              
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                return dataTable;
            }

        }

        public double PedidoTotal(Int32 idpedido)
        {
            using (SqlConnection connection = LeerCadena())
            {
                connection.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter("USP_TOTAL", connection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", idpedido);
                sqlData.SelectCommand.Parameters.Add(
                    "@Total", SqlDbType.Money).Direction =
                    ParameterDirection.Output;
                sqlData.SelectCommand.ExecuteScalar();
                Int32 total = Convert.ToInt32(
                    sqlData.SelectCommand.Parameters["@Total"].Value);

                return total;
            }

        }

        //-----------------Ejemplo3-Caso1--------------

        public SqlDataReader ListaClientes()
        {
            try
            {          
                SqlConnection cn = LeerCadena();
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_ListaClientes_Neptuno_SinFiltro");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;

            }
            catch (Exception)
            {
                throw;
            }
        }


        //-----------------Ejemplo3-Caso2--------------


        public List<Empleado> ListarEmpleado()
        {
            SqlConnection cn = LeerCadena();
            cn.Open();
            List<Empleado> Lista = new List<Empleado>();

            Empleado E;
            SqlDataReader lector;

            try
            {
                SqlCommand cmd = new SqlCommand("Usp_ListaEmpleados");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    E = new Empleado();
                    E.IdEmpleado = (int)(lector[0]);
                    E.Apellido = (string)(lector[1]);
                    E.Nombre = (string)(lector[2]);
                    E.Nacimiento = (DateTime)(lector[3]);
                    E.Direccion = (string)(lector[4]);
                    Lista.Add(E);
                }

            }
            catch(Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return Lista;

        }



    }
}
