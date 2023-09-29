
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : IRequest<Unit>
    {
        public string RequestComments { get; set; } = string.Empty;
    }
}
