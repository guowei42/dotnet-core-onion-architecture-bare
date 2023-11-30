using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Diagnostics;

namespace Application.WeatherForecasts
{
    public class List
    {
        public class Query : IRequest<Result<List<WeatherForecast>>> { }

        public class Handler : IRequestHandler<Query, Result<List<WeatherForecast>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<WeatherForecast>>> Handle(Query request, CancellationToken cancellation)
            {
                return Result<List<WeatherForecast>>.Success(await _context.WeatherForecasts.ToListAsync(cancellation));
            }
        }
    }
}
