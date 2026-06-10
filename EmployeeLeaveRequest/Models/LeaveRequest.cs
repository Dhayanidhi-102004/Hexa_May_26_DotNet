namespace EmployeeLeaveRequest.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public string EmployeeName { get; set; }= string.Empty;
        public string EmployeeEmail { get; set; }= string.Empty;
        public string MobileNumber { get; set; }= string.Empty;
        public string LeaveType { get; set; }= string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
