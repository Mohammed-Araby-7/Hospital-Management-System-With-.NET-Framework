namespace HospitalManagment.Models
{
    public class Appoinitment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        ////Navigation Propirty
        public Doctor? Doctor { get; set; }
        public int DoctorId { get; set; }
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }

        public int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        

    }
}
