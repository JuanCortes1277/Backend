using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using SampleRESTServer.Models;


namespace SampleRESTServer.Persistencia
{
    public class PersistenciaTagReport
    {


        public  List<Relacion_tag_informe> RetornoRelacionados(string relacion)
        {
            List<Relacion_tag_informe> misrelaciones = new List<Relacion_tag_informe>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "azuevbsqc01q.database.windows.net";
                builder.UserID = "_Soportedb";
                builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
                builder.InitialCatalog = "Portal_Digital";

                /*
        * select UnionReporte.ReporteID,UnionReporte.Nombre,UnionReporte.url_reporte,
UnionReporte.Area, UnionReporte.Descripcion,UnionReporte.Tipo,
UnionReporte.Grafica,UnionReporte.PK_RelacionTR,UnionReporte.FK_Relacion_Report,
UnionReporte.FK_Relacion_Tag, ATa.Tipo_Tag,ATa.Descripcion
from
(select * from Portal_Digital.Administrator.Reporte_Portal RP inner join 
Portal_Digital.Administrator.Relacion_Tag_Reporte TR on RP.ReporteID=TR.FK_Relacion_Report)UnionReporte
inner join Portal_Digital.Administrator.Tag ATa on UnionReporte.FK_Relacion_Tag= ATa.TagID
        * */
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    string referencia;
                    referencia = relacion;
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select UnionReporte.ReporteID,UnionReporte.Nombre,UnionReporte.url_reporte, ");
                    sb.Append("UnionReporte.Area, UnionReporte.Descripcion,UnionReporte.Tipo, ");
                    sb.Append("UnionReporte.Grafica,UnionReporte.PK_RelacionTR,UnionReporte.FK_Relacion_Report, ");
                    sb.Append("UnionReporte.FK_Relacion_Tag, ATa.Tipo_Tag,ATa.Descripcion ");
                    sb.Append("from ");
                    sb.Append("(select * from Portal_Digital.Administrator.Reporte_Portal RP inner join  ");
                    sb.Append("Portal_Digital.Administrator.Relacion_Tag_Reporte TR on RP.ReporteID=TR.FK_Relacion_Report)UnionReporte ");
                    sb.Append("inner join Portal_Digital.Administrator.Tag ATa on UnionReporte.FK_Relacion_Tag= ATa.TagID ");
                  



                    sb.Append("where ATa.Tipo_Tag= " + "'" + referencia + "'");
                    sb.Append(" or unionReporte.Nombre LIKE " + "'%" + referencia + "%'" + " ;");

                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Relacion_tag_informe mirelacion = new Relacion_tag_informe();

                                 mirelacion.ID= reader.GetInt32(0);
                                mirelacion.Nombre = reader.GetString(1);
                                mirelacion.Informe_Url = reader.GetString(2);
                                mirelacion.Area= reader.GetString(3);
                                mirelacion.Descripcion= reader.GetString(4);
                                mirelacion.Tipo=reader.GetString(5);
                                mirelacion.Grafica= reader.GetString(6);
                                mirelacion.Tag= reader.GetString(10);
                                mirelacion.DescripcionTag=reader.GetString(11);
                               


                                misrelaciones.Add(mirelacion);
                            }
                        }
                    }
                    connection.Close();

                }
            }
            catch (SqlException e)
            {
                e.ToString();
            }
            return misrelaciones;






        }
        public int verificaExisteReporte(string Url_Report)
        {
            int id = 0;
           

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT ReporteID  from Portal_Digital.Administrator.Reporte_Portal where url_reporte= " + "'" + Url_Report + "'; ";

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
            }
            return PatientCount;

        }
        public Boolean GuardarReporte(Relacion_tag_informe miInforme)
        {

            string url = miInforme.Informe_Url;
            string relacion = miInforme.Relation;
            string nombre = miInforme.Nombre;
            string area = miInforme.Area;
            string descripcion = miInforme.Descripcion;
            string tipo = miInforme.Tipo;
            string grafica = miInforme.Grafica;
           
            //
            List<Tag> tags = new List<Tag> ();
            tags = miInforme.mistags;
            List<string> misdescripciones = new List<string>();
         
            string tag = miInforme.Tag;
            int Identifier;
            SqlDataAdapter adapter = new SqlDataAdapter();
            int idmax = 0;
            //
            int existeReporte = 0;
            bool nohacer = true;
            existeReporte = verificaExisteReporte(url);
           
            Boolean repetido=false;
            if (existeReporte != 0)
            {
                idmax = existeReporte;
                nohacer = false;

            }
            else
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
                        sb.Append("insert into Portal_Digital.Administrator.Reporte_Portal (Nombre,Url_Reporte,Area,Descripcion,Tipo,Grafica)");
                        sb.Append(" VALUES" + " ('" + nombre + "','" + url + "', '" + area + "', '" + descripcion + "', '" + tipo + "', '" + grafica + "');SELECT CAST(scope_identity() AS int);");


                        String sql = sb.ToString();
                        string prove = sql;


                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(sql, connection))
                            {

                                int modified = Convert.ToInt32(cmd.ExecuteScalar());

                                idmax = modified;


                            }


                            //   cmd.ExecuteNonQuery();










                        }
                        catch (Exception ex)
                        {
                            ex.ToString();

                        }


                        connection.Close();





                    }




                   

                   
                  

                    int idintroducida = idmax;



                } catch (SqlException e)
            {
                e.ToString();
            }
                ///////**
            } 
            var valorIdReporte = idmax;
            int ValorIdReporteFInal = valorIdReporte;

            foreach (Tag t in tags)
            {
                repetido = VerificaExistag(t);
                if (repetido == true )
                {
                    int tagexistente = 0;
                    tagexistente = RetornoIDTagSiExiste(t);
                    if (tablaRelacional(tagexistente, idmax) == 0)
                    {
                        GuardaTablaTag_Report(tagexistente, idmax);
                    }
                       
                    //se consulta el tagid
                }

                if (repetido == false  )
                {
                    //se crea
                    int ultimoTag = GuardarTag(t);
                    if(tablaRelacional(ultimoTag,idmax)==0)

                    GuardaTablaTag_Report(ultimoTag, idmax);


                }


            }


            return true;

        }

        public int  tablaRelacional(int IDTAG,int IDREPORT)
        {
            int colocar = 0;
            

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT PK_RelacionTR from Portal_Digital.Administrator.Relacion_Tag_Reporte where FK_Relacion_Report= " +
                 "" + IDREPORT + " and "+"FK_Relacion_Tag= "+""+IDTAG+";";

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




    

        public int RetornoIDTagSiExiste(Tag tag1)
        {
            int id = 0;
            string tag = tag1.tipoTag;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT TagID  from Portal_Digital.Administrator.Tag where Tipo_Tag= "+"'"+ tag+"'; ";
            
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



        public  int RetornoIDReport()
        {
            int id = 0;


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT count(ReporteID)  from Portal_Digital.Administrator.Reporte_Portal;";
            using (SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(strCommand, sqlConnection))
                {

                    SqlDataReader sqlReader = sqlcommand.ExecuteReader();
                    if (sqlReader.Read())
                        PatientCount = sqlReader.GetInt32(0);
                }
                sqlConnection.Close();
            }
            return PatientCount;

        }

        public Boolean GuardaTablaTag_Report(int tag, int report)
        {

            int tag1 = tag;
            int tag2 = tag1;
            int descripciontag1 = report;
            int descripciontag2 = descripciontag1;

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
                    sb.Append("insert into Portal_Digital.Administrator.Relacion_Tag_Reporte (FK_Relacion_Report,FK_Relacion_Tag)");
                    sb.Append(" VALUES" + " (" + descripciontag1 + ", " + tag1 + ");");


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


            return true;

        }




        public  int GuardarTag(Tag mitag)
        {   
          
            string tag1 =mitag.tipoTag;
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
                    sb.Append(" VALUES" + " ('"+tag1+"', '"+descripciontag1+ "');SELECT CAST(scope_identity() AS int)");



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
            catch (SqlException e)
            {
                e.ToString();
            }


            return idmax ;

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
                String strCommand = "SELECT count(TagID)  from Portal_Digital.Administrator.Tag where Tipo_Tag = '"+tag+"';";
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
        public int RetornoUltimoIDTAG()
        {


            int id = 0;


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            int ContarTags = 0;
            builder.DataSource = "azuevbsqc01q.database.windows.net";
            builder.UserID = "_Soportedb";
            builder.Password = "V3nT@$%s3v1Ci0$2@@19*.";
            builder.InitialCatalog = "Portal_Digital";

            int PatientCount = 0;
            String strCommand = "SELECT count(TagID)  from Portal_Digital.Administrator.Tag;";
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

            return ContarTags;


        }











        public Boolean GUardarTag(Person mipersona)
        {
            string Nombre = mipersona.Nombre;
            string rol = mipersona.Rol;
            string Username = mipersona.Username;
            string Contrasena = mipersona.Contrasena;
            string Area = mipersona.Area;
            string Email = mipersona.Email;

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
                    sb.Append("insert into  Portal_Digital.Administrator.Usuario_Portal (Nombre,Rol,Username,Contrasena,Area,Email)");
                    sb.Append(" VALUES" + " ('" + Nombre + "', '" + rol + "', '" + Username + "','" + Contrasena + "', '" + Area + "', '" + Email + "');");


                    String sql = sb.ToString();

                    try
                    {
                        //adapter.InsertCommand = new SqlCommand(sql, connection, tr);
                        adapter.InsertCommand = new SqlCommand(sql, connection);
                        adapter.InsertCommand.ExecuteNonQuery();

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


            return true;

        }



    }
}

    
