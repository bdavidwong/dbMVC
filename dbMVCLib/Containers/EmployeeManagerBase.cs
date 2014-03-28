using System.Collections;
using System.Collections.Generic;

namespace dbMVC.Lib
{
    public abstract class EmployeeManagerBase : IEnumerable<Employee>, IEmployeeManager
    {
        protected static List<Employee> employees = new List<Employee>();

        public EmployeeManagerBase()
        {
            if (employees.Count == 0)
            {
                employees.Add(new Employee() {ID = 1, FullName = "Daisy", Email = "d@d.com", Phone = "301-232-1343"});
                employees.Add(new Employee() {ID = 2, FullName = "Harrison", Email = "h@d.com", Phone = "231-332-1333"});
                employees.Add(new Employee() {ID = 3, FullName = "Mary", Email = "m@d.com", Phone = "231-332-1333"});
            }
        }

        public abstract void Add(Employee value);
        public abstract bool Remove(Employee value);
        public abstract bool Update(Employee data);
        public abstract bool Update(IEnumerable<Employee> data );
        public abstract Employee this[int index] { get; }
        public abstract IEnumerator<Employee> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public abstract IEnumerable<Employee> GetAll();
        public abstract Employee Get(int id);
    }
}