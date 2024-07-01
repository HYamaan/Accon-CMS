﻿using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Testimonal.GetAllTestimonal;

public class GetAllTestimonalQueryRequest : IRequest<ResponseModel<GetAllTestimonalQueryResponse>>
{
}