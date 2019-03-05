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
        public int RetornoIdUsuario(string NombreUsuario)
        {
           

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT UsuarioID  from Portal_Digital.Administrator.Usuario_Portal where Username= " + "'" + NombreUsuario + "'; ";

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
        public bool llenar_TablaUsers_Roles_Tareas(String rol, int user)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            List<Roles_Tareas> mistareas=new List<Roles_Tareas>();
            List<int> tareas = new List<int>();
            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";
            try
            {

                if (String.Compare(rol, "Administrador") == 0)
                {

                    string sql = "select PKRoles_Tareas from Portal_Digital.Administrator.Roles_Tareas where Administrator_Rol    = "  +1+ ";";


                    using (SqlConnection sqlconnection = new SqlConnection(builder.ConnectionString))
                    {
                        sqlconnection.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, sqlconnection))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    // Read advances to the next row.
                                    while (reader.Read())
                                    {

                                        int numtarea = 0;
                                        Roles_Tareas mitareaactual = new Roles_Tareas();
                                        numtarea = reader.GetInt32(0);

                                        tareas.Add(numtarea);


                                    }
                                }




                            }




                        }



                        sqlconnection.Close();

                    }
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        InsertAdministratorRoles_Tareas(user, tareas.ElementAt(i));

                    }
                    return true;


                }
                if (String.Compare(rol, "Visualizador") == 0)
                {

                    string sql = "select PKRoles_Tareas from Portal_Digital.Administrator.Roles_Tareas where Visualizator_Rol    = " +1+ ";";


                    using (SqlConnection sqlconnection = new SqlConnection(builder.ConnectionString))
                    {
                        sqlconnection.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, sqlconnection))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    // Read advances to the next row.
                                    while (reader.Read())
                                    {

                                        int numtarea = 0;
                                        Roles_Tareas mitareaactual = new Roles_Tareas();
                                        numtarea = reader.GetInt32(0);

                                        tareas.Add(numtarea);


                                    }
                                }




                            }




                        }



                        sqlconnection.Close();

                    }
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        InsertAdministratorRoles_Tareas(user, tareas.ElementAt(i));

                    }

                    return true;



                }

                if (String.Compare(rol, "Tecnico") == 0)
                {

                    string sql = "select PKRoles_Tareas from Portal_Digital.Administrator.Roles_Tareas where Tecnico_Rol    = " +1+ ";";


                    using (SqlConnection sqlconnection = new SqlConnection(builder.ConnectionString))
                    {
                        sqlconnection.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, sqlconnection))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    // Read advances to the next row.
                                    while (reader.Read())
                                    {

                                        int numtarea = 0;
                                        Roles_Tareas mitareaactual = new Roles_Tareas();
                                        // numtarea = reader.GetInt32(reader.GetOrdinal("PKRoles_Tareas"));
                                        numtarea=reader.GetInt32(0);
                                        tareas.Add(numtarea);


                                    }
                                }




                            }




                        }



                        sqlconnection.Close();

                    }
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        InsertAdministratorRoles_Tareas(user, tareas.ElementAt(i));

                    }


                    return true;


                }



                








            }catch(Exception e)
            {

            }
            return false;
        }
        public void InsertAdministratorRoles_Tareas(int iduser, int idtarea)
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
                    sb.Append("insert into Portal_Digital.Administrator.Users_Roles_Tareas (FKPKRoles_Tareas,FKPKUsuarioID)");
                    sb.Append(" VALUES" + " (" + idtarea + ", " + iduser + ");");


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

        public void GuardarPersona(Person mipersona)
        {/*
             sb.Append("insert into  Portal_Digital.Administrator.Usuario_Portal (Nombre,Rol,Username,Contrasena,Area,Email)");
                        sb.Append(" VALUES" + " ('" + Nombre + "', '" + rol + "', '" + Username + "','" + Contrasena + "', '" + Area + "', '" + Email + "');SELECT CAST(scope_identity() AS int);");
             
             */
            string Nombre=  mipersona.Nombre ;
          string rol=  mipersona.Rol  ;
          string Username=  mipersona.Username ;
          string Contrasena= mipersona.Contrasena ;
          string Area = mipersona.Area  ;
          string Email=mipersona.Email ;
            int idmax = 0;

            SqlDataAdapter adapter = new SqlDataAdapter();
            int valida = RetornoIdUsuario(Username);
            if (valida == 0)
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
                        StringBuilder sb = new StringBuilder();
                        // SqlTransaction tr = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);
                        sb.Append("insert into  Portal_Digital.Administrator.Usuario_Portal (Nombre,Rol,Username,Contrasena,Area,Email)");
                        sb.Append(" VALUES" + " ('" + Nombre + "', '" + rol + "', '" + Username + "','" + Contrasena + "', '" + Area + "', '" + Email + "');SELECT CAST(scope_identity() AS int);");


                   
                       


                        String sql = sb.ToString();
                        string sql1 = sql;
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand(sql1, connection))
                            {

                                int modified = Convert.ToInt32(cmd.ExecuteScalar());

                                idmax = modified;


                            }




                        }
                        catch (Exception ex)
                        {
                            ex.ToString();

                        }

                     //   tr.Commit();
                        connection.Close();


                    }

                    llenar_TablaUsers_Roles_Tareas(mipersona.Rol, idmax);





                }
                catch (SqlException e)
                {
                    e.ToString();
                }
            }
            else
            {
                idmax = valida;
            }

            llenar_TablaUsers_Roles_Tareas(mipersona.Rol, idmax);
           

        }
                

        }



    }



