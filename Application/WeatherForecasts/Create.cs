using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.WeatherForecasts
{
    public class Create
    {
        public class Command: IRequest<Result<Unit>>
        {
            public WeatherForecast WeatherForecast { get; set; }
        }
        
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.WeatherForecast).SetValidator(new WeatherForecastsValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.WeatherForecasts.Add(request.WeatherForecast);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create weather forecast");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }

    
}
