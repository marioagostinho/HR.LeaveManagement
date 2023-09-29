using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagementDomain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(p => p.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests.Where(p => p.RequestingEmployeeId == userId)
                .Include(p => p.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = _context.LeaveRequests
                .Include(p => p.LeaveType)
                .FirstOrDefaultAsync(p => p.Id == id);

            return leaveRequest;
        }
    }
}
