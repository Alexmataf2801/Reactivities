using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest{
            public Activity Activity { get; set; }
        }

         public class Handler : IRequestHandler<Command>
        {
             public readonly DataContext _Context;
            public readonly IMapper _Mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _Mapper = mapper;
                _Context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _Context.Activities.FindAsync(request.Activity.Id);
                activity.Title = request.Activity.Title ?? activity.Title; 

                _Mapper.Map(request.Activity,activity);

                await _Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}