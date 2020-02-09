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
    public class KategorijaRepo : IKategorijaRepo
    {
        string cs = ConfigurationManager.ConnectionStrings["OdecaDbContext"].ToString();

        public List<Kategorija> GetAll()
        {
            string query = "select * from Kategorija";
            List<Kategorija> kategorije = new List<Kategorija>();
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
                        Kategorija kategorija = new Kategorija
                        {
                            Id = (int)row["KategorijaId"],
                            Naziv = (string)row["KategorijaNaziv"]
                        };

                        kategorije.Add(kategorija);
                    }
               }               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return kategorije;
        }

    }
}