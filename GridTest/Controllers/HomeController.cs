using GridTest.Models;
using JQueryDataTables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        int overFlowLimit = 13;
        public ActionResult Index()
        {
            return View("Home");
        }
        /// <summary>
        /// added comments
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {   IList<Permit> permitdata = new List<Permit>();
        permitdata.Add(new Permit() { PermitNbr = "SN13000001", ClientName = "Lala", ApplicationNbr = "1", PermitType = "Single Trip", AccountNbr = "34203" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000002", ClientName = "Amit", ApplicationNbr = "2", PermitType = "Annual Permit", AccountNbr = "34204" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000003", ClientName = "Kinjal", ApplicationNbr = "3", PermitType = "Project Permit", AccountNbr = "34205" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000004", ClientName = "Yogesh", ApplicationNbr = "4", PermitType = "Single Trip Batch", AccountNbr = "34206" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000005", ClientName = "Jigar", ApplicationNbr = "5", PermitType = "Single Trip", AccountNbr = "34207" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000006", ClientName = "Sagar", ApplicationNbr = "6", PermitType = "Single Trip", AccountNbr = "34208" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000007", ClientName = "Samir", ApplicationNbr = "7", PermitType = "Single Trip", AccountNbr = "34209" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000008", ClientName = "Tom", ApplicationNbr = "8", PermitType = "Single Trip", AccountNbr = "34210" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000010", ClientName = "Nirav", ApplicationNbr = "9", PermitType = "Annual Permit", AccountNbr = "34211" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000009", ClientName = "Vijay", ApplicationNbr = "10", PermitType = "Annual Permit", AccountNbr = "34212" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000011", ClientName = "Jeff", ApplicationNbr = "11", PermitType = "Annual Permit", AccountNbr = "34213" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000012", ClientName = "Mozilla", ApplicationNbr = "12", PermitType = "Project Permit", AccountNbr = "34214" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000013", ClientName = "Mozilla", ApplicationNbr = "13", PermitType = "Project Permit", AccountNbr = "34215" });
        permitdata.Add(new Permit() { PermitNbr = "SN13000014", ClientName = "Mozilla", ApplicationNbr = "14", PermitType = "Project Permit", AccountNbr = "34216" });
       
        
        var displaypermit = permitdata.Count>overFlowLimit? permitdata.Skip(param.iDisplayStart).Take(param.iDisplayLength):permitdata;
        
       
        var result = from c in displaypermit select new[] { c.PermitNbr, c.ClientName, c.ApplicationNbr, c.PermitType, c.AccountNbr };
            return Json(new
                            {
                                sEcho = param.sEcho,
                                iTotalRecords = permitdata.Count,
                                iTotalDisplayRecords = permitdata.Count,
                                aaData = result
                            }
                , JsonRequestBehavior.AllowGet);

        }


    }
}
