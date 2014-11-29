﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viainternet.OnionArchitecture.Core.Interfaces;
using Viainternet.OnionArchitecture.Core.Services;

namespace Viainternet.OnionArchitecture.Presentation.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private IMovieService _movieService;

        public HomeController(IUnitOfWorkAsync unitOfWorkAsync,
            IMovieService movieService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _movieService = movieService;
        }

        public ActionResult Index()
        {
            ViewBag.Result = _movieService.CustomerOrderTotalByYear();
            return View();
        }
    }
}