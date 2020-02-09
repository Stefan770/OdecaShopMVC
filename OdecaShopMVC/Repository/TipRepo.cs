using OdecaShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OdecaShopMVC.Repository
{
    public class TipRepo : ITipRepo
    {
        string cs = ConfigurationManager.ConnectionStrings["OdecaDbContext"].ToString();

        public List<Tip> GetAll()
        {
            string query = "select * from Tip";
            List<Tip> tipovi = new List<Tip>();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        SqlDataAdapter adapter = new SqlDataAdapter
                        {
                            SelectCommand = cmd
                        };

                        adapter.Fill(dt);
                        conn.Close();
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        Tip Tip = new Tip
                        {
                            Id = (int)row["TipId"],
                            Naziv = (string)row["TipNaziv"]
                        };

                        tipovi.Add(Tip);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return tipovi;
        }
    }
}