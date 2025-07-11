
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.Activities.Queries;
using Application.Activities.Commands;
using Domain;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //   public class ActivitiesController(AppDbContext context, IMediator mediator) : BaseApiController

    // public class ActivitiesController(IMediator mediator) : BaseApiController
    public class ActivitiesController : BaseApiController
    {

        // private readonly AppDbContext _context;

        // public ActivitiesController(AppDbContext context)
        // {
        //     _context = context;
        // }


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            // var activities = await context.Activities.ToListAsync();
            // return Ok(activities);

            // return await mediator.Send(new GetActivityList.Query());

            return await Mediator.Send(new GetActivityList.Query());

            // .ContinueWith(task => 
            // {
            //     if (task.IsFaulted)
            //     {
            //         return StatusCode(StatusCodes.Status500InternalServerError, task.Exception?.Message);
            //     }
            //     return Ok(task.Result);
            // }); 
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            // var activity = await context.Activities.FindAsync(id);
            // if (activity == null) return NotFound();
            // return Ok(activity);


            // return await mediator.Send(new GetActivityDetails.Query { Id = id });
            return await Mediator.Send(new GetActivityDetails.Query { Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<String>> CreateActivity(Activity activity)
        {
            // context.Activities.Add(activity);
            // await context.SaveChangesAsync();
            // return CreatedAtAction(nameof(GetActivity), new { id = activity.Id }, activity);

            return await Mediator.Send(new CreateActivity.Command { Activity = activity });
        }


        [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command { Activity = activity });
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id });
            return Ok();
        }
    }



}
