using FluentValidation;
using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using HR.LeaveManagment.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveRequestRepository = leaveRequestRepository;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveRequestMustExist).WithMessage("{PropertName} must be present");
        }

        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveAllocation != null;
        }
    }
}
