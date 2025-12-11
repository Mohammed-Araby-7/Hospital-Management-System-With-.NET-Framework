using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagment.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Disease { get; set; }

        public string Phone {  get; set; }

        //public string DoctorId { get; set; }
        
        //Navigation Properity
        public Doctor? Doctor { get; set; }

        public int DoctorId { get; set; }   

        //public List<Perciption> Perciption { get; set; }

        public List<Appoinitment>? Appoinitments { get; set; }
    }
}
