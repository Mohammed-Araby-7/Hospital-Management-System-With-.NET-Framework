namespace HospitalManagment.Models
{
    public class Perciption
    {
        public int Id { get; set; }

        public string Dosage { get; set; }

        public DateTime Date { get; set; }

        public string MedicaneName {  get; set; }

        public string Phone { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        ////Navigation Properity
        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }
    }
}
