using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using EmployeeManagement.Models; //Se importa el modelo para poderlo utilizar.

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees() //Traer todos los Employees
        {       
            List<Employee> myEmployees = new List<Employee>(); //Creacion de lista del tipo de modelo a usar.
            
            //Modelo de entidades creado por entity framework que accede a la base de datos.
            using (EmployeeDBEntities db = new EmployeeDBEntities())
            {
                myEmployees = (from Employee in db.Employee 
                               select Employee).ToList(); //Consulta LINQ para llamar los datos y guardarlos en la lista.

                return Json(new {data= myEmployees }, JsonRequestBehavior.AllowGet); //Para el dataTable es necesario pasarle un atributo llamado data
            }       
        }

        public JsonResult GetEmployee(int id) {  //Traer 1 solo Employee
        
            Employee myEmployee = new Employee();

            using (EmployeeDBEntities db = new EmployeeDBEntities()) 
            {
                myEmployee = (from Employee in db.Employee
                              where Employee.Id == id  //Consulta LINQ para obtener un Employee segun el Id
                              select Employee).FirstOrDefault();  //Seleccione el primero que encuentre.

                
            }
            return Json( myEmployee , JsonRequestBehavior.AllowGet); //se retorna lo obtenido de la consulta. aqui ya no es necesario mandar el atributo, sino el objeto.
        }
        [HttpPost]
        public JsonResult UpdateEmployees(Employee oEmployee) //oEmployee es el objeto que recibe desde el metodo ajax.
        {
            bool respuesta = true; //Controla si fue satisfactoria la operación o no.
            try
            {
                if (oEmployee.Id == 0) //Si el id es ==0 Es un nuevo Employee
                {

                    using (EmployeeDBEntities db = new EmployeeDBEntities())
                    {
                        db.Employee.Add(oEmployee);  //Se añade el objeto a la DDBB
                        db.SaveChanges(); //Guardar los cambios efectuados.
                    }

                }
                else
                {
                    using (EmployeeDBEntities db = new EmployeeDBEntities())
                    {
                        Employee tempEmployee = (from Employee in db.Employee
                                                 where Employee.Id == oEmployee.Id
                                                 select Employee).FirstOrDefault();  //Consulta LINQ para obtener un Employee segun el Id

                        tempEmployee.Name = oEmployee.Name;
                        tempEmployee.Position = oEmployee.Position;  //Se añaden los valores a la db.
                        tempEmployee.Office = oEmployee.Office;
                        tempEmployee.Salary = oEmployee.Salary;
                        db.SaveChanges(); //Es IMPORTANTE tener bien configurada la PK.

                    }

                }
            }
            catch
            {
                respuesta = false;

            }
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet); //Nos devuelve true si todo sale bien o false si existe alguna excepción

        }

        public JsonResult DeleteEmployee(int id) { 
        
            bool respuesta = true;  //Nos muestra si es satisfactoria o no la operacion.

            try
            {
                using (EmployeeDBEntities db= new EmployeeDBEntities())
                {
                    Employee oEmploye = new Employee();

                    oEmploye= (from Employee in db.Employee.Where(e => e.Id == id)  //Manera distinta de obtener el Employee por el Id (Funcion flecha o lambda )
                               select Employee).FirstOrDefault();
                    db.Employee.Remove(oEmploye); //Eliminacion del objeto
                    db.SaveChanges(); //Guardar cambios.

                }
            } 
            catch (Exception)
            {
                respuesta=false;
                throw;
            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

    }


}