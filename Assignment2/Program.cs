using System;
using System.Collections.Generic;

namespace Assignment2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Appointment> appointments = new List<Appointment>()
            {
                new Appointment
                {
                    Id = 101,
                    PatientName = "Ramesh Kumar",
                    Title = "General Physician",
                    Description = "Regular Health Checkup",
                    StartTime = DateTime.Parse("2026-06-02 12:30:00"),
                    EndTime = DateTime.Parse("2026-06-02 15:00:00"),
                    Location = "Apollo Hospital, Chennai",
                    Status = "Pending",
                    Fees = 500.00m
                },
                new Appointment
                {
                    Id = 102,
                    PatientName = "Priya Sharma",
                    Title = "Cardiology",
                    Description = "Heart health and ECG presentation",
                    StartTime = DateTime.Parse("2026-06-03 10:00:00"),
                    EndTime = DateTime.Parse("2026-06-03 11:30:00"),
                    Location = "Fortis Malar, Chennai",
                    Status = "Confirmed",
                    Fees = 1200.00m
                },
                new Appointment
                {
                    Id = 103,
                    PatientName = "Suresh Raina",
                    Title = "Physiotherapy",
                    Description = "Cardio and physical posture training",
                    StartTime = DateTime.Parse("2026-06-03 17:00:00"),
                    EndTime = DateTime.Parse("2026-06-03 18:00:00"),
                    Location = "Cult Fit Rehab, Chennai",
                    Status = "Pending",
                    Fees = 800.00m
                }
            };

            Appointment processor = new Appointment();

            Console.WriteLine("=== ALL APPOINTMENTS ===");
            processor.displayAppointments(appointments);

            Console.WriteLine("\n=== CONFIRMED/SCHEDULED APPOINTMENTS ===");
            processor.displayScheduled(appointments);

            Console.WriteLine("\n=== COMPLETED APPOINTMENTS ===");
            processor.DisplayCompleted(appointments);

            Console.WriteLine("\n=== CARDIOLOGY DEPT APPOINTMENTS ===");
            processor.DisplayCardio(appointments);

            Console.WriteLine("\n=== CONSULTATIONS WITH FEES GREATER THAN 500 ===");
            processor.DisplayConsultGrt500(appointments);

            Console.WriteLine("\n=== APPOINTMENTS FOR PATIENT: Priya Sharma ===");
            processor.DisplayPatient(appointments, "Priya Sharma");

            Console.WriteLine("\n=== UPCOMING APPOINTMENTS ===");
            processor.DisplayUpcoming(appointments);

            Console.WriteLine("\n=== APPOINTMENTS SORTED BY DATE & TIME ===");
            processor.SortByDate(appointments);

            Console.WriteLine("\n=== SUMMARY BREAKDOWN BY DEPARTMENT ===");
            processor.GroupByDepartment(appointments);

            Console.WriteLine("\n=== TOTAL COUNTS BY WORKING STATUS ===");
            processor.CountByStatus(appointments);

            Console.WriteLine("\n=== FINANCIAL ANALYSIS METRICS ===");
            processor.CalculateRevenue(appointments);
            processor.CalculateAvg(appointments);

            Console.WriteLine("\n=== RUNNING OPERATIONAL INSTANCE ACTIONS ===");
            Appointment singleApp = appointments[0];

            Console.WriteLine($"Original Status of ID {singleApp.Id}: {singleApp.Status}");
            Console.WriteLine($"Estimated Duration: {singleApp.totalTime()} minutes.");

            singleApp.changeStatus();
            Console.WriteLine($"Updated Status of ID {singleApp.Id}: {singleApp.Status}");

            Console.ReadLine();
        }
    }
}