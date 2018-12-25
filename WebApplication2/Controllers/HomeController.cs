using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;

using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult VehicleList()
        {

            
            List<Vehicle> v = VehicleDataMapper.Select();
            ViewData["VehicleList"] = v;


            return View();
        }

        public IActionResult ShiftList()
        {
            
            List<Shift> v = ShiftDataMapper.Selectmyshiftsthismonth();
            ViewData["ShiftList"] = v;
            ViewBag.Salary = v.Count * 1000;

            return View();
        }

        public IActionResult AddNewVehicle(int vehicleid, int productionyear, string depot, string condition, int vehiclemodelid)
        {
                Vehicle v = new Vehicle(vehicleid, productionyear, depot, condition, vehiclemodelid);
                VehicleDataMapper.Insert(v);

            return View();
        }

        
           
       

    }
}
