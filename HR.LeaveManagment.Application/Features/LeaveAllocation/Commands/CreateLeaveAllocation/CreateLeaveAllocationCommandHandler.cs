using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper, 
            ILeaveAllocationRepository leaveAllocationRepository, 
            ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validatonResult = await validator.ValidateAsync(request);

            if (validatonResult.IsValid == false)
                throw new BadRequestException("Invalid Leave Allocation Request", validatonResult);

            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

            var allocations = new List<HRLeaveManagementDomain.LeaveAllocation>();
            await _leaveAllocationRepository.AddAllocations(allocations);

            return Unit.Value;
        }
    }
}
