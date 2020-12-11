using Bello.WEB.Models.Request.Board;
using Bello.WEB.Models.Response.Board;
using Bello.WEB.Ultileties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("board/gets")]
        public JsonResult Gets()
        {
            var result = ApiHelper<List<BoardView>>.HttpGetAsync($"board/gets");
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("board/get/{id}")]
        public JsonResult Get(int id)
        {
            var result = ApiHelper<BoardView>.HttpGetAsync($"board/get/{id}");
            return Json(new { data = result });
        }

        [HttpPost,HttpPatch]
        [Route("board/save")]
        public JsonResult Save([FromBody] SaveBoardReq saveBoardReq)
        {
            var result = ApiHelper<SaveBoardRes>.HttpPostAsync($"board/save", "POST", saveBoardReq);
            return Json(new { data = result });      
        }

        [HttpPost]
        [Route("board/changestatus/{boardId}/{status}/{userId}")]
        public JsonResult ChangeStatus(int boardId, int status,string userId)
        {
            var result = ApiHelper<SaveBoardRes>.HttpPostAsync($"board/changestatus/{boardId}/{status}/{userId}", "POST", new { boardId = boardId, status = status, userId = userId });
            return Json(new { data = result });
        }
    }
}
