using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bello.BAL.Interface;
using Bello.DAL.Implement;
using Bello.Domain.Request.List;
using Bello.Domain.Response.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bello.API.Controllers
{
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService ListService;
        private readonly UserManager<ApplicationUser> userManager;

        public ListController(IListService ListService)
        {
            this.ListService = ListService;
        }

        [HttpGet("api/list/gets/{boardId}")]
        public async Task<OkObjectResult> GetsList(int boardId)
        {
            var Lists = await ListService.Gets(boardId);
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

        [HttpPost("api/list/changestatus/{listId}/{status}/{userId}")]
        public async Task<OkObjectResult> ChangeStatus(int listId, int status,string userId)
        {
            var result = await ListService.ChangeStatus(listId,status, userId);
            return Ok(result);
        }
        [HttpPost("api/list/drapdroplist/{listId}/{positionNew}")]
        public async Task<OkObjectResult> Drapdrop(int listId, int positionNew)
        {
            var result = await ListService.DrapDropList(listId, positionNew);
            return Ok(result);
        }
        [HttpPost("api/list/moveAllList/{listIdBefore}/{listIdAfter}")]
        public async Task<OkObjectResult> MoveAllList(int listIdBefore, int listIdAfter)
        {
            var result = await ListService.MoveAllList(listIdBefore, listIdAfter);
            return Ok(result);
        }
        [HttpPost("api/list/StorageAllCard/{listId}")]
        public async Task<OkObjectResult> StorageAllCard(int listId)
        {
            var result = await ListService.StorageAllCard(listId);
            return Ok(result);
        }
        [HttpGet("api/list/GetListSaved")]
        public async Task<OkObjectResult> GetListSave()
        {
            var Lists = await ListService.GetListSave();
            return Ok(Lists);
        }
    }
}
