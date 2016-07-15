using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;

    public Client(string name,  int id = 0)
    {
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
