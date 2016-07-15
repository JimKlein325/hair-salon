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
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients  WHERE id = @ClientId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@ClientId";
      idParameter.Value = id.ToString();
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();

      string foundClientName = null;
      int foundStylistId = 0;
      int foundId = 0;

      while(rdr.Read())
      {
        foundClientName = rdr.GetString(0);
        foundStylistId = rdr.GetInt32(1);
        foundId = rdr.GetInt32(2);
      }

      Client foundClient = new Client(
      foundClientName,
      foundStylistId,
      foundId
      );

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundClient;
    }
    public void Update(string name, int stylistID)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName,  stylist_id = @StylistID OUTPUT INSERTED.name, INSERTED.stylist_id WHERE id = @Id;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = name;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistID";
      stylistIdParameter.Value = stylistID;
      cmd.Parameters.Add(stylistIdParameter);

      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@Id";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(idParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }

    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @id;", conn);

      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@id";
      clientIdParameter.Value = this.GetId();

      cmd.Parameters.Add(clientIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }

    }


  }
}
