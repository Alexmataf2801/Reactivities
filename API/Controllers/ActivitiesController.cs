using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            return await mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
            return await mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult>CreateActivity(Activity activity){
            return Ok(await mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>EditActivity(Guid Id, Activity activity){
            activity.Id = Id;
            return Ok(await mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteActivity(Guid id){
            return Ok(await mediator.Send(new Delete.Command{Id = id}));
        }

    }
}