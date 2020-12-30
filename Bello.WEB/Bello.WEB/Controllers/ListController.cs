using Bello.WEB.Models.Request.List;
using Bello.WEB.Models.Response.List;
using Bello.WEB.Ultileties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Controllers
{
    public class ListController: Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        [Route("/list/gets/{boardId}")]
        public JsonResult Gets(int boardId)
        {
            var lists = ApiHelper<List<ListView>>.HttpGetAsync($"list/gets/{boardId}");
            return Json(new { data = lists });
        }

        [HttpGet]
        [Route("/list/get/{listId}")]
        public JsonResult Get(int listId)
        {
            var list = ApiHelper<ListView>.HttpGetAsync($"list/get/{listId}");
            return Json(new { data = list });
        }
        [HttpPost,HttpPatch]
        [Route("/list/save")]
        public JsonResult SaveList([FromBody] SaveListReq saveListReq)
        {
            var result = ApiHelper<SaveListRes>.HttpPostAsync($"list/save", "POST", saveListReq);
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/list/changestatus/{listId}/{status}/{userId}")]
        public JsonResult ChangeStatus (int listId, int status,string userId)
        {
            var result = ApiHelper<SaveListRes>.HttpPostAsync($"list/changestatus/{listId}/{status}/{userId}", "POST", new {listId = listId, status = status,userId = userId});
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/list/drapdroplist/{listId}/{positionNew}")]
        public JsonResult Drapdrop(int listId, int positionNew)
        {
            var result = ApiHelper<SaveListRes>.HttpPostAsync($"list/drapdroplist/{listId}/{positionNew}", "POST", new {listId = listId, positionNew = positionNew});
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/list/moveAllList/{listIdBefore}/{listIdAfter}")]
        public JsonResult MoveAllList(int listIdBefore, int listIdAfter)
        {
            var result = ApiHelper<SaveListRes>.HttpPostAsync($"list/moveAllList/{listIdBefore}/{listIdAfter}", "POST", new { listIdBefore = listIdBefore, listIdAfter = listIdAfter });
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("list/StorageAllCard/{listId}")]
        public JsonResult StorageAllCard(int listId)
        {
            var result = ApiHelper<SaveListRes>.HttpPostAsync($"list/StorageAllCard/{listId}", "POST", new { listId = listId});
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/list/GetListSaved")]
        public JsonResult GetListSave()
        {
            var result = ApiHelper<List<ListView>>.HttpGetAsync($"list/GetListSaved");
            return Json(new { data = result });
        }


    }
}
