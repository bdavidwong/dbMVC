using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dbMVC.Lib;

namespace dbMVC.Tests.Models
{
    public class InMemoryEmployeeReposittory : dbMVC.Lib.EmployeeManagerBase, IEmployeeManager, IEnumerable<Employee>
    {
        public override void Add(Employee value)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(Employee value)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Employee data)
        {
            throw new NotImplementedException();
        }

        public override bool Update(IEnumerable<Employee> data)
        {
            throw new NotImplementedException();
        }

        public override Employee this[int index]
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerator<Employee> GetEnumerator()
        {
            return new List<Employee>().GetEnumerator();
            //return base.GetEnumerator();
        }

        public override IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Employee Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
