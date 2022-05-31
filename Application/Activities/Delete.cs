using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete 
    {
        public class Command : IRequest{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            public readonly DataContext _Context;
            public Handler(DataContext context)
            {
                _Context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _Context.Activities.FindAsync(request.Id);
                _Context.Remove(activity);
                await _Context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}