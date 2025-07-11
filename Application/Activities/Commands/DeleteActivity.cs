using System;
using MediatR;
using Domain;
using Persistence;
using AutoMapper;

namespace Application.Activities.Commands;


public class DeleteActivity
{
    public class Command : IRequest
    {
        // public required Activity Activity { get; set; }
        public required string Id { get; set; }

    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {

            var activity = await context.Activities.FindAsync([request.Id], cancellationToken)
            ?? throw new Exception("cannot find activity");
            // activity.Title = request.Activity.Title;
            //mapper.Map(request.Activity, activity);
            context.Remove(activity);
            await context.SaveChangesAsync(cancellationToken);
            
        }
    }

}

