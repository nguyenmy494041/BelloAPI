using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bello.BAL.Interface;
using Bello.Domain.Request.List;
using Bello.Domain.Response.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bello.API.Controllers
{
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService ListService;

        public ListController(IListService ListService)
        {
            this.ListService = ListService;
        }

        [HttpGet("api/list/gets")]
        public async Task<OkObjectResult> GetsList()
        {
            var Lists = await ListService.Gets();
            return Ok(Lists);
        }
        [HttpGet("api/list/get/{id}")]
        public async Task<OkObjectResult> GetList(int id)
        {
            var List = await ListService.Get(id);
            if (List.ListId == 0)
                return Ok(new SaveListRes()
                {
                    ListId = 0,
                    Message = "Something went wrong, please try again later!"
                });
            return Ok(List);
        }
        [HttpPost, HttpPatch]
        [Route("api/list/save")]
        public async Task<OkObjectResult> SaveCourse(SaveListReq request)
        {
            var result = await ListService.Save(request);
            return Ok(result);
        }

        [HttpPost("api/list/changestatus/{listId}/{status}")]
        public async Task<OkObjectResult> ChangeStatus(int listId, int status)
        {
            var result = await ListService.ChangeStatus(listId,status);
            return Ok(result);
        }
    }
}
