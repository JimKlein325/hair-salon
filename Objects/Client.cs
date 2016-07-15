using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private int _stylist_id;
    private string _name;

    public Client(string name, int stylist_id, int id = 0)
    {
      _stylist_id = stylist_id;
      _id = id;
      _name = name;
    }

    public override bool Equals(System.Object otherObject)
    {
      if (! (otherObject is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client)otherObject;
        bool idIsEqual = this.GetId() == newClient.GetId();
        bool stylistIdIsEqual = this.GetStylistId() == newClient.GetStylistId();
        bool nameIsEqual = this.GetName() == newClient.GetName();
        return (idIsEqual && stylistIdIsEqual && nameIsEqual);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylist_id;
    }
    public void SetStylistID(int stylistID)
    {
      _stylist_id = stylistID;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @StylistID);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);

      SqlParameter stylistIDParameter = new SqlParameter();
      stylistIDParameter.ParameterName = "@StylistID";
      stylistIDParameter.Value = this.GetStylistId();
      cmd.Parameters.Add(stylistIDParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

    }
    public static List<Client> GetAll()
    {
      List<Client> stylists =  new List<Client>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        string stylistName = rdr.GetString(0);
        int stylistId = rdr.GetInt32(1);
        int id = rdr.GetInt32(2);
        Client stylist = new Client(stylistName, stylistId, id);
        stylists.Add(stylist);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return stylists;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }
    public static Client Find(int id)
    {
      return new Client("Sweeny Todd", -1, -1);
    }
    public void Update(string name)
    {

    }
    public void Delete()
    {

    }


  }
}
