using AutoMapper;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data

            // Convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<HRLeaveManagementDomain.LeaveType>(request);

            // add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            // return record id
            return leaveTypeToCreate.Id;
        }
    }
}
