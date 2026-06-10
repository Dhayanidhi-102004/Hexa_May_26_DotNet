using EmployeeLeaveRequest.Context;
using EmployeeLeaveRequest.DTOs;
using EmployeeLeaveRequest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveRequest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveRequestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("leaverequests")]
        public IActionResult CreateLeaveRequest([FromBody] LeaveRequestCreateDto leave)
        {
            var request = new LeaveRequest
            {
                EmployeeName = leave.EmployeeName,
                EmployeeEmail = leave.EmployeeEmail,
                MobileNumber = leave.MobileNumber,
                LeaveType = leave.LeaveType,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                TotalDays = (leave.EndDate.DayNumber - leave.StartDate.DayNumber) + 1,
                Status = "Pending",
                CreatedOn = DateTime.Now
            };

            _context.LeaveRequests.Add(request);
            _context.SaveChanges();

            return Ok(request);
        }

        [HttpGet("leaverequests")]
        public IActionResult GetLeaveRequest()
        {
            var requests = _context.LeaveRequests.ToList();

            return Ok(requests);
        }
        [HttpGet("{id}")]
        public IActionResult GetLeaveRequestById(int id)
        {
            var request = _context.LeaveRequests.FirstOrDefault(x => x.LeaveRequestId == id);

            if (request == null)
            {
                return NotFound($"Leave Request with Id {id} not found.");
            }

            return Ok(request);
        }
    }
}