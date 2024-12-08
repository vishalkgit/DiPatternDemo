using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

        int AddEmployee(Employee employee);

        int UpdateEmployee(Employee employee);

        int DeleteEmployee(int id);
      
    }
}
