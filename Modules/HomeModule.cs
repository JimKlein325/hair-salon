using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using HairSalon.Objects;
using System;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ => {
        List<Stylist> stylists = Stylist.GetAll();
        return View["index.cshtml", stylists];
      };
      Post["/"] = _ => {
        Stylist stylist = new Stylist(Request.Form["stylist-name"]);
        stylist.Save();
        List<Stylist> stylists = Stylist.GetAll();
        return View["index.cshtml", stylists];
      };
      Delete["stylists/delete/{id}"] = paramaters => {
        Stylist stylist = Stylist.Find(paramaters.id);
        stylist.Delete();
        return View["index.cshtml", Stylist.GetAll()];
      };
      Get["stylists/{id}/clients"] = paramaters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(paramaters.id);
        List<Client> allClients = Stylist.GetClients(stylist.GetId());
        model.Add("stylist", stylist);
        model.Add("clients", allClients);
        return View["clients.cshtml", model];
      };
      Get["stylists/edit/{id}"] = paramaters =>
      {
        Stylist stylist =  Stylist.Find(paramaters.id);
        return View["stylist_edit.cshtml", stylist];
      };
      Patch["stylists/edit/{id}"] = paramaters => {
        Stylist stylist = Stylist.Find(paramaters.id);
        stylist.Update(Request.Form["stylist-name"]);
        return View["index.cshtml", Stylist.GetAll()];
      };

      Get["clients/edit/{id}"] = paramaters =>
      {
        Client client =  Client.Find(paramaters.id);
        return View["client_edit.cshtml", client];
      };
      Patch["clients/edit/{id}"] = paramaters => {
        Client client = Client.Find(paramaters.id);
        client.Update(Request.Form["client-name"], client.GetStylistId());

        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(client.GetStylistId());
        List<Client> allClients = Stylist.GetClients(client.GetStylistId());
        model.Add("stylist", stylist);
        model.Add("clients", allClients);
        return View["clients.cshtml", model];
      };

      Post["/clients/new/{id}"] = paramaters => {
        int stylistID = paramaters.id;
        Client client = new Client(Request.Form["client-name"], stylistID);
        client.Save();

        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(stylistID);
        List<Client> allClients = Stylist.GetClients(stylist.GetId());
        model.Add("stylist", stylist);
        model.Add("clients", allClients);
        return View["clients.cshtml", model];
      };
      Delete["clients/delete/{id}"] = parameters => {
        Client client = Client.Find(parameters.id);
        client.Delete();
        int stylistID = client.GetStylistId();
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(stylistID);
        List<Client> allClients = Stylist.GetClients(stylist.GetId());
        model.Add("stylist", stylist);
        model.Add("clients", allClients);
        return View["clients.cshtml", model];
      };
    }
  }
}
