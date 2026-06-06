using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public partial class Appointment
    {
        public int totalTime()
        {
            return (int)(EndTime - StartTime).TotalMinutes;
        }
        public void changeStatus()
        {
            Status = "Cancelled";
        }
        public void displayAppointments(List<Appointment> appointments)
        {
            foreach (Appointment appointment in appointments)
            {
                Console.WriteLine($@"Id: {appointment.Id},
                                    Title: {appointment.Title},
                                    Description: {appointment.Description},
                                    Timing: {appointment.StartTime} to {appointment.EndTime},
                                    Location: {appointment.Location},
                                    Status: {appointment.Status}
                                    ------------------------------------");
            }
        }
        public void displayScheduled(List<Appointment> appointments)
        {
            var scheduled = appointments.Where(a => a.Status == "Confirmed");
            foreach (var appointment in scheduled)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                          $"Title: {appointment.Title}\n" +
                          $"Description: {appointment.Description}\n" +
                          $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                          $"Location: {appointment.Location}\n" +
                          $"Status: {appointment.Status}\n" +
                          $"Fees: {appointment.Fees}\n" +
                          "------------------------------------");
            }
        }
        public void DisplayCompleted(List<Appointment> appointments)
        { 
            var completed = appointments.Where(a => a.Status == "Completed" ||
                                                   (a.EndTime < DateTime.Now && a.Status != "Cancelled"));

            foreach (var appointment in completed)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                                  $"Title: {appointment.Title}\n" +
                                  $"Description: {appointment.Description}\n" +
                                  $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                                  $"Location: {appointment.Location}\n" +
                                  $"Status: {appointment.Status}\n" +
                                  $"Fees: {appointment.Fees}\n"+
                                  "------------------------------------");
            }
        }
        public void DisplayCardio(List<Appointment> appointments)
        {
            var completed = appointments.Where(a => a.Title == "Cardiology");

            foreach (var appointment in completed)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                                  $"Title: {appointment.Title}\n" +
                                  $"Description: {appointment.Description}\n" +
                                  $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                                  $"Location: {appointment.Location}\n" +
                                  $"Status: {appointment.Status}\n" +
                                  $"Fees: {appointment.Fees}\n" +
                                  "------------------------------------");
            }
        }
        public void DisplayConsultGrt500(List<Appointment> appointments)
        {
            var completed = appointments.Where(a => a.Fees > 500);

            foreach (var appointment in completed)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                                  $"Title: {appointment.Title}\n" +
                                  $"Description: {appointment.Description}\n" +
                                  $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                                  $"Location: {appointment.Location}\n" +
                                  $"Status: {appointment.Status}\n" +
                                  $"Fees: {appointment.Fees}\n" +
                                  "------------------------------------");
            }
        }
        public void DisplayPatient(List<Appointment> appointments,string name)
        {
            var completed = appointments.Where(a => a.PatientName==name);

            foreach (var appointment in completed)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                                  $"Title: {appointment.Title}\n" +
                                  $"Description: {appointment.Description}\n" +
                                  $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                                  $"Location: {appointment.Location}\n" +
                                  $"Status: {appointment.Status}\n" +
                                  $"Fees: {appointment.Fees}\n" +
                                  "------------------------------------");
            }
        }
        public void SortByDate(List<Appointment> appointments)
        {
            var sortBydate=appointments.OrderBy(a=>a.StartTime).ToList();
            foreach (var appointment in sortBydate)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                                  $"Title: {appointment.Title}\n" +
                                  $"Description: {appointment.Description}\n" +
                                  $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                                  $"Location: {appointment.Location}\n" +
                                  $"Status: {appointment.Status}\n" +
                                  $"Fees: {appointment.Fees}\n" +
                                  "------------------------------------");
            }
        }
        public void GroupByDepartment(List<Appointment> appointments)
        {
            var groupByDept = appointments.GroupBy(a => a.Title).ToList();

            foreach (var deptGroup in groupByDept)
            {
                Console.WriteLine($"\nDepartment: {deptGroup.Key}");
                Console.WriteLine("=====================================");

                foreach (var appointment in deptGroup)
                {
                    Console.WriteLine($"  -> ID: {appointment.Id} | {appointment.Description}");
                    Console.WriteLine($"     Time: {appointment.StartTime.ToShortTimeString()} | Fee: ₹{appointment.Fees}");
                    Console.WriteLine("  -----------------------------------");
                }
            }
        }
        public void CountByStatus(List<Appointment> appointments)
        {
            var groupedByStatus = appointments.GroupBy(a => a.Status).ToList();

            foreach (var statusGroup in groupedByStatus)
            {
                Console.WriteLine($"\nStatus: {statusGroup.Key} (Total: {statusGroup.Count()})");
                Console.WriteLine("=====================================");

                foreach (var appointment in statusGroup)
                {
                    Console.WriteLine($"  -> ID: {appointment.Id} | {appointment.Description}");
                    Console.WriteLine($"     Time: {appointment.StartTime.ToShortTimeString()} | Fee: ₹{appointment.Fees}");
                    Console.WriteLine("  -----------------------------------");
                }
            }
        }
        public void CalculateRevenue(List<Appointment> appointments)
        {
            decimal totalRevenue = appointments
            .Where(a => a.Status == "Completed" || (a.EndTime < DateTime.Now && a.Status != "Cancelled"))
            .Sum(a => a.Fees);

            Console.WriteLine($"\n=====================================");
            Console.WriteLine($"Total Revenue from Completed Sessions: ₹{totalRevenue:N2}");
            Console.WriteLine($"=====================================");
        }
        public void CalculateAvg(List<Appointment> appointments)
        {
            var activeAppointments = appointments.Where(a => a.Status != "Cancelled");

            if (!activeAppointments.Any()) return;
            decimal average = appointments.Average(a => a.Fees);
            Console.WriteLine($"\n=====================================");
            Console.WriteLine($"Average Revenue: ₹{average:N2}");
            Console.WriteLine($"=====================================");
        }
        public void DisplayUpcoming(List<Appointment> appointments)
        {
            var upcoming= appointments.Where(a=>a.StartTime < DateTime.Now).ToList();
            foreach (var appointment in upcoming)
            {
                Console.WriteLine($"Id: {appointment.Id}\n" +
                                  $"Title: {appointment.Title}\n" +
                                  $"Description: {appointment.Description}\n" +
                                  $"Timing: {appointment.StartTime} to {appointment.EndTime}\n" +
                                  $"Location: {appointment.Location}\n" +
                                  $"Status: {appointment.Status}\n" +
                                  $"Fees: {appointment.Fees}\n" +
                                  "------------------------------------");
            }
        }
    }
}
