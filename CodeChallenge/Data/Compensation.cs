using CodeChallenge.Models;
using System;

namespace CodeChallenge.Data
{
    public class Compensation
    {
        //get set for employee, employeeId, salary, and effectiveDate
        public Employee employee { get; set; }
        public string employeeId { get; set; }
        public int salary { get; set; }
        public string effectiveDate { get; set; }

        //constructor for Compensation
        public Compensation() {

            this.employeeId = "";
            this.salary = 0;
            this.effectiveDate = "00/00/00";  
        }

        //constructor for Compensation given employee, salary, and effectiveDate
        public Compensation(Employee employee, int salary, String effectiveDate)
        {
            this.employee = employee;
            this.salary = salary;
            this.effectiveDate = effectiveDate;
            this.employeeId = this.employee.EmployeeId;
        }   


    }
}
