using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.WeatherForecasts
{
    public class Details
    {
        public class Query : IRequest<Result<WeatherForecast>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<WeatherForecast>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<WeatherForecast>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.WeatherForecasts.FindAsync(request.Id);
                return Result<WeatherForecast>.Success(activity);
            }
        }
    }
}
