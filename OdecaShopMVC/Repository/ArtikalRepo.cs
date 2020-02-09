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
    public class ArtikalRepo : IArtikalRepo
    {
        string cs = ConfigurationManager.ConnectionStrings["OdecaDbContext"].ToString();

        public List<Artikal> GetAll()
        {
            string query = "select * from Artikal inner join Tip on Artikal.TipId = Tip.TipId inner join Kategorija " +
                "on Artikal.KategorijaId = Kategorija.KategorijaId where ArtikalObrisan=0";
            List<Artikal> artikli = new List<Artikal>();
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
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    Artikal Artikal = new Artikal
                    {
                        Id = (int)row["ArtikalId"],
                        Naziv = (string)row["ArtikalNaziv"],
                        Opis = (string)row["ArtikalOpis"],
                        Marka = (string)row["ArtikalMarka"],
                        Cena = (double)row["ArtikalCena"],
                        Akcija = (bool)row["ArtikalAkcija"],
                        Kategorija = new Kategorija { Id = (int)row["KategorijaId"], Naziv = (string)row["KategorijaNaziv"] },
                        Tip = new Tip { Id = (int)row["TipId"], Naziv = (string)row["TipNaziv"] }
                    };

                    artikli.Add(Artikal);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return artikli;
        }

        public int Create(Artikal artikal)
        {
            string query = "insert into Artikal values(@katId, @tipId, @naziv, @opis, @marka, @cena, @akcija, 0)";
            query += "select RacunId from Racun where RacunId=@@Identity";
            int retVal = -1;
 
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("katId", artikal.Kategorija.Id);
                        cmd.Parameters.AddWithValue("tipId", artikal.Tip.Id);
                        cmd.Parameters.AddWithValue("naziv", artikal.Naziv);
                        cmd.Parameters.AddWithValue("opis", artikal.Opis);
                        cmd.Parameters.AddWithValue("marka", artikal.Marka);
                        cmd.Parameters.AddWithValue("cena", artikal.Cena);
                        cmd.Parameters.AddWithValue("akcija", artikal.Akcija);

                        conn.Open();
                        var id = cmd.ExecuteScalar();

                        if (id != null)
                        {
                            retVal = (int)id;
                        }
                    }
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return retVal;
        }

        public bool DeleteLogical(int id)
        {
            string query = "update Artikal set ArtikalObrisan=1 where ArtikalId=@id";
            bool retVal = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("id", id);
                        conn.Open();

                        int affected = cmd.ExecuteNonQuery();

                        if (affected == 1)
                        {
                            retVal = true;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return retVal;
        } 
    }
}