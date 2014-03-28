using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbMVC.Lib
{
   public class EmployeeManager : EmployeeManagerBase
   {
       public EmployeeManager() : base()
       {
       }
       
       public override void Add(Employee value)
       {
           employees.Add(value);
           
       }

       public override bool Remove(Employee value)
       {
           return employees.Remove(value);
       }

       public override bool Update(Employee data)
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
       
       public override bool Update(IEnumerable<Employee> data )
       {
           employees = (List<Employee>)data;
           return true;
       }

       public override Employee this[int index]
       {
           get { return employees[index]; }
       }

       public override IEnumerator<Employee> GetEnumerator()
       {
           return employees.GetEnumerator();
       }

       public override IEnumerable<Employee> GetAll()
       {
           return employees;
       }

       public override Employee Get(int id)
       {
           return employees.Single(x => x.ID == id);
       }
   }
}
