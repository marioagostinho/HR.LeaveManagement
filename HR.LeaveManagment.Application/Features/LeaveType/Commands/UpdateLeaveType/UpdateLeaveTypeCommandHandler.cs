using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Logging;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, IAppLogger<UpdateLeaveTypeCommandHandler> logger, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid == false) 
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);

                throw new BadRequestException("Invalid Leave Type", validationResult);
            }

            // Convert to domain entity object
            var leaveTypeToUpdate = _mapper.Map<HRLeaveManagementDomain.LeaveType>(request);

            // Update in database
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            // Return Unit value
            return Unit.Value;
        }
    }
}
