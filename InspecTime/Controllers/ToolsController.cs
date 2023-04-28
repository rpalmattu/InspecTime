using DataLibrary;
using DataLibrary.Models;
using InspecTime.Data;
using InspecTime.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.ToolProcessor;

namespace InspecTime.Controllers
{
    public class ToolsController : Controller
    {
        private List<Tool> currentTools;

        // Updates the variable currentTools so that it gets most recent data from DB
        public void getList()
        {
            var data = LoadCheckedOutTools();
            List<Tool> tools = new List<Tool>();

            foreach (var row in data)
            {
                tools.Add(new Tool
                {
                    toolNumber = row.toolNumber,
                    D_Remove = row.D_Remove,
                    P_Return = row.P_Return,
                    EmpNo = row.EmpNo,
                    WC = row.WC

                });
            }
            currentTools = tools;
        }

        // Is used to populate the WC Dropdown list in a tool object
        public List<string> getWCList()
        {
            var data = LoadFields("WC");
            List<string> WCList = new List<string>();

            foreach (var row in data)
            {
                WCList.Add(row);
            }
            return WCList;
        }

        // Is used to populate the toolNo Dropdown list in a tool object
        public List<string> getToolNoList()
        {
            var data = LoadFields("ToolNo");
            List<string> toolNoList = new List<string>();

            foreach (var row in data)
            {
                toolNoList.Add(row);
            }
            return toolNoList;
        }

        // Is used to populate the ID Dropdown list in a tool object
        public List<string> getIDList()
        {
            var data = LoadFields("Empl");
            List<string> emplList = new List<string>();

            foreach (var row in data)
            {
                emplList.Add(row);
            }
            return emplList;
        }


        // GET: Tools
        public ActionResult Index(string SearchString)
        {
            getList();
            if (!String.IsNullOrEmpty(SearchString))
            {
                return View(currentTools.Where(tool => tool.toolNumber.ToUpper().Contains(SearchString.ToUpper())));
            }

            return View(currentTools);
        }

        // Error
        public ActionResult Error()
        {
            return View();
        }

        // GET: Tools/Details/5
        public ActionResult Details(string id)
        {
            getList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = currentTools.Find(x => x.toolNumber == id);

            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // GET: Tools/Create
        public ActionResult CheckOut()

        {
            getWCList();
            Tool dropDownTool = new Tool();
            dropDownTool.WCdropDownList = getWCList();
            dropDownTool.EmplDropDownList = getIDList();
            dropDownTool.ToolNoDropDownList = getToolNoList();

            return View(dropDownTool);
        }

        // POST: Tools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut([Bind(Include = "toolNumber,D_Remove,P_Return,WC,EmpNo")] Tool tool)
        {

            if (!InDB(tool.toolNumber))
            {
                ModelState.AddModelError(nameof(tool.toolNumber), "Please return already checked out tool first");
            }

            if (ModelState.IsValid)
            {

                try
                {
                    CreateTool(tool.toolNumber,
                            tool.D_Remove,
                            tool.P_Return,
                            tool.WC,
                            tool.EmpNo);
                    return RedirectToAction("Index");

                }
                catch
                {
                    return RedirectToAction("Error");

                }
                //db.Tools.Add(tool);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            getWCList();

            tool.WCdropDownList = getWCList();
            tool.EmplDropDownList = getIDList();
            tool.ToolNoDropDownList = getToolNoList();

            return View(tool);
        }




        // GET: Tools/Edit/5
        public ActionResult Edit(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            getList();
            Tool tool = currentTools.Find(x => x.toolNumber == id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "toolNumber,D_Remove,P_Return,WC,EmpNo")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateTool(tool.toolNumber,
                            tool.D_Remove,
                            tool.P_Return,
                            tool.WC,
                            tool.EmpNo);
                    //db.Entry(tool).State = EntityState.Modified;
                    //db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return Redirect("Error");
                }
            }
            return View(tool);
        }

        // GET: Tools/Delete/5
        public ActionResult Return(string id)
        {
            getList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = currentTools.Find(x => x.toolNumber == id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnConfirmed(string id)
        {
            getList();
            Tool tool = currentTools.Find(x => x.toolNumber == id);

            // REMOVE Function

            returnCheckedOutTool(tool.toolNumber, tool.D_Remove, tool.P_Return, tool.WC, tool.EmpNo);




            return RedirectToAction("Index");
        }

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
