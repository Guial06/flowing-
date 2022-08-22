using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace flowing.Data
{
    public class Datipazienti
    {
            public static bool REGISTRO(PAZIENTI pAZIENTI)
            {
                using (SqlConnection sqlConnection = new SqlConnection(Connection.connectionroute))
                {
                    SqlCommand cmd = new SqlCommand("usp_registrare", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Documentodidentità", pAZIENTI.Documentodidentità);
                    cmd.Parameters.AddWithValue("@Nome", pAZIENTI.Nome);
                    cmd.Parameters.AddWithValue("@Cognome", pAZIENTI.Cognome);
                    cmd.Parameters.AddWithValue("@Telefono", pAZIENTI.Telefono);
                    cmd.Parameters.AddWithValue("@Città", pAZIENTI.Città);

                    try
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

        public static bool MODIFICA (PAZIENTI pAZIENTI)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Connection.connectionroute))
            {
                SqlCommand cmd = new SqlCommand("usp_registrare", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documentodidentità", pAZIENTI.Documentodidentità);
                cmd.Parameters.AddWithValue("@Nome", pAZIENTI.Nome);
                cmd.Parameters.AddWithValue("@Cognome", pAZIENTI.Cognome);
                cmd.Parameters.AddWithValue("@Telefono", pAZIENTI.Telefono);
                cmd.Parameters.AddWithValue("@Città", pAZIENTI.Città);

                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<PAZIENTI> ELENCARE()
        {
            List<PAZIENTI> lISTPAZIENTI = new List<PAZIENTI>();
            using (SqlConnection sqlConnection = new SqlConnection(Connection.connectionroute))
            {
                SqlCommand cmd = new SqlCommand("usp_Elencare", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            lISTPAZIENTI.Add(new PAZIENTI()
                            {
                               IDPazienti = Convert.ToInt32(dr["IDPaziente"]),
                               Documentodidentità = dr["Documentodidentità"].ToString(),
                               Nome = dr["Nome"].ToString(),
                               Cognome = dr["Cognome"].ToString(),
                               Telefono = dr["Telefono"].ToString(),
                               Città = dr["Città"].ToString(),                              
                            });
                        }

                    }



                    return lISTPAZIENTI;
                }
                catch (Exception ex)
                {
                    return lISTPAZIENTI;
                }
            }
        }

        public static PAZIENTI RICEVERE(int IDPaziente)
        {
            PAZIENTI pAZIENTI = new PAZIENTI();
            using (SqlConnection sqlConnection = new SqlConnection(Connection.connectionroute))
            {
                SqlCommand cmd = new SqlCommand("usp_Ricevere", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPaziente", sqlConnection);

                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            pAZIENTI = new PAZIENTI()
                            {
                                IDPazienti = Convert.ToInt32(dr["IDPaziente"]),
                                Documentodidentità = dr["Documentodidentità"].ToString(),
                                Nome = dr["Nome"].ToString(),
                                Cognome = dr["Cognome"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Città = dr["Città"].ToString()                            
                            };
                        }

                    }


                    return pAZIENTI;
                }
                catch (Exception ex)
                {
                    return pAZIENTI;
                }
            }
        }
        public static bool ELIMINARE(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Connection.connectionroute))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPaziente", id);

                try
                {
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}


   
