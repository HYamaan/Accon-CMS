﻿using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TeamMemberSection.Designation.UpdateDesignation;

public class UpdateDesignationCommandRequest : IRequest<ResponseModel<UpdateDesignationCommandResponse>>
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
}