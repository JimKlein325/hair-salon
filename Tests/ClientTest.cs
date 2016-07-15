using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameNameStylistIDAndIDForClient()
    {
      //Arrange, Act
      Client firstClient = new Client("Wilma", 1, 1);
      Client secondClient = new Client("Wilma", 1, 1);
      //Assert
      Assert.Equal(firstClient,secondClient);
    }
    [Fact]
    public void Test_GetAll_ReturnsEmptyListIfDBContainsNoRows()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0,result);
    }
    [Fact]
    public void Test_Save_SavesClientToDB()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 1, 1);
      firstClient.Save();
      List<Client> testList = new List<Client> {firstClient};

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_GetAll_ReturnsCorrectClientRow()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 1);
      firstClient.Save();
      List<Client> testList = new List<Client> {firstClient};

      //Act
      List<Client> result = Client.GetAll();

      //Console.WriteLine(testList[0].GetId().ToString() + "  "+ result[0].GetId().ToString());
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_DeleteAll_DeletesClientsFromDB()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 1, 1);
      Client secondClient = new Client("Fred", 2, 2);
      firstClient.Save();
      secondClient.Save();
      //Act
      Client.DeleteAll();
      int result = Client.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Find_ForClientIDReturnsClientFromDB()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 1, 1);
      Client secondClient = new Client("Fred", 2, 2);
      firstClient.Save();
      secondClient.Save();
      //Act
      Client result = Client.Find(firstClient.GetId());
      //Assert
      Assert.Equal(firstClient, result);
    }
    [Fact]
    public void Test_Delete_DeletesClientFromDB()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 1, 1);
      Client secondClient = new Client("Fred", 2, 2);
      firstClient.Save();
      secondClient.Save();
      //Act
      secondClient.Delete();
      List<Client> testList = new List<Client> {firstClient};
      List<Client> result = Client.GetAll();
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Update_UpdatesClientName()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 5);
      firstClient.Save();
      string newName = "Betty";

      //Act
      firstClient.Update(newName, 5);
      string clientUpdatedName = Client.Find(firstClient.GetId()).GetName();

      //Assert
      Assert.Equal(newName, clientUpdatedName);
    }
    public void Test_Update_UpdatesClientStylistID()
    {
      //Arrange
      Client firstClient = new Client("Wilma", 5);
      firstClient.Save();
      int newStylistID = 99;

      //Act
      firstClient.Update("Wilma", newStylistID);
      int updatedStylistID = Client.Find(firstClient.GetId()).GetStylistId();

      //Assert
      Assert.Equal(newStylistID, updatedStylistID);
    }




    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
