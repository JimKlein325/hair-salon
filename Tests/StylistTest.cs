using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameNameAndIDForStylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Wilma", 1);
      Stylist secondStylist = new Stylist("Wilma", 1);
      //Assert
      Assert.Equal(firstStylist,secondStylist);
    }
    [Fact]
    public void Test_Equal_ReturnsFalseForDifferentNameAndIDForStylist()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Wilma", 1);
      Stylist secondStylist = new Stylist("Bill", 99);
      // Act
      bool result = firstStylist.Equals(secondStylist);
      //Assert
      Assert.False(result);
    }
    [Fact]
    public void Test_GetAll_ReturnsEmptyListIfDBContainsNoRows()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;
      //Assert
      Assert.Equal(0,result);
    }
    [Fact]
    public void Test_Save_SavesStylistToDB()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Wilma");

      //Act
      firstStylist.Save();
      List<Stylist> testList = new List<Stylist> {firstStylist};
      List<Stylist> result = Stylist.GetAll();
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_DeleteAll_DeletesStylistsFromDB()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Wilma");
      Stylist secondStylist = new Stylist("Fred");
      firstStylist.Save();
      secondStylist.Save();
      //Act
      Stylist.DeleteAll();
      int result = Stylist.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Find_ForStylistIDReturnsStylistFromDB()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Wilma");
      Stylist secondStylist = new Stylist("Fred");
      firstStylist.Save();
      secondStylist.Save();
      //Act
      Stylist result = Stylist.Find(firstStylist.GetId());
      //Assert
      Assert.Equal(firstStylist, result);
    }
    [Fact]
    public void Test_Delete_DeletesStylistFromDB()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Wilma");
      Stylist secondStylist = new Stylist("Fred");
      firstStylist.Save();
      secondStylist.Save();
      //Act
      secondStylist.Delete();
      List<Stylist> testList = new List<Stylist> {firstStylist};
      List<Stylist> result = Stylist.GetAll();
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Update_UpdatesStylistName()
    {
      //Arrange
      Stylist firstStylist = new Stylist("Wilma");
      firstStylist.Save();
      string newName = "Betty";

      //Act
      firstStylist.Update(newName);
      string stylistUpdatedName = Stylist.Find(firstStylist.GetId()).GetName();

      //Assert
      Assert.Equal(newName, stylistUpdatedName);
    }
    [Fact]
    public void Test_GetClients_ReturnsCorrectClientRowForStylist()
    {
      //Arrange
      Stylist stylist = new Stylist("Monique");
      stylist.Save();
      Client firstClient = new Client("Wilma", stylist.GetId() );
      firstClient.Save();
      List<Client> testList = new List<Client> {firstClient};
      //Act
      List<Client> result = Stylist.GetClients(stylist.GetId());
      Console.WriteLine("resultID:" + result[0].GetId());
      Console.WriteLine("Clietns ID:" + firstClient.GetId());
      //Assert
      Assert.Equal(testList, result);
    }


    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
