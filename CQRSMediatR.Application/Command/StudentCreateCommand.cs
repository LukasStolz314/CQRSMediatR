using System;
using MediatR;

namespace CQRSMediatR.Application.Command;

public record StudentCreateCommand(String Name, Int32 Age) : IRequest;