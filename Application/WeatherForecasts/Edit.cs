using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WeatherForecasts
{
    public class Edit
    {
        public class Command : IRequest
        {
            public WeatherForecast WeatherForecast { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var weatherForecast = await _context.WeatherForecasts.FindAsync(request.WeatherForecast.Id);

                _mapper.Map(request.WeatherForecast, weatherForecast);

                await _context.SaveChangesAsync();

            }
        }
    }
}
