using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbMVC.Lib
{
   public class EmployeeManager : IEnumerable<Employee>
   {
       private static List<Employee> employees = new List<Employee>();

       public EmployeeManager()
       {
           if (employees.Count == 0)
           {
               employees.Add(new Employee() {ID = 1, FullName = "Daisy", Email = "d@d.com", Phone = "301-232-1343"});
               employees.Add(new Employee() {ID = 2, FullName = "Harrison", Email = "h@d.com", Phone = "231-332-1333"});
               employees.Add(new Employee() {ID = 3, FullName = "Mary", Email = "m@d.com", Phone = "231-332-1333"});
           }
       }
       
       public  void Add(Employee value)
       {
           employees.Add(value);
           
       }

       public bool Remove(Employee value)
       {
           return employees.Remove(value);
       }

       public bool Update(Employee data)
       {
           var foundItem = employees.Single(x => x.ID == data.ID);
           if (foundItem != null)
           {
               employees.Remove(foundItem as Employee);
               employees.Add(data);
               return true;
           }
           else
           {
               return false;
           }
           
       }
       
       public bool Update(IEnumerable<Employee> data )
       {
           employees = (List<Employee>)data;
           return true;
       }

       public Employee this[int index]
       {
           get { return employees[index]; }
       }

       public IEnumerator<Employee> GetEnumerator()
       {
           return employees.GetEnumerator();
       }

       IEnumerator IEnumerable.GetEnumerator()
       {
           return this.GetEnumerator();
       }

       public IEnumerable<Employee> GetAll()
       {
           return employees;
       }

       public Employee Get(int id)
       {
           return employees.Single(x => x.ID == id);
       }
   }
}
