namespace HospitalManagment.Models
{
    public class Clinic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation Properity
        public List<Doctor>? Doctor { get; set; }
        public List<Appoinitment>? Appoinitments { get; set; }

    }
}
