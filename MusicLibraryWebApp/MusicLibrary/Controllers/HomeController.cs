using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.SongProcessor;

namespace MusicLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewSongs()
        {
            ViewBag.Message = "Songs List";

            var data = LoadSongs();
            List<SongModel> songs = new List<SongModel>();

            foreach (var row in data)
            {
                songs.Add(new SongModel
                {
                    SongId = row.Id,
                    Title = row.Title,
                    Author = row.Author,
                    Album = row.Album,
                    CoverLink = row.CoverLink
                });
            }

            return View(songs);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Message = "Details";

            var data = LoadSongs();
            var songs = new SongModel();
            
            foreach (var row in data)
            {
                if(row.Id == id)
                {
                    songs = new SongModel
                    {
                        SongId = row.Id,
                        Title = row.Title,
                        Author = row.Author,
                        Album = row.Album,
                        CoverLink = row.CoverLink
                    };
                }
            }

            return View(songs);
        }

        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Message = "Edit";

        //    var data = LoadSongs();
        //    var songs = new SongModel();

        //    foreach (var row in data)
        //    {
        //        if (row.Id == id)
        //        {
        //            songs = new SongModel
        //            {
        //                SongId = row.Id,
        //                Title = row.Title,
        //                Author = row.Author,
        //                Album = row.Album,
        //                CoverLink = row.CoverLink
        //            };
        //        }
        //    }

        //    return View(songs);
        //}

        public ActionResult AddNewSong()
        {
            ViewBag.Message = "Add new song to the library";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewSong(SongModel model)
        {
            if (ModelState.IsValid)
            {
                CreateSong(model.Title, 
                    model.Author, 
                    model.Album, 
                    model.CoverLink);
                return RedirectToAction("ViewSongs");
            }

            return View();
        }
    }
}