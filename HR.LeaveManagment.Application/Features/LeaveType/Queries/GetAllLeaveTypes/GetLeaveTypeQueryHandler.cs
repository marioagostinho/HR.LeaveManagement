﻿using AutoMapper;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery,
        List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // Convert data objects to DTO
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // Return list of DTO
            return data;
        }
    }
}
