using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Namespace for Docter appointment system
/// </summary>
/// 
namespace FinalAssignmentDocter
{
    /// <summary>
    /// Create Class for appointment system
    /// </summary>
    class AppointmentManager
    {
        string CURRENT_USER_NAME = "";
        int CURRENT_USER_ID = 0;
        string USERNAME = "yuvaraj";
        string password = "Yup@";
        //Create PatientList with Patient class
        public List<Patient> PatientList = new List<Patient>();

        //Create DocterList with Docter class
        public List<Docter> DocterList = new List<Docter>();

        //Create Appointment list with appointment class
        public List<Appointment> AppointmentList = new List<Appointment>();

        //Create Object for AppointmentManager class
        public static AppointmentManager Apmanager = new AppointmentManager();

        /// <summary>
        /// Create main class for start the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Insert default patients,docters and Appointments
            Apmanager.Default();

            do
            {
                Console.WriteLine("\n----Welcome to Appointment Management system");
                Console.WriteLine("1.Login\n2.Register\n3.Exit");
                Console.Write("\nChoose:>> ");
                int choose = int.Parse(Console.ReadLine());

                if (choose == 1)
                {
                    Apmanager.Login();
                }
                else if (choose == 2)
                {
                    Apmanager.Register();
                }
                else if (choose == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("X------X-----X-----X------X");
                    Console.WriteLine("Please choose give option!");
                    Console.WriteLine("X------X-----X-----X------X");

                }

            } while (true);
        }

        /// <summary>
        /// Add two user details 
        /// </summary>
        public void Default()
        {
            // Insert Default Patient data into Patient list
            Patient patientObj1 = new Patient("Robert", "welcome", 40, Gender.male);
            Patient patientObj2 = new Patient("Laura", "welcome", 36, Gender.female);
            Patient patientObj3 = new Patient("Anne", "welcome", 42, Gender.female);
            PatientList.Add(patientObj1);
            PatientList.Add(patientObj2);
            PatientList.Add(patientObj3);

            //Insert Default Docter data into Docter list
            Docter DocterObj1 = new Docter("Nancy", "Anaesthesiology");
            Docter DocterObj2 = new Docter("Andrew", "Cardiology");
            Docter DocterObj3 = new Docter("Janet", "Diabetology");
            Docter DocterObj4 = new Docter("Margaret", "Neonatology");
            Docter DocterObj5 = new Docter("Steven", "Nephrology");
            DocterList.Add(DocterObj1);
            DocterList.Add(DocterObj2);
            DocterList.Add(DocterObj3);
            DocterList.Add(DocterObj4);
            DocterList.Add(DocterObj5);

            //Insert Default Appointment for docters
            Appointment appointmentObj1 = new Appointment(1, 2, Convert.ToDateTime("08/03/2012"), "Heart Problem");
            Appointment appointmentObj2 = new Appointment(1, 5, Convert.ToDateTime("08/03/2012"), "Spinal cord injury");
            Appointment appointmentObj3 = new Appointment(2, 2, Convert.ToDateTime("08/03/2012"), "Heart attack");
            AppointmentList.Add(appointmentObj1);
            AppointmentList.Add(appointmentObj2);
            AppointmentList.Add(appointmentObj3);
        }

        /// <summary>
        /// Register New patient
        /// </summary>
        public void Register()
        {
            Console.Clear();
            Console.WriteLine("-------User Registration--------");
            Console.Write("User Name :>> ");
            string Uname = Console.ReadLine().ToLower();
            Console.Write("Password :>> ");
            string Upass = Console.ReadLine();
            Console.Write("Age :>> ");
            int Uage = int.Parse(Console.ReadLine());
            Console.WriteLine("\n1.Male\n2.Female");
            Console.Write("\nGender :>>");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            Patient patientObj = new Patient(Uname, Upass, Uage, gender);
            PatientList.Add(patientObj);

            Console.Clear();
            MessageBox.Show("Registration success");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"Registration Successfull\nYour Patient ID : {patientObj.PatientId}");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }

        /// <summary>
        /// Check User login
        /// </summary>
        public void Login()
        {
            string UserEnteredName;
            char Useropt;
            string Addressing = "";
            Console.Clear();
            Console.WriteLine("-----Login-----");
            Console.Write("User Name: >>");
            UserEnteredName = Console.ReadLine().ToLower();
            Console.Write("Password :>> ");
            string UserEntredPass = Console.ReadLine();

            //Send User details For validation.
            if (Validate(UserEnteredName, UserEntredPass))
            {
                do
                {
                    //Find user name and Gender for Loggedin user
                    foreach (var val in PatientList)
                    {
                        if (val.PatientId == CURRENT_USER_ID)
                        {
                            CURRENT_USER_NAME = val.Name;

                            if (val.Gender == Gender.male)
                            {
                                Addressing = "Mr";
                                break;
                            }
                            else if (val.Gender == Gender.female)
                            {
                                Addressing = "Miss";
                                break;
                            }
                        }

                    }
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Welcome:>> {Addressing}.{CURRENT_USER_NAME}");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("1.Book Appointment\n2.View Appointment Details" +
                                       "\n3.Edit my Profile\n4.Exit");
                    Console.Write("\n----------\nChoose:>> ");
                    int userOption = int.Parse(Console.ReadLine());

                    switch (userOption)
                    {
                        case 1:
                            Apmanager.BookAppointment();
                            break;

                        case 2:
                            Apmanager.ViewDetail();
                            break;

                        case 3:
                            Apmanager.EditDetail();
                            break;

                        case 4:
                            break;

                        default:
                            Console.WriteLine("X-----X-----X----X-----X");
                            Console.WriteLine("You Entered worng option!");
                            Console.WriteLine("X-----X-----X----X-----X");
                            break;
                    }
                    do
                    {
                        Console.Write("\nDo you want to continue User Menu? (Y/N)");
                        Useropt = char.Parse(Console.ReadLine().ToUpper());
                    } while (Useropt != 'Y' && Useropt != 'N');

                } while (Useropt != 'N');
            }
            else
            {
                MessageBox.Show("Username or password wrong!");
            }
        }
        public void BookAppointment()
        {
            Console.Clear();
            Console.WriteLine("----------Appointment Section----------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Welcome Mr/Miss>>: {CURRENT_USER_NAME}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Anaesthesiology\n2. Cardiology\n3. Diabetology\n4. Neonatology\n5. Nephrology ");
            Console.Write("\n-----------\nChoose:>> ");
            int UserDepartment = int.Parse(Console.ReadLine());
            switch (UserDepartment)
            {
                case 1:
                    Apmanager.Anasthesiology();
                    break;

                case 2:
                    Apmanager.Cardiology();
                    break;

                case 3:
                    Apmanager.Diabetology();
                    break;

                case 4:
                    Apmanager.Neonatology();
                    break;

                case 5:
                    Apmanager.Nephrology();
                    break;

                case 6:
                    break;
            }
        }

        /// <summary>
        /// Book appointment for perticular Docter with curesponding patient
        /// </summary>
        public void Anasthesiology()
        {
            int count = 0;
            int tempDocID = 0;
            foreach (Docter data in DocterList)
            {
                if (data.DocterDepartment == "Anaesthesiology")
                {
                    //Check if docter is available or booked

                    foreach (Appointment val in AppointmentList)
                    {
                        if (data.DocterId == val.DocterId)
                        {
                            tempDocID = data.DocterId;
                            count += 1;
                        }
                        else
                        {
                            tempDocID = data.DocterId;
                        }
                    }

                    // If docter already have two patient in one day new appointment will postpone to next day
                    if (count >= 2)
                    {
                        Console.WriteLine($"Docter today busy Can you book tommarow {DateTime.Now.AddDays(1)}");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now.AddDays(1), problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }

                    //if docter is free then Book today;
                    else if (count <= 1)
                    {
                        Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now} ");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now, problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                }
            }
        }
        public void Cardiology()
        {
            int count = 0;
            int tempDocID = 0;
            foreach (Docter data in DocterList)
            {
                if (data.DocterDepartment == "Cardiology")
                {
                    foreach (Appointment val in AppointmentList)
                    {
                        if (data.DocterId == val.DocterId)
                        {
                            tempDocID = data.DocterId;
                            count += 1;
                        }
                        else
                        {
                            tempDocID = data.DocterId;
                        }
                    }
                    if (count >= 2)
                    {
                        Console.WriteLine($"Docter today busy Could you book tommarow {DateTime.Now.AddDays(1)}");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now.AddDays(1), problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                    else if (count <= 1)
                    {
                        Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now} ");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now, problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                }
            }
        }
        public void Neonatology()
        {
            int count = 0;
            int tempDocID = 0;
            foreach (Docter data in DocterList)
            {
                if (data.DocterDepartment == "Neonatology")
                {
                    foreach (Appointment val in AppointmentList)
                    {
                        if (data.DocterId == val.DocterId)
                        {
                            tempDocID = data.DocterId;
                            count += 1;
                        }
                        else
                        {
                            tempDocID = data.DocterId;
                        }
                    }
                    if (count >= 2)
                    {
                        Console.WriteLine($"Docter today busy Could you book tommarow {DateTime.Now.AddDays(1)}");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now.AddDays(1), problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                    else if (count <= 1)
                    {
                        Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now} ");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now, problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                }
            }
        }
        public void Nephrology()
        {
            int count = 0;
            int tempDocID = 0;
            foreach (Docter data in DocterList)
            {
                if (data.DocterDepartment == "Nephrology")
                {
                    foreach (Appointment val in AppointmentList)
                    {
                        if (data.DocterId == val.DocterId)
                        {
                            tempDocID = data.DocterId;
                            count += 1;
                        }
                        else
                        {
                            tempDocID = data.DocterId;
                        }
                    }
                    if (count >= 2)
                    {
                        Console.WriteLine($"Docter today busy Could you book tommarow {DateTime.Now.AddDays(1)}");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now.AddDays(1), problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                    else if (count <= 1)
                    {
                        Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now} ");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now, problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                }
            }
        }
        public void Diabetology()
        {
            int count = 0;
            int tempDocID = 0;
            foreach (Docter data in DocterList)
            {
                if (data.DocterDepartment == "Diabetology")
                {
                    foreach (Appointment val in AppointmentList)
                    {
                        if (data.DocterId == val.DocterId)
                        {
                            tempDocID = data.DocterId;
                            count += 1;
                        }
                        else
                        {
                            tempDocID = data.DocterId;
                        }
                    }
                    if (count >= 2)
                    {
                        Console.WriteLine($"Docter today busy Could you book tommarow {DateTime.Now.AddDays(1)}");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now.AddDays(1), problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                    else if (count <= 1)
                    {
                        Console.WriteLine($"Appointment is confirmed for the date {DateTime.Now} ");
                        Console.Write($"Confirm Booking?(Y/N) :>> ");
                        char option = char.Parse(Console.ReadLine().ToLower());
                        if (option == 'y')
                        {
                            Console.WriteLine("Tell me what is Your problem?");
                            string problem = Console.ReadLine();
                            Appointment AppointmentObj = new Appointment(CURRENT_USER_ID, tempDocID, DateTime.Now, problem);
                            AppointmentList.Add(AppointmentObj);
                            MessageBox.Show("Appointment Booked successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Booking Cancelled!");
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Show Patient Appointment list
        /// </summary>
        public void ViewDetail()
        {
            foreach (var val in AppointmentList)
            {
                if (val.PatientId == CURRENT_USER_ID)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"Patient ID : {val.PatientId}\n" +
                                      $"Docter ID: {val.DocterId}\n" +
                                      $"Date of Appointment : {val.Date}\n" +
                                      $"Problem : {val.Problem}\n" +
                                      $"-----------------------\n");
                }
            }
        }

        /// <summary>
        /// Edit User or Patient Details 
        /// </summary>
        public void EditDetail()
        {
            char UserOpt;
            do
            {
                Console.Clear();
                Console.WriteLine("------Profile Edit-------");
                Console.WriteLine("1.Name\n2.password\n3.Age\n4.Gender\n5.Exit");
                Console.Write("---------\nChoose To edit :>> ");
                int userOption = int.Parse(Console.ReadLine());
                switch (userOption)
                {
                    //Edit Patient Name 
                    case 1:
                        Console.WriteLine("---Edit your name----");
                        Console.Write("Enter Your Currect Name :>> ");
                        string name = Console.ReadLine().ToLower();
                        if(name == "")
                        {
                            Console.WriteLine("Please Enter Name !");
                        }
                        else
                        {
                            foreach (var data in PatientList)
                            {
                                if (data.PatientId == CURRENT_USER_ID)
                                {
                                    data.Name = name;
                                }
                            }
                        }
                        
                        break;

                    //Edit Patient password
                    case 2:
                        Console.WriteLine("Reset Your password");
                        Console.Write("Enter New password:>> ");
                        string newpassword = Console.ReadLine();

                        foreach (var data in PatientList)
                        {
                            if (data.PatientId == CURRENT_USER_ID)
                            {
                                data.Password = newpassword;
                            }
                        }
                        break;

                    //Edit Patient Age
                    case 3:
                        Console.WriteLine("------Change your Age------");
                        Console.Write("Ente Your Age:>> ");
                        int age = int.Parse(Console.ReadLine());

                        foreach (var data in PatientList)
                        {
                            if (data.PatientId == CURRENT_USER_ID)
                            {
                                data.Age = age;
                            }
                        }
                        break;

                    //Edit Patient Gender
                    case 4:
                        Console.WriteLine("-----Change your Gender-----");
                        Console.WriteLine("1.Male\n2.Female");
                        Console.Write("Choose:>> ");
                        Gender gender = (Gender)int.Parse(Console.ReadLine());

                        foreach (var data in PatientList)
                        {
                            if (data.PatientId == CURRENT_USER_ID)
                            {
                                data.Gender = gender;
                            }
                        }
                        break;
                    //Exit
                    case 5:
                        break;
                }
                do
                {
                    Console.Write("Continue Editing. (Y/N) :>> ");
                    UserOpt = char.Parse(Console.ReadLine().ToUpper());
                }
                while (UserOpt != 'Y' && UserOpt != 'N');
            }
            while (UserOpt != 'N');
        }


        /// <summary>
        /// Validate if the user is present or Not in the UsersList
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>

        public bool Validate(string userid, string pass)
        {
            foreach (Patient data in PatientList)
            {
                if (data.Name == userid && data.Password == pass)
                {
                    CURRENT_USER_ID = data.PatientId;
                    CURRENT_USER_NAME = data.Name;
                    return true;
                }
            }
            return false;
        }
    }
}
