using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordSystem
{
    using System;
    using System.Collections.Generic;

    class Patient
    {
        public string Name;
        public int Age;
        public string Diagnosis;
        public bool IsPatientAdmited;
    }

    class PatientRecordSystem
    {
        private List<Patient> patientDetails = new List<Patient>(); // List to store patients

        public void AddNewPatient(string name, int age, string diagnosis, bool ispatientAdmited)
        {
            patientDetails.Add(new Patient { Name = name, Age = age, Diagnosis = diagnosis, IsPatientAdmited = ispatientAdmited });
        }

        public Patient SearchForPatient(string name)
        {
            foreach (var patient in patientDetails)
            {
                if (patient.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return patient; 
                }
            }
            return null; 
        }

        public void UpdateThePatient(string name, string diagnosis, bool ispatientAdmited)
        {
            Patient patient = SearchForPatient(name);
            if (patient != null)
            {
                patient.Diagnosis = diagnosis;
                patient.IsPatientAdmited = ispatientAdmited;
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        public void ListOfAdmittedPatients()
        {
            Console.WriteLine("Admitted Patients Are:");
            foreach (var patient in patientDetails)
            {
                if (patient.IsPatientAdmited)
                {
                    Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Diagnosis: {patient.Diagnosis}");
                }
                else
                {
                    Console.WriteLine("No patients are currently admitted.");
                }
            }
        }

        public void DisplayPatientDetails(Patient patient)
        {
            if (patient != null)
            {
                Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Diagnosis: {patient.Diagnosis}, Admitted: {patient.IsPatientAdmited}");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PatientRecordSystem system = new PatientRecordSystem();
            bool options = true;

            while (options)
            {
              Console.WriteLine("\nPatient Record System");
              Console.WriteLine("1. Add a New Patient");
              Console.WriteLine("2. Search Patient By Name");
              Console.WriteLine("3. Update Patient");
              Console.WriteLine("4. Show List of Admitted Patients");
              Console.WriteLine("5. Exit");
              Console.Write("Choose an option: ");
              string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add Patient
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Diagnosis: ");
                        string diagnosis = Console.ReadLine();
                        Console.Write("Is Admitted (true/false): ");
                        bool isPAdmitted = bool.Parse(Console.ReadLine());
                        system.AddNewPatient(name, age, diagnosis, isPAdmitted);
                        Console.WriteLine("Patient added successfully.");
                        break;

                    case "2":
                        // Search Patient
                        Console.Write("Enter Name to search: ");
                        string searchName = Console.ReadLine();
                        Patient foundPatient = system.SearchForPatient(searchName);
                        system.DisplayPatientDetails(foundPatient);
                        break;

                    case "3":
                        // Update Patient
                        Console.Write("Enter Name to update: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Enter new Diagnosis: ");
                        string newDiagnosis = Console.ReadLine();
                        Console.Write("Is Admitted (true/false): ");
                        bool newPatientIsAdmitted = bool.Parse(Console.ReadLine());
                        system.UpdateThePatient(updateName, newDiagnosis, newPatientIsAdmitted);
                        Console.WriteLine("Patient updated successfully.");
                        break;

                    case "4":
                        // List Admitted Patients
                        system.ListOfAdmittedPatients();
                        break;

                    case "5":
                        // Exit
                        options = false;
                        Console.WriteLine("Bye, Have a nice day/night ..Closing......");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again........");
                        break;
                }
            }
        }

    }
}