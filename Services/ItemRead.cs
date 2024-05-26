using Base.Enums;
using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace StoreAdm.Services
{
    public class ItemRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select i.Name, t.Name as TypeName,
    i.Unit, 
    m.Name as MakerName,
    i.Id
from dbo.Item i
join dbo.Maker m on i.MakerId=m.Id
join dbo.ItemType t on i.TypeId=t.Id
order by i.Id",

            TableAs = "i",
            //2.set query fields
            Items = new QitemDto[] {
                new() { Fid = "TypeId", Col = "t.Id" },
                new() { Fid = "MakerId", Col = "m.Id"},
                new() { Fid = "Name", Op = ItemOpEstr.Like2 },
            },
        };

        public async Task<JObject> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(dto, dt, ctrl);
        }

    } //class
}