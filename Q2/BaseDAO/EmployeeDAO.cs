using Q2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2.BaseDAO
{
    internal class EmployeeDAO
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using var context = new PeFall21B5Context();
                employees = context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employees;
        }

        public List<string> GetPositions()
        {
            List<string> positions = new List<string>();
            try
            {
                var context = new PeFall21B5Context();
                positions = context.Employees.Select(e => e.Position).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return positions;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                var context = new PeFall21B5Context();
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            try
            {
                var context = new PeFall21B5Context();
                employee = context.Employees.SingleOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                var context = new PeFall21B5Context();
                context.Employees.Update(employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
