using System.Data.SqlClient;
using System.Data;

namespace DLLStorageSQL
{
    public class StorageSQL
    {
        public List<Datos> ListadeCliente;
        public bool Almacenar(string Nombre, string Domicilio, string Correo,
            int Edad, double Saldo)
        {
            var connect = new SqlConnection
                ("Server=HUAWEIENRIQUE; Initial Catalog=Informacion; User Id=sa; Password=Mexico2023");
            var query = new SqlCommand("EXEC Insertar '" + Nombre + "','" + Domicilio
                + "','" + Correo + "','" + Edad + "','" + Saldo + "'", connect);
            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception ex)
            {
                connect.Close();
                return false;
            }
        }
        public List<Datos> ConsultarTodo()
        {
            var dt = new DataTable();
            var connect = new SqlConnection
                ("Server=HUAWEIENRIQUE; Initial Catalog=Informacion; User Id=sa; Password=Mexico2023");
            var cmd = new SqlCommand("EXEC ConsultarTodo", connect);
            try
            {
                ListadeCliente = new List<Datos>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Datos cliente = new Datos();
                    cliente.ID = int.Parse((dt.Rows[i]["ID"]).ToString());
                    cliente.Nombre = ((dt.Rows[i]["Nombre"]).ToString());
                    cliente.Domicilio = ((dt.Rows[i]["Domicilio"]).ToString());
                    cliente.Correo = ((dt.Rows[i]["Correo"]).ToString());
                    cliente.Edad = int.Parse((dt.Rows[i]["Edad"]).ToString());
                    cliente.Saldo = double.Parse((dt.Rows[i]["Saldo"]).ToString());
                    ListadeCliente.Add(cliente);
                }
                return ListadeCliente;
            }
            catch (Exception ex)
            {
                connect.Close();
                return ListadeCliente;
            }
        }
        public List<Datos> ConsultarRegistro(int ID)
        {
            var dt = new DataTable();
            var connect = new SqlConnection
                ("Server=HUAWEIENRIQUE; Initial Catalog=Informacion; User Id=sa; Password=Mexico2023");
            var cmd = new SqlCommand("EXEC ConsultarRegistro '" + ID + "'", connect);
            try
            {
                ListadeCliente = new List<Datos>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Datos cliente = new Datos();
                    cliente.ID = int.Parse((dt.Rows[i]["ID"]).ToString());
                    cliente.Nombre = ((dt.Rows[i]["Nombre"]).ToString());
                    cliente.Domicilio = ((dt.Rows[i]["Domicilio"]).ToString());
                    cliente.Correo = ((dt.Rows[i]["Correo"]).ToString());
                    cliente.Edad = int.Parse((dt.Rows[i]["Edad"]).ToString());
                    cliente.Saldo = double.Parse((dt.Rows[i]["Saldo"]).ToString());
                    ListadeCliente.Add(cliente);
                }
                return ListadeCliente;
            }
            catch (Exception ex)
            {
                connect.Close();
                return ListadeCliente;
            }

        }
    }
}