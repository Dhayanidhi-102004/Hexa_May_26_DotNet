using EmployeeLeaveRequest.DTOs;
using FluentValidation;

namespace EmployeeLeaveRequest.Validations
{
    public class LeaveRequestCreateValidation : AbstractValidator<LeaveRequestCreateDto>
    {
        public LeaveRequestCreateValidation()
        {
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Employee Name is required.")
                .Length(3, 100).WithMessage("Name length must be between 3 and 100 characters.");

            RuleFor(x => x.EmployeeEmail)
                .NotEmpty().WithMessage("Employee Email is required.")
                .EmailAddress().WithMessage("Invalid Email format.");

            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile Number is required.")
                .Matches(@"^[6-9]\d{9}$")
                .WithMessage("Mobile Number must be a valid 10-digit Indian mobile number.");

            RuleFor(x => x.LeaveType)
                .NotEmpty().WithMessage("Leave Type is required.")
                .Must(type => new[] { "Sick", "Casual", "Earned" }.Contains(type))
                .WithMessage("Leave Type must be Sick, Casual, or Earned.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start Date is required.")
                .Must(date => date > DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Start Date must be a future date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End Date must be greater than or equal to Start Date.");

            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason for leave is required.")
                .Length(10, 250)
                .WithMessage("Reason must be between 10 and 250 characters.");
        }
    }
}