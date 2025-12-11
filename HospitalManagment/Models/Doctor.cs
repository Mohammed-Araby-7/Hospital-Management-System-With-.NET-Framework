namespace HospitalManagment.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }

        public string Phone { get; set; }

        public int ClinicId { get; set; }
        //Navigation Propeirty [Doctors and Clinks]
        public Clinic? Clinic { get; set; }

        //Navigation Properity [Doctors And Patients]
        public List<Patient>? Patient { get; set; }

        //public List<Perciption> Perciptions { get; set; }

        public List<Appoinitment>? Appoinitments { get; set; }
    }
}
