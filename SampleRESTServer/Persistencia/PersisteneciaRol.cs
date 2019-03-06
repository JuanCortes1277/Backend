using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using SampleRESTServer.Models;

namespace SampleRESTServer.Persistencia
{
    public class PersisteneciaRol
    {


        

        public int GuardarRolSinTareas(string rol, string descipcion)
        {
            int idmax=0;
            int idexiste = RetornoIdRol(rol);
            if (idexiste == 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                    builder.DataSource = "azuevbsqc01q.database.windows.net";
                    builder.UserID = "_Soportedb";
                    builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                    builder.InitialCatalog = "Portal_Digital";

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        //  SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);


                        StringBuilder sb = new StringBuilder();
                        sb.Append("insert into Portal_Digital.Administrator.Rol (Rol,DescripctionRol)");
                        sb.Append(" VALUES" + " ('" + rol + "', '" + descipcion + "');SELECT CAST(scope_identity() AS int)");



                        String sql = sb.ToString();

                        try
                        {

                            using (SqlCommand cmd = new SqlCommand(sql, connection))
                            {

                                int modified = Convert.ToInt32(cmd.ExecuteScalar());

                                idmax = modified;


                            }

                        }
                        catch (Exception ex)
                        {
                            ex.ToString();

                        }


                        connection.Close();


                    }
                 

                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
                return idmax;
            }



            return 0;


        }
           
            
        public int RetornoIdRol(string NombreRol)
        {


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT IDRol  from Portal_Digital.Administrator.Rol where Rol= " + "'" + NombreRol + "'; ";

            using (SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(strCommand, sqlConnection))
                {

                    SqlDataReader sqlReader = sqlcommand.ExecuteReader();
                    //

                    //
                    if (sqlReader.Read())
                        PatientCount = sqlReader.GetInt32(0);
                }
                sqlConnection.Close();
            }
            return PatientCount;

        }
        public void borrarTareasPorROl(int IDROL)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "azuevbsqc01q.database.windows.net";
                builder.UserID = "_Soportedb";
                builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                builder.InitialCatalog = "Portal_Digital";



                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    // SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);


                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete from Administrator.rol_tarea");
                    sb.Append(" where FKROL= " + IDROL + ";");


                    String sql = sb.ToString();
                    string sql1 = sql;

                    try
                    {

                        adapter.InsertCommand = new SqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();

                    }

                    // tr.Commit();
                    connection.Close();


                }
            }
            catch (SqlException e)
            {
                e.ToString();
            }



        }
        public void llenarTareaROl(int IDROL, int IDTAREA)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "azuevbsqc01q.database.windows.net";
                builder.UserID = "_Soportedb";
                builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                builder.InitialCatalog = "Portal_Digital";



                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    // SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);


                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into Administrator.Rol_Tarea (FKROL,FKIDtarea) values");
                    sb.Append("(" + IDROL + ", " + IDTAREA+");");


                    String sql = sb.ToString();
                    string sql1 = sql;

                    try
                    {

                        adapter.InsertCommand = new SqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();

                    }

                    // tr.Commit();
                    connection.Close();


                }
            }
            catch (SqlException e)
            {
                e.ToString();
            }



        }



        public int GuardarRolConTareas(Rol mirol)
        {
            string rol;
            string descripcion;
            rol = mirol.NombreROl;
            descripcion = mirol.DescripcionRol;
            List<int> mistareas = new List<int>();
            mistareas = mirol.tareas;
            int idmax = 0;
            int IDR = RetornoIdRol(rol);
           
            if (IDR == 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                    builder.DataSource = "azuevbsqc01q.database.windows.net";
                    builder.UserID = "_Soportedb";
                    builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                    builder.InitialCatalog = "Portal_Digital";

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        //  SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);


                        StringBuilder sb = new StringBuilder();
                        sb.Append("insert into Portal_Digital.Administrator.Rol (Rol,DescripctionRol)");
                        sb.Append(" VALUES" + " ('" + rol + "', '" + descripcion + "');SELECT CAST(scope_identity() AS int)");



                        String sql = sb.ToString();
                        string sql1 = sql;

                        try
                        {

                            using (SqlCommand cmd = new SqlCommand(sql, connection))
                            {

                                int modified = Convert.ToInt32(cmd.ExecuteScalar());

                                idmax = modified;


                            }

                        }
                        catch (Exception ex)
                        {
                            ex.ToString();

                        }


                        connection.Close();


                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();

                }
             
                for (int i =0; i < mistareas.Count; i++)
                {
                    llenarTareaROl(idmax, mistareas.ElementAt(i));
                }

                return idmax;
            }
            else
            {
                if (IDR != 0)
                {
                    List <int>list=new List<int>( mistareas);
                    idmax = RetornoIdRol(rol);
                   
                        borrarTareasPorROl(IDR);
                    
                    for (int i = 0; i < mistareas.Count; i++)
                    {
                        llenarTareaROl(IDR, mistareas.ElementAt(i));
                    }
                   
                }
                return idmax;

            }

           
          
        }
    }
} 