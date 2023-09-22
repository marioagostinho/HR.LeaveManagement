using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Verify that record exists
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            // Remove in database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // Return Unit value
            return Unit.Value;
        }

    }
}
