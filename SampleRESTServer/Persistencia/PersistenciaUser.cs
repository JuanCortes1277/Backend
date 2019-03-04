using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using SampleRESTServer.Models;
namespace SampleRESTServer.Persistencia
{
    /*
     *  mipersona.id = reader.GetInt32(0);
                                mipersona.Nombre = reader.GetString(1);
                                mipersona.Rol = reader.GetString(2);
                                mipersona.Usuario = reader.GetString(3);
                                mipersona.Password = reader.GetString(4);
                                mipersona.Area = reader.GetString(5);
                                mipersona.Email = reader.GetString(6);
     * */
    public class PersistenciaUser
    {
        public Person RetornoUsuario(string NombreUsuario)
        {
           Person mipersona = new Person();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "azuevbsqc01q.database.windows.net";
                builder.UserID = "_Soportedb";
                builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                builder.InitialCatalog = "Portal_Digital";

                string sql = "Select * from Portal_Digital.Administrator.Usuario_Portal where Username= " + "'" + NombreUsuario + "';" ;  

                SqlConnection connessione = new SqlConnection(builder.ConnectionString);
                connessione.Open();

                SqlCommand cmd = new SqlCommand(sql, connessione);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mipersona.id = dr.GetInt32(0);
                                mipersona.Nombre = dr.GetString(1);
                                mipersona.Rol = dr.GetString(2);
                                mipersona.Username = dr.GetString(3);
                                mipersona.Contrasena = dr.GetString(4);
                                mipersona.Area = dr.GetString(5);
                                mipersona.Email = dr.GetString(6);
                    }
                }
                dr.Close();
                connessione.Close();



            }
            catch(Exception e)
            {

            }
            return mipersona;

        }
        public Boolean GuardarPersona(Person mipersona)
        {
          string Nombre=  mipersona.Nombre ;
          string rol=  mipersona.Rol  ;
          string Username=  mipersona.Username ;
          string Contrasena= mipersona.Contrasena ;
          string Area = mipersona.Area  ;
          string Email=mipersona.Email ;

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
                    SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);


                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into  Portal_Digital.Administrator.Usuario_Portal (Nombre,Rol,Username,Contrasena,Area,Email)");
                    sb.Append(" VALUES" + " ('" + Nombre + "', '" + rol + "', '" +Username+"','"+ Contrasena + "', '" +Area+"', '"+Email+"');");


                    String sql = sb.ToString();

                    try
                    {

                        adapter.InsertCommand = new SqlCommand(sql, connection, tr);
                        adapter.InsertCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();

                    }

                    tr.Commit();
                    connection.Close();


                }
            }
            catch (SqlException e)
            {
                e.ToString();
            }


            return true;

        }



    }


}
