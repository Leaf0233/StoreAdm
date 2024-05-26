using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseApi.Services;
using BaseApi.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAdm.Services;
using System.Threading.Tasks;
using Base.Enums;

namespace StoreAdm.Controllers
{
    //[XgProgAuth]
    public class MakerController : BaseCtrl
    {
        [XgProgAuth(CrudEnum.Read)]
        public ActionResult Read()
        {
            return View();
        }

        [XgProgAuth(CrudEnum.Read)]
        [HttpPost]
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new MakerRead().GetPageA(Ctrl, dt));
        }

        private MakerEdit EditService()
        {
            return new MakerEdit(Ctrl);
        }

        [XgProgAuth(CrudEnum.Update)]
        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        [XgProgAuth(CrudEnum.View)]
        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

        [XgProgAuth(CrudEnum.Create)]
        [HttpPost]
        public async Task<JsonResult> Create(string json)
        {
            return Json(await EditService().CreateA(_Str.ToJson(json)));
        }

        [XgProgAuth(CrudEnum.Update)]
        [HttpPost]
        public async Task<JsonResult> Update(string key, string json)
        {
            //_Fun.Except();
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)));
        }

        [XgProgAuth(CrudEnum.Delete)]
        [HttpPost]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

    }//class
}