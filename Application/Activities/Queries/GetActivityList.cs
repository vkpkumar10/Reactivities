using System;
using Domain;
using MediatR;
using Persistence;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Queries;

public class GetActivityList
{
    public class Query : IRequest<List<Domain.Activity>>
    {
    }

    public class Handler(AppDbContext dbContext) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Domain.Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await dbContext.Activities
                .ToListAsync(cancellationToken);
        }


    }
}
