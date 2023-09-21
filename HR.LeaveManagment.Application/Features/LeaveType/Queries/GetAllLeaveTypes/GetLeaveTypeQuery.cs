using MediatR;
using System.Collections.Generic;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;
}
