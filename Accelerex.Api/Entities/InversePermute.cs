using MediatR;

namespace Accelerex.Api.Entities;

public record InversePermute(int[] payload): IRequest<int[]>;