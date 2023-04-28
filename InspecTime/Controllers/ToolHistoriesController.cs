using InspecTime.Data;
using InspecTime.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.ToolProcessor;

namespace InspecTime.Controllers
{
    public class ToolHistoriesController : Controller
    {

        private List<ToolHistory> allToolHistory;

        public void getList()
        {
            var data = LoadToolsHistory();
            List<ToolHistory> tools = new List<ToolHistory>();

            foreach (var row in data)
            {
                tools.Add(new ToolHistory
                {
                    ID = row.ID,
                    toolNumber = row.toolNumber,
                    D_Remove = row.D_Remove,
                    P_Return = row.P_Return,
                    EmpNo = row.EmpNo,
                    WC = row.WC

                });
            }
            allToolHistory = tools;
        }

        // GET: ToolHistories
        public ActionResult Index(string SearchString)
        {
            getList();
            if (!String.IsNullOrEmpty(SearchString))
            {
                return View(allToolHistory.Where(tool => tool.toolNumber.ToUpper().Contains(SearchString.ToUpper())));
            }

            return View(allToolHistory);
        }

        // GET: ToolHistories/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ToolHistory toolHistory = db.ToolHistories.Find(id);
        //    if (toolHistory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toolHistory);
        //}

        //// GET: ToolHistories/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ToolHistories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "toolNumber,D_Remove,P_Return,DateReturned,WC,EmpNo")] ToolHistory toolHistory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ToolHistories.Add(toolHistory);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(toolHistory);
        //}

        //// GET: ToolHistories/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ToolHistory toolHistory = db.ToolHistories.Find(id);
        //    if (toolHistory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toolHistory);
        //}

        //// POST: ToolHistories/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "toolNumber,D_Remove,P_Return,DateReturned,WC,EmpNo")] ToolHistory toolHistory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(toolHistory).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(toolHistory);
        //}

        //// GET: ToolHistories/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ToolHistory toolHistory = db.ToolHistories.Find(id);
        //    if (toolHistory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toolHistory);
        //}

        //// POST: ToolHistories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ToolHistory toolHistory = db.ToolHistories.Find(id);
        //    db.ToolHistories.Remove(toolHistory);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)

        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
