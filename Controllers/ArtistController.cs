using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveArtist(ArtistModel model)
        {

            try
            {

                return Json(new { model = (new ArtistModel().SaveArtist(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetArtList()
        {

            try
            {

                return Json(new { model = (new ArtistModel().GetArtistList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetArtDDLList()
        {

            try
            {

                return Json(new { model = (new ArtistModel().GetArtDDLList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}