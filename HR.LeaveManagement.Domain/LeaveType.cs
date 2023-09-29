﻿using HR.LeaveManagement.Domain.Common;

namespace HRLeaveManagementDomain
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
