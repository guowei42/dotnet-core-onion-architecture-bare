using Domain;
using MediatR;
using Persistence;

namespace Application.WeatherForecasts
{
    public class Create
    {
        public class Command: IRequest
        {
            public WeatherForecast WeatherForecast { get; set; }
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
                _context.WeatherForecasts.Add(request.WeatherForecast);
                await _context.SaveChangesAsync();
            }
        }
    }

    
}
