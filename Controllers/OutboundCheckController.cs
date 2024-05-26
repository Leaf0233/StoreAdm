using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using StoreAdm.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StoreAdm.Services;
using BaseApi.Attributes;

namespace StoreAdm.Controllers
{
    [XgLogin]
    //[Permission(Prog = _Prog.Course)]
    public class OutboundCheckController : BaseCtrl
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
        public async Task<ContentResult> GetPage(DtDto dt)
        {
            return JsonToCnt(await new OutboundCheckRead().GetPageA(Ctrl, dt));
        }

        private OutboundCheckEdit EditService()
        {
            return new OutboundCheckEdit(Ctrl);
        }

        //讀取要修改的資料(Get Updated Json)
        [HttpPost]
        public async Task<ContentResult> GetUpdJson(string key)
        {
            return JsonToCnt(await EditService().GetUpdJsonA(key));
        }

        //新增(DB)
        public async Task<JsonResult> Create(string json)
        {
            var data = _Str.ToJson(json);

            return Json(await EditService().CreateA(data));
        }
        //修改(DB)
        public async Task<JsonResult> Update(string key, string json)
        {
            var data = _Str.ToJson(json);
            var row = _Json.GetRows0(data);
            row["Checker"] = _Fun.UserId();
            row["CheckTime"] = _Date.NowDbStr();
            return Json(await EditService().UpdateA(key, data));
        }

        //刪除(DB)
        public async Task<JsonResult> Delete(string key)
        {
            return Json(await EditService().DeleteA(key));
        }

 /*       public async Task Export(string find)
    {
           await new OutboundRead().ExportAsync(_Str.ToJson(find));
        }

        //generate database document in word type
        //[HttpPost]
        public async Task GenWord(string keys)
        {
            var tableIds = keys.Split(',');
            await new GenDocuService().RunA("", tableIds);
        }*/

        /*
        [HttpPost]
        public async Task<ContentResult> GetViewJson(string key)
        {
            return JsonToCnt(await EditService().GetViewJsonAsync(key));
        }

        public JsonResult SetStatus(string key, bool status)
        {
            return Json(_Db.SetRowStatus("dbo.[Table]", "Id", key, status));
        }
        */

    }//class
}