namespace HospitalManagment.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int Ssn { get; set; }
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string JobTitle { get; set; }

        public string WorkType { get; set; }
    }
}
