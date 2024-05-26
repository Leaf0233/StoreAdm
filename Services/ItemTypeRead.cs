using Base.Models;
using Base.Services;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace StoreAdm.Services
{
    public class ItemTypeRead
    {
        private readonly ReadDto dto = new()
        {
            ReadSql = @"
select * from dbo.ItemType
order by Id
",
        };

        public async Task<JObject> GetPageA(string ctrl, DtDto dt)
        {
            return await new CrudReadSvc().GetPageA(dto, dt, ctrl);
        }

    } //class
}