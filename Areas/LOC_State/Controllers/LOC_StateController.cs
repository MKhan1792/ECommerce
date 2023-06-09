﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.DAL;
using System.Data;
using ECommerce.Auth;

namespace ECommerce.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    [Route("LOC_State/[Controller]/[action]")]
    //[CheckAdminAccess]
    public class LOC_StateController : Controller
    {
        LOC_StateDAL stateDAL = new LOC_StateDAL();
        // GET: LOC_StateController
        public ActionResult Admin()
        {
            DataTable dtState = stateDAL.PR_LOC_State_SelectAll();
            return View("StateList",dtState);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LOC_StateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOC_StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LOC_StateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LOC_StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LOC_StateController/Delete/5
        public ActionResult Delete(int StateId)
        {
            if (Convert.ToBoolean(stateDAL.PR_LOC_State_Delete(StateId)))
                return RedirectToAction("Admin");
            return View("Admin");
        }
    }
}
