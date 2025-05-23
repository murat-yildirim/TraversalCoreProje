﻿using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class CityController : Controller
	{
		private readonly IDestinationService _destinationService;
		public CityController(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CityList()
		{
			var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
			return Json(jsonCity);
			
		}

		[HttpPost]
		public IActionResult AddCityDestination(Destination destination)
		{
			destination.Status = true;
			_destinationService.TAdd(destination);
			var values = JsonConvert.SerializeObject(destination);
			return Json(values);
		}

		public IActionResult GetById(int DestinationID)
		{
			var values = _destinationService.TGetByID(DestinationID);
			if(values==null)
			{
				
			}
			else
			{
				var jsonValues = JsonConvert.SerializeObject(values);
				return Json(jsonValues);
			}
			return View();
			
		}

		public IActionResult DeleteCity(int id)
		{
			var values = _destinationService.TGetByID(id);
			_destinationService.TDelete(values);
			return NoContent();
		}

		public IActionResult UpdateCity(Destination destination)
		{
			_destinationService.TUpdate(destination);
			var v = JsonConvert.SerializeObject(destination);
			return Json(v);
		}
			


	}
}
