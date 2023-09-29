using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationsDetailsDto>
    {
        public int Id { get; set; }
    }
}
