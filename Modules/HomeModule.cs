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
        Console.WriteLine("param: " + paramaters.id + " Stylist.id: " + stylist.GetId());
        stylist.Delete();
        return View["index.cshtml", Stylist.GetAll()];
      };

    }
  }
}
