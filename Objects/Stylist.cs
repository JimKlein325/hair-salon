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

    public override bool Equals(System.Object otherObject)
    {
      if (! (otherObject is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist)otherObject;
        bool idIsEqual = this.GetId() == newStylist.GetId();
        bool nameIsEqual = this.GetName() == newStylist.GetName();
        return (idIsEqual && nameIsEqual);
      }
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
