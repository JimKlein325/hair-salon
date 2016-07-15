using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(string name,  int id = 0)
    {
      _id = id;
      _name = name;
    }

    public override bool Equals(System.Object object)
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
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> stylists =  new List<Cuisine>{};

=      return stylists;
    }

    public void Save()
    {

    }

    public void Update(string name)
    {

    }
    public void Delete()
    {

    }
    public static void DeleteAll()
    {

    }

    public static Stylist Find(int id)
    {
      return new Stylist("Sweeny Todd");
    }

  }
}
