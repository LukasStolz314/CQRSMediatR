using System;
using CQRSMediatR.Domain;
using MediatR;

namespace CQRSMediatR.Application.Query;

public record StudentGetByIdQuery(Int32 Id) : IRequest<Student?>;