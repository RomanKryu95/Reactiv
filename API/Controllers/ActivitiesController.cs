using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using MediatR;
using Application.Activities;
using System.Threading;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivties(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(),ct); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivty(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivty([FromBody]Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{Activity=activity}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditActivty(Guid id,[FromBody]Activity activity)
        {
            activity.Id=id;
            return Ok(await Mediator.Send(new Edit.Command{Activity=activity}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivty(Guid id)
        {
            
            return Ok(await Mediator.Send(new Delete.Command{Id=id}));
        }

    }
}