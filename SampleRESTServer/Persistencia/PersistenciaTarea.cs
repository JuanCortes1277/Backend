using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace SampleRESTServer.Persistencia
{
    public class PersistenciaTarea
    {




        public int guardarTarea(string NombreTarea, string DescripcionTarea)
        {



            int idmax = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            int existe = 0;
            existe = RetornoTarea(NombreTarea);
            if (existe == 0)
            {
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
                        sb.Append("insert into Portal_Digital.Administrator.Tarea (TAREA_NOMBRE,TAREA_DESCRIPCION)");
                        sb.Append(" VALUES" + " ('" + NombreTarea + "', '" + DescripcionTarea + "');SELECT CAST(scope_identity() AS int)");



                        String sql = sb.ToString();
                        string sql2 = sql;

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
            else
            {
                return existe;
            }


        }

        public int RetornoTarea(string tarea)
        {


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT ID_TAREA  from Portal_Digital.Administrator.Tarea where TAREA_NOMBRE= " + "'" + tarea + "'; ";

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







    }
}