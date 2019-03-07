using System;
using System.Collections.Generic;
using System.Linq;
using SampleRESTServer.Models;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace SampleRESTServer.Persistencia
{
    public class PersistenciaRol_Tarea
    {

        public void isertarRol_Tarea(Roles_Tareas mitarea)
        {
          // if (verificaexistenciatarea(mitarea.) == false)
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    int TecnicoR = 0;
                    int adminR = 0;
                    int visR = 0;
                    builder.DataSource = "azuevbsqc01q.database.windows.net";
                    builder.UserID = "_Soportedb";
                    builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                    builder.InitialCatalog = "Portal_Digital";
                    
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        // SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);


                        StringBuilder sb = new StringBuilder();
                        sb.Append("insert into Portal_Digital.Administrator.Roles_Tareas(,Administrator_Rol,Visualizator_Rol,Tecnico_Rol)");
                        sb.Append(" VALUES" + " (" + ", " + adminR + ", " + visR + ", " + TecnicoR + ");");


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


        }






        public bool verificaexistenciatarea(string tarea)
        {

            int id = 0;


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            int ContarTareas = 0;
            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT count(PKRoles_Tareas)  from Portal_Digital.Administrator.Roles_Tareas where Tarea = '" + tarea + "';";
            using (SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(strCommand, sqlConnection))
                {

                    SqlDataReader sqlReader = sqlcommand.ExecuteReader();
                    if (sqlReader.Read())
                        ContarTareas = sqlReader.GetInt32(0);
                    int local = ContarTareas;
                }
                sqlConnection.Close();
            }
            if (ContarTareas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }



        }


    }






}