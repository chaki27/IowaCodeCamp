﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public class SponsorController : Controller
{
    public ActionResult Index()
    {
        return View("list");
    }

    public ActionResult List()
    {
        return View();
    }
}
