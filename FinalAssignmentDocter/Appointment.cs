using System;

namespace FinalAssignmentDocter
{
    class Appointment
    {
        private static int _appointmentid = 0;

        public int AppointmentId;
        public int PatientId { get; set; }
        public int DocterId { get; set; }
        public DateTime Date { get; set; }
        public string Problem { get; set; }



        public Appointment(int Patientid,int DocterId,DateTime Date,string Problem)
        {
            _appointmentid++;
            this.AppointmentId = _appointmentid;
            this.PatientId = Patientid;
            this.DocterId = DocterId;
            this.Date = Date;
            this.Problem = Problem;
        }

    }
}
