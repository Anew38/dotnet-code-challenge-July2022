using CodeChallenge.Models;

namespace CodeChallenge.Data
{
    public class ReportingStructure
    {
        //get set for employee and numberOfReports
        private Employee employee;

        private int numberOfReports;

        //constructor for ReportingStructure
        public ReportingStructure()
        {
            this.numberOfReports = 0;
        }
        //constructor for ReportingStructure given employee
        public ReportingStructure(Employee employee)
        {
            this.employee = employee;
            this.numberOfReports = 0;
        }
        //getters and setters for employee and numberOfReports
        public int getNumberOfReports()
        {
            return numberOfReports;
        }
        //getters and setters for employee and numberOfReports
        public void setNumberOfReports(int numberOfReports)
        {
            this.numberOfReports = numberOfReports;
        }

    }

}
