using Domain;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WeatherForecasts
{
    public class List
    {
        public class Query : IRequest<List<WeatherForecast>> { }

        public class Handler : IRequestHandler<Query, List<WeatherForecast>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<WeatherForecast>> Handle(Query request, CancellationToken cancellation)
            {
                return await _context.WeatherForecasts.ToListAsync();
            }
        }
    }
}
