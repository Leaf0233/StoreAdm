using Base.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DbAdm.Services
{
    public class ItemService
    {
        public async Task<JArray> GetRowsAsync(string Name)
        {
            //if (_Str.IsEmpty(tableId) || !_Str.CheckKeyRule(tableId, "ColumnService.cs GetRows() tableId is wrong: " + tableId))
            if (_Str.IsEmpty(Name))
                return null;

            var sql = string.Format(@"
select 
    c.Id, c.Code, c.Name, c.DataType
from dbo.[Column] c
where c.TableId='{0}'
and c.Status=1
order by c.Sort
", Name);
            return await _Db.GetJsonsA(sql);
        }

    }//class
}