using Animal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Animal.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            return View();
        }

        //-----------------------------//

        //create index

        public ActionResult CountryCreate()
        {
            return View("CountryCreate");
        }

        //insert

        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string country_name = frm["country_name"];
                bool isActive = frm["isActive"] == "on" ? true : false;
           var status = model.InsertCountry(country_name, isActive);
               return RedirectToAction("CountryIndex");
            }
            else
            {
                return RedirectToAction("CountryIndex");
            }
        }

        /*Delete*/
        public ActionResult Delete(int country_id)
        {
            CRUDModel model = new CRUDModel();
            model.DeleteCountry(country_id);
            return RedirectToAction("CountryIndex");
        }


        public ActionResult UpdateRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string country_name = frm["country_name"];
                bool isActive = frm["isActive"] == "on" ? true : false;
                int country_id = Convert.ToInt32(frm["country_id"]);
                var status = model.UpdateCountry(country_name, isActive, country_id);

                return RedirectToAction("CountryIndex");
            }

            return RedirectToAction("CountryIndex");
        }
      /* -------------------------------------*/

        /*Index*/
        public ActionResult CountryIndex()
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.GetAllCountry();
            return View("CountryIndex", dt);
        }


        //Edit index
        public ActionResult CountryEdit(int country_id)
        {

            CRUDModel model = new CRUDModel();
            DataTable dt = model.GetCountryByID(country_id);
            return View(dt);

        }

        //---------------------------------------------------
        public ActionResult Home()
        {

            return View();
        }

    }
}
   