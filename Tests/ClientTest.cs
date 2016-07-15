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


    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
