using System.Collections.Generic;

namespace dbMVC.Lib
{
    public interface IEmployeeManager
    {
        void Add(Employee value);
        bool Remove(Employee value);
        bool Update(Employee data);
        bool Update(IEnumerable<Employee> data );
        Employee this[int index] { get; }
        //IEnumerator<Employee> GetEnumerator();
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
    }
}