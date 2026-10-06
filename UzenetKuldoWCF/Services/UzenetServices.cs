using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UzenetKuldoWCF.DatabaseManager;
using UzenetKuldoWCF.Interfaces;
using UzenetKuldoWCF.Models;

namespace UzenetKuldoWCF.Services
{
    internal class UzenetServices : ICRUD
    {
        #region Read
        public List<Tablazat> Read()
        {
            List<Tablazat> tablazatok = new List<Tablazat>();
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "SELECT * FROM uzenet";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Uzenet uzenet = new Uzenet();
                        uzenet.Id = reader.GetInt32("Id");
                        uzenet.Szoveg = reader.GetString("Szoveg");

                        uzenet.KüldesiIdo = reader.GetDateTime("KuldesIdo");

                        uzenet.UzenetTipus = reader.GetString("UzenetTipus");
                        uzenet.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) ? null : reader.GetString("Telefon");
                        uzenet.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email");

                        tablazatok.Add(uzenet);
                    }
                }
                return tablazatok;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az adatok lekérdezése során:" + ex.Message);
                return tablazatok;
            }
        }
        #endregion

        #region Create
        public string Create(Tablazat tablazat)
        {
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "INSERT INTO uzenet (Szoveg, KuldesIdo, UzenetTipus, Telefon, Email) VALUES (@szoveg, @kuldesIdo, @uzenetTipus, @telefon, @email)";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);

                    cmd.Parameters.AddWithValue("@kuldesIdo", (tablazat as Uzenet).KüldesiIdo);

                    cmd.Parameters.AddWithValue("@uzenetTipus", (tablazat as Uzenet).UzenetTipus);
                    cmd.Parameters.AddWithValue("@telefon", (object)(tablazat as Uzenet).Telefon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)(tablazat as Uzenet).Email ?? DBNull.Value);

                    int eredmeny = cmd.ExecuteNonQuery();
                    if (eredmeny > 0)
                    {
                        return "Sikeres beszúrás!";
                    }
                    else
                    {
                        return "Sikertelen beszúrás";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt a lekérdezés során:" + ex.Message;
            }
        }
        #endregion

        #region Update
        public string Update(Tablazat tablazat)
        {
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "UPDATE uzenet SET Szoveg=@szoveg, KuldesIdo=@kuldesIdo, UzenetTipus=@uzenetTipus, Telefon=@telefon, Email=@email WHERE Id=@id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);

                    cmd.Parameters.AddWithValue("@kuldesIdo", (tablazat as Uzenet).KüldesiIdo);

                    cmd.Parameters.AddWithValue("@uzenetTipus", (tablazat as Uzenet).UzenetTipus);
                    cmd.Parameters.AddWithValue("@telefon", (object)(tablazat as Uzenet).Telefon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)(tablazat as Uzenet).Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", (tablazat as Uzenet).Id);

                    int eredmeny = cmd.ExecuteNonQuery();
                    if (eredmeny > 0)
                    {
                        return "Sikeres módosítás!";
                    }
                    else
                    {
                        return "Sikertelen módosítás";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt a lekérdezés során:" + ex.Message;
            }
        }
        #endregion

        #region Delete
        public string Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "DELETE FROM uzenet WHERE Id=@id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);
                    int eredmeny = cmd.ExecuteNonQuery();
                    if (eredmeny > 0)
                    {
                        return "Sikeres törlés!";
                    }
                    else
                    {
                        return "Sikertelen törlés";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt a lekérdezés során:" + ex.Message;
            }
        }
        #endregion
    }
}
