﻿using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WeatherForecasts
{
    public class Details
    {
        public class Query : IRequest<WeatherForecast>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, WeatherForecast>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<WeatherForecast> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.WeatherForecasts.FindAsync(request.Id);
            }
        }
    }
}