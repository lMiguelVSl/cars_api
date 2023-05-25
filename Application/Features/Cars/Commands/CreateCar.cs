using cars_api.ApplicationDBContext;
using cars_api.Model;
using FluentValidation;
using MediatR;

namespace cars_api.Application.Features.Cars.Commands
{
    public class CreateCar
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }

            public class ExecuteValidator : AbstractValidator<Execute>
            {
                public ExecuteValidator()
                {
                    RuleFor(x => x.Name).NotEmpty();
                    RuleFor(x => x.Model).NotEmpty();
                    RuleFor(x => x.Year).NotEmpty();
                }
            }

            public class Handler : IRequestHandler<Execute>
            {
                private readonly CarContext _carContext;

                public Handler(CarContext carContext)
                {
                    _carContext = carContext;
                }

                public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
                {
                    var car = new Car()
                    {
                        Name = request.Name,
                        Model = request.Model,
                        Year = request.Year
                    };

                    _carContext.Add(car);
                    var value = await _carContext.SaveChangesAsync();
                    return value > 0 ? Unit.Value : throw new Exception("The car could not be added");
                }
            }
        }
    }

}
