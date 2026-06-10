using EmployeeLeaveRequest.DTOs;
using FluentValidation;

namespace EmployeeLeaveRequest.Validations
{
    public class LeaveRequestResponseValidation : AbstractValidator<LeaveRequestResponseDto>
    {
        public LeaveRequestResponseValidation()
        {
            RuleFor(x => x.LeaveRequestId)
                .GreaterThan(0);

            RuleFor(x => x.EmployeeName)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.EmployeeEmail)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.LeaveType)
                .NotEmpty();

            RuleFor(x => x.StartDate)
                .NotEmpty();

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate);

            RuleFor(x => x.Reason)
                .NotEmpty();

            RuleFor(x => x.TotalDays)
                .GreaterThan(0);

            RuleFor(x => x.Status)
                .NotEmpty();

            RuleFor(x => x.CreatedOn)
                .NotEmpty();
        }
    }
}