using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseApi.Services;
using BaseApi.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAdm.Services;
using System.Threading.Tasks;

namespace StoreAdm.Controllers
{
    //[XgProgAuth]
    public class ItemController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            ViewBag.ItemTypes = await _XpCode.ItemTypesA();
            ViewBag.Makers = await _XpCode.MakersA();
            return View();
        }

        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new ItemRead().GetPageA(Ctrl, dt));
        }

        private ItemEdit EditService()
        {
            return new ItemEdit(Ctrl);
        }

        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            //_Fun.Except();
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

    }//class
}