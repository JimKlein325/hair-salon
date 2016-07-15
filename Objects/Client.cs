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
      return false;
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

    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> stylists =  new List<Stylist>{};

      return stylists;
    }
    public static void DeleteAll()
    {

    }
    public static Stylist Find(int id)
    {
      return new Stylist("Sweeny Todd");
    }
    public void Update(string name)
    {

    }
    public void Delete()
    {

    }


  }
}
