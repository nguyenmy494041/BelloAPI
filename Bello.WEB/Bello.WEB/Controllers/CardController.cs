using Bello.WEB.Models.Request.Card;
using Bello.WEB.Models.Response.Card;
using Bello.WEB.Ultileties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/card/gets/{ListId}")]
        public JsonResult Gets (int ListId)
        {
            var result = ApiHelper<List<CardView>>.HttpGetAsync($"card/gets/{ListId}");
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/card/get/{id}")]
        public JsonResult Get(int id)
        {
            var result = ApiHelper<CardView>.HttpGetAsync($"card/get/{id}");
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/card/changestatus/{cardId}/{status}/{userId}")]
        public JsonResult ChangeStatus(int cardId, int status, string userId)
        {
            var result = ApiHelper<SaveCardRes>.HttpPostAsync($"card/changestatus/{cardId}/{status}/{userId}", "POST", new { cardId = cardId, status = status,userId = userId });
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/card/complete/{cardId}")]
        public JsonResult Complete(int cardId)
        {
            var result = ApiHelper<SaveCardRes>.HttpPostAsync($"card/complete/{cardId}", "POST", new { cardId = cardId});
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/card/save")]
        public JsonResult Save([FromBody] SaveCardReq saveCardReq)
        {
            var result = ApiHelper<SaveCardRes>.HttpPostAsync($"card/save", "POST", saveCardReq);
            return Json(new { data = result });
        }

        [HttpPatch]
        [Route("/card/update")]
        public JsonResult Update([FromBody] UpdateCardReq updateCardReq)
        {
            var result = ApiHelper<SaveCardRes>.HttpPostAsync($"card/update", "PATCH", updateCardReq);
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/card/drapdrop")]
        public JsonResult Drapdrop([FromBody] DrapDropReq drapDropReq)
        {
            var result = ApiHelper<SaveCardRes>.HttpPostAsync($"card/drapdrop", "POST", drapDropReq);
            return Json(new { data = result });
        }

        [HttpPatch]
        [Route("/card/updatename")]
        public JsonResult UpdateName([FromBody] UpdateName updateName)
        {
            var result = ApiHelper<SaveCardRes>.HttpPostAsync($"card/update", "PATCH", updateName);
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/card/orderbyname/{listId}")]
        public JsonResult OrderByName(int listId)
        {
            var result = ApiHelper<List<CardView>>.HttpGetAsync($"card/orderbyname/{listId}");
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/card/orderbyduedate/{listId}")]
        public JsonResult OrderByDueDate(int listId)
        {
            var result = ApiHelper<List<CardView>>.HttpGetAsync($"card/orderbydudate/{listId}");
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/card/GetCardSaved")]
        public JsonResult GetCardSaved()
        {
            var result = ApiHelper<List<CardView>>.HttpGetAsync($"card/GetCardSaved");
            return Json(new { data = result });
        }




    }
}
