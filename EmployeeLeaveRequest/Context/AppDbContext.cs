using System.Collections.Generic;
using EmployeeLeaveRequest.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveRequest.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}