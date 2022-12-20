using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignmentDocter
{
    public enum Gender
    {
        male=1,
        female
    }
    class Patient
    {
        private static int _patientId = 0;

        public int PatientId;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public Gender Gender{ get; set; }

        public Patient(string Name, string password, int Age, Gender gender)
        {
            _patientId++;
            this.PatientId = _patientId;
            this.Name = Name;
            this.Password = password;
            this.Age = Age;
            this.Gender = gender;
        }
    }
}
