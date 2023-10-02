using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Logging;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Verify that record exists
            if (leaveTypeDetails == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            // Convert data objects to DTO
            var data = _mapper.Map<LeaveTypeDetailDto>(leaveTypeDetails);

            // Return list of DTO
            return data;
        }
    }
}
 