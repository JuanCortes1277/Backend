using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using SampleRESTServer.Models;
namespace SampleRESTServer.Persistencia
{
    public class PersistenciaTag
    {

        public void ingresarTagAsociarREporte(Tag mitag)
        {

            string tag1 = mitag.tipoTag;
            string descripciontag1 = mitag.DescripcionTag;

            int idmax = 0;
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
                    sb.Append("insert into Portal_Digital.Administrator.Tag (Tipo_Tag,Descripcion)");
                    sb.Append(" VALUES" + " ('" + tag1 + "', '" + descripciontag1 + "');");



                    String sql = sb.ToString();

                    try
                    {

                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            if (VerificaExistag(mitag) != false)
                            {
                                cmd.ExecuteNonQuery();
                            }




                        }

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();

                    }


                    connection.Close();


                }
            }
            catch (SqlException e)
            {
                e.ToString();
            }




        }



        public Tag retornoTag(string NombreTag)
        {
            Tag miTag = new Tag();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "azuevbsqc01q.database.windows.net";
                builder.UserID = "_Soportedb";
                builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                builder.InitialCatalog = "Portal_Digital";

                string sql = "Select * from Portal_Digital.Administrator.Tag where Tipo_Tag= " + "'" + NombreTag + "';";

                SqlConnection connessione = new SqlConnection(builder.ConnectionString);
                connessione.Open();

                SqlCommand cmd = new SqlCommand(sql, connessione);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        miTag.id = dr.GetInt32(0);
                        miTag.tipoTag = dr.GetString(1);
                        miTag.DescripcionTag = dr.GetString(2);



                    }
                }
                dr.Close();
                connessione.Close();



            }
            catch (Exception e)
            {

            }
            return miTag;

        }
        public Boolean VerificaExistag(Tag tag1)
        {

            string tag = tag1.tipoTag;
            int id = 0;


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            int ContarTags = 0;
            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT count(TagID)  from Portal_Digital.Administrator.Tag where Tipo_Tag = '" + tag + "';";
            using (SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(strCommand, sqlConnection))
                {

                    SqlDataReader sqlReader = sqlcommand.ExecuteReader();
                    if (sqlReader.Read())
                        ContarTags = sqlReader.GetInt32(0);
                }
                sqlConnection.Close();
            }
            if (ContarTags == 0)
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