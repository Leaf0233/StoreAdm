using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace StoreAdm.Services
{
    public class OutboundRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select o.*,
    '' as _Fun
from dbo.Outbound o
join dbo.[User] u on o.Creator=u.Id
order by o.Created desc
",

            TableAs = "o",
            Items = new QitemDto[] {
                new() { Fid = "Created" },
                new() { Fid = "Creator", Op = ItemOpEstr.Like2 },
                new() { Fid = "TakeTime" },
                new() { Fid = "CheckStatus" },
            },
        };

        public async Task<JObject> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(dto, dt, ctrl);
        }

        /// <summary>
        /// export excel
        /// </summary>
        /// <param name="ctrl">controller name for authorize</param>
        /// <param name="find"></param>
        /// <returns></returns>
 /*       public async Task ExportAsync(JObject find)
        {
            await _WebExcel.ExportByReadA("", dto, find, 
                "Table.xlsx", _Xp.GetTplPath("Table.xlsx", true), 1);
        }*/

    } //class
}
