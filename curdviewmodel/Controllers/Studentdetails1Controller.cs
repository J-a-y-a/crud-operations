using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using curdviewmodel;
using curdviewmodel.Models;
using curdviewmodel.ViewModels;


namespace curdviewmodel.Controllers
{
    public class Studentdetails1Controller : Controller
    {
        private jayaEntities db = new jayaEntities();
        // GET: Studentdetails1
        public ActionResult Index()
        {
           
            GetStudent();
            return View();
        }

        public ActionResult GetStudent()
        {

            var stu = db.Studentdetails.ToList();
            return Json(new { data = stu }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpGet]
        public JsonResult GetstudentbyId(string Stuid)
        {
            using (jayaEntities db = new jayaEntities())
            {
                bool flag = false;
                var emp1 = db.Studentdetails.Where(x => x.Sid == Stuid).FirstOrDefault();

                if (emp1 != null)
                {

                    flag = true;
                }
                else
                {
                    flag = false;
                }


                return Json(new { result = flag }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Save(studentViewModel user)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                int i = 0;
                try
                {

                    var errors = ModelState.Select(x => x.Value.Errors)
                               .Where(y => y.Count > 0)
                               .ToList();
                    if (ModelState.IsValid)
                    {


                        if (user.ID == 0 || user.ID == null)
                        {
                            Studentdetail student = new Studentdetail();
                            student.Sid = user.Sid;
                            student.Sname = user.Sname;
                            student.Age = user.Age;
                            student.Adress = user.Adress;
                            student.classes = user.classes;
                            student.Fname = user.Fname;
                            student.Phno = user.Phno;
                            student.Gmail = user.Gmail;
                            student.Pincode = user.Pincode;
                            db.Studentdetails.Add(student);
                            i = db.SaveChanges();
                            transaction.Commit();
                            if (i > 0)
                            {
                                return Json(new { success = true, message = "Data inserted Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { success = true, message = "Data Not inserted" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {



                            var stu1 = (from stu in db.Studentdetails
                                        where stu.Sid == user.Sid
                                        select stu).FirstOrDefault();
                            stu1.Sname = user.Sname;
                            stu1.Age = user.Age;
                            stu1.Adress = user.Adress;
                            stu1.classes = user.classes;
                            stu1.Fname = user.Fname;
                            stu1.Phno = user.Phno;
                            stu1.Gmail = user.Gmail;
                            stu1.Pincode = user.Pincode;
                            db.Entry(stu1).State = EntityState.Modified;
                            i = db.SaveChanges();
                            transaction.Commit();
                            if (i > 0)
                            {
                                return Json(new { success = true, message = "Data updated Successfully" }, behavior: JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { success = true, message = "Data Not updated" }, behavior: JsonRequestBehavior.AllowGet);

                            }
                        }
                    }



                    return View();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw (ex);
                }
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                using (jayaEntities db = new jayaEntities())
                {

                    var emp = (from Employee in db.Studentdetails
                               where Employee.ID == id
                               select Employee).FirstOrDefault();

                    return Json(emp, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                throw;
            }
        }

        public JsonResult DeleteStudent(int? ID)
        {
            int i = 0;

            using (jayaEntities db = new jayaEntities())
            {
                using (var dbtranscation = db.Database.BeginTransaction())
                {
                    try
                    {
                        var emp = db.Studentdetails.Find(ID);
                        if (emp != null)
                        {
                            db.Studentdetails.Remove(emp);
                            i = db.SaveChanges();
                             dbtranscation.Commit();
                        }

                        if (i > 0)
                        {
                            return Json(data: " data Deleted successfully", behavior: JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(data: " data NotDeleted", behavior: JsonRequestBehavior.AllowGet);
                        }

                    }
                    catch (Exception ex)
                    {
                        dbtranscation.Rollback();
                        return Json(data: "Error occured", behavior: JsonRequestBehavior.AllowGet);
                    }

                }
            }
        }
        [HttpGet]
        public ActionResult GenerateStudentCode()
        {

            using (jayaEntities db = new jayaEntities())
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();
                // var prefix = "ST";
                var Code = "";
                var maxcode = db.Studentdetails.Select(e => e.Sid).Max();
                if (maxcode == null)
                {
                    Code = "001";
                }
                else
                {
                    var nextId = Convert.ToInt32(maxcode.Substring(2)) + 1;


                    if (nextId < 10)
                    {
                        Code = "00" + nextId;
                    }
                    else if (nextId >= 10)
                    {
                        Code = "0" + nextId;
                    }
                }
                Code = "ST" + Code;


                return Json(Code, JsonRequestBehavior.AllowGet);


            }

        }





    }


}

