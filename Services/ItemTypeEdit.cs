using Base.Models;
using Base.Services;
using BaseWeb.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace StoreAdm.Services
{
    public class ItemTypeEdit : BaseEditSvc
    {
        public ItemTypeEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
                Table = "dbo.ItemType",
                ReadSql = @"
select i.*,
    CreatorName=u.Name,
    ReviserName=u2.Name
from dbo.ItemType i
left join dbo.[User] u on i.Creator=u.Id
left join dbo.[User] u2 on i.Reviser=u2.Id
where i.Id=@Id
",
                PkeyFid = "Id",
                AutoIdLen = _Fun.AutoIdShort,
                // Col4 = null,
                Items = new EitemDto[]
                {
                    new() { Fid = "Id" },
                    new() { Fid = "Name", Required = true },
               },
            };
        }

        public async Task<ResultDto> CreateA(JObject json)
        {
            return await EditService().CreateA(json);
        }

        public async Task<ResultDto> UpdateA(string key, JObject json)
        {
            return await EditService().UpdateA(key, json);
        }

    } //class
}
