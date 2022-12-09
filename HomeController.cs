using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_Final.Controllers;
using Hotel_Booking_Final.Models;



namespace Hotel_Booking_Final.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.bookTheRoom = " ";
            ViewBag.waiting = "";
            ViewBag.showRooms = " ";
            ViewBag.showOpen = "";
            ViewBag.showPrice = "";
            ViewBag.UserID = 0;


            HotelModel model = new HotelModel();
            clientGuest client = new clientGuest();

            
            ViewBag.showRooms = model.showRoomNumbers();
            ViewBag.showOpen = model.showOpenForBooking();
            ViewBag.showPrice = model.showPrices();
            ViewBag.UserID = client.makeUserID();


            return View();
        }
        
        
        
        [HttpPost]
        public IActionResult Index(Hotel_Booking_Final.Models.HotelModel model)
        {
            clientGuest client = new clientGuest();
            ViewBag.showRooms = model.showRoomNumbers();
            ViewBag.showOpen = model.showOpenForBooking();
            ViewBag.showPrice = model.showPrices();
            ViewBag.UserID = client.makeUserID();

            ViewBag.waiting = model.enterIntoWaitList();
            ViewBag.bookTheRoom = model.enterUserIn();

            return View(model);
        }
        
    }
}
