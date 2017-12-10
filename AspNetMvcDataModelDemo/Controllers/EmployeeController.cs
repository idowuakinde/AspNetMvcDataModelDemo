using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AspNetMvcDataModelDemo.Models;

namespace AspNetMvcDataModelDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDbContext db = new EmpDbContext();
        // GET: Employee
        public ActionResult Index()
        {
			var employees = from e in db.Employees
							orderby e.ID
                            select e;
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
		public ActionResult Create(Employee emp)
		{
			try
			{
                db.Employees.Add(emp);
                db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Employee/Edit/5
		public ActionResult Edit(int id)
        {
            var employee = db.Employees.Single(m => m.ID == id);
            return View(employee);
        }

        // TODO: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = db.Employees.Single(m => m.ID == id);
                if (TryUpdateModel(employee)) 
                {
                    // ToDo: database code
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // GET: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Employee> GetEmployeeList()
        {
            return new List<Employee>
            {
                new Employee( ID: 1, Name: "Allan", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 23 ),
                new Employee( ID: 2, Name: "Carson", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 45 ),
                new Employee( ID: 3, Name: "Carson", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 37 ),
                new Employee( ID: 4, Name: "Laura", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 26 )
            };
        }

        public static List<Employee> empList = new List<Employee>
        {
            new Employee( ID: 1, Name: "Allan", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 23 ),
            new Employee( ID: 2, Name: "Carson", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 45 ),
            new Employee( ID: 3, Name: "Carson", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 37 ),
            new Employee( ID: 4, Name: "Laura", JoiningDate: DateTime.Parse(DateTime.Today.ToString()), Age: 26 )
        };
    }
}
