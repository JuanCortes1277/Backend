using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using SampleRESTServer.Models;


namespace SampleRESTServer.Persistencia
{
    public class PersistenciaIndicador
    {
        public void ingresarIndicador(Indicador miIndicador)
        {

            /*
             * 
        public String Nombre { get; set; }
        public String Unidad_Medida { get; set; }
        public float peso { get; set; }
        public String frecuencia { get; set; }
        public float Limite_Inferior { get; set; }
        public float Li { get; set; }
        public float Meta { get; set; }
        public float Ls { get; set; }
        public float Limite_Superior { get; set; }
             * */

            string Nombre = miIndicador.Nombre;
            string Unidad_Medida = miIndicador.Unidad_Medida;
            float peso = miIndicador.peso;
            string frecuencia = miIndicador.frecuencia;
            float Limite_Inferior = miIndicador.Limite_Inferior;
            float Li = miIndicador.Li;
            float Meta = miIndicador.Meta;
            float ls = miIndicador.Ls;
            float Limite_superior = miIndicador.Limite_Superior;


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
                    sb.Append("insert into Portal_Digital.Administrator.Indicador_Portal_Digital (Nombre,Unidad_Medida,peso,Frecuencia,Limite_Inferior" +
                        "LI,Meta,L_S,Limite_Superior");
                    sb.Append(" VALUES" + " ('" + Nombre + "', '" + Unidad_Medida + "', '"+peso+"', ");");



                    String sql = sb.ToString();

                    try
                    {

                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {

                            int modified = Convert.ToInt32(cmd.ExecuteNonQuery());



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




    }
}