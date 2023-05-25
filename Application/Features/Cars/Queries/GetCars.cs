using AutoMapper;
using cars_api.ApplicationDBContext;
using cars_api.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cars_api.Application.Features.Cars.Queries
{
    public class GetCars
    {
        public class carList : IRequest<List<CarDTO>> { }
        public class Handler : IRequestHandler<carList, List<CarDTO>>
        {
            private readonly CarContext _carContext;
            private readonly IMapper _mapper;

            public Handler(CarContext carContext, IMapper mapper)
            {
                _carContext = carContext;
                _mapper = mapper;
            }

            public async Task<List<CarDTO>> Handle(carList request, CancellationToken cancellationToken)
            {
                var cars = await _carContext._Car.ToListAsync();
                var carsDTO = _mapper.Map<List<Car>, List<CarDTO>>(cars);
                return carsDTO;
            }
        }
    }
}
