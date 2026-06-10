namespace EmployeeLeaveRequest.DTOs
{
    public class LeaveRequestCreateDto
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeEmail { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string LeaveType { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
