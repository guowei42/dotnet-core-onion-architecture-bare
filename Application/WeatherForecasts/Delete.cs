using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.WeatherForecasts
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var weatherForecast = await _context.WeatherForecasts.FindAsync(request.Id);

                _context.Remove(weatherForecast);

                await _context.SaveChangesAsync();

            }
        }
    }
}
