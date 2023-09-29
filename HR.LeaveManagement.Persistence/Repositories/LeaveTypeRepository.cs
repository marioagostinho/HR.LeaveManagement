using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagementDomain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(p => p.Name == name);
        }
    }
}
