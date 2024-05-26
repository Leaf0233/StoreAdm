using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using StoreAdm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using StoreAdm.Services;
using BaseApi.Attributes;
using Base.Enums;
using System.Diagnostics;

namespace StoreAdm.Controllers
{
    [XgLogin]
    //[Permission(Prog = _Prog.Course)]
    public class OutboundController : BaseCtrl
    {
        public async Task<ActionResult> Read()
        {
            ViewBag.ItemTypes = await _XpCode.ItemTypesA();
            ViewBag.CheckStatuses = await _XpCode.GetCheckStatusesA();
            ViewBag.Statuses = await _XpCode.GetStatusesA();
            ViewBag.ItemExtStrs = _Model.ListToJsonStr<IdStrExtDto>(await _XpCode.ItemExtsA());
            //ViewBag.Items = await _XpCode.ItemsA();
            //test
            //_Fun.Except("exception test");

            //ViewBag.Projects = await _XpCode.ProjectsA(); //dropdown
            //ViewBag.YesNos = _XpCode.YesNos();
            return View();
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.Read)]

        public async Task<ContentResult> GetPage(DtDto dt)
             {
            return JsonToCnt(await new OutboundRead().GetPageA(Ctrl, dt));
        }

        private OutboundEdit EditService()
        {
            return new OutboundEdit(Ctrl);
        }

        //讀取要修改的資料(Get Updated Json)
        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        //新增(DB)
        [HttpPost]
        [XgProgAuth(CrudEnum.Create)]
        public async Task<JsonResult> Create(string json)
        {
            var data = _Str.ToJson(json);

            return Json(await EditService().CreateA(data));
        }
        //修改(DB)
        [HttpPost]
        [XgProgAuth(CrudEnum.Update)]
        public async Task<JsonResult> Update(string key, string json)
        {
            return Json(await EditService().UpdateA(key, _Str.ToJson(json)));
        }

        //刪除(DB)
        [HttpPost]
        [XgProgAuth(CrudEnum.Delete)]
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

        [HttpPost]
        [XgProgAuth(CrudEnum.View)]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonA(key));
        }

    }//class
}