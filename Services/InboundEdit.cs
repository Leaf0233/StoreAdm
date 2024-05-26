using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;

namespace StoreAdm.Services
{
    public class InboundEdit : BaseEditSvc
    {
        public InboundEdit(string ctrl) : base(ctrl) { }


        override public EditDto GetDto()
        {
            var locale = _Xp.GetLocale0();
            return new EditDto
            {
                Table = "dbo.Inbound",
                FnGetNewKeyA = _Xp.GetInboundIdA,
                ReadSql = $@"
select i.*,
    StatusName=c.Name_{locale},
    CreatorName=u.Name,
    {_Fun.FidUser}=u.Id, {_Fun.FidDept}=u.DeptId
from dbo.Inbound i
join dbo.[User] u on i.Creator=u.Id
join dbo.XpCode c on c.Type='Status' and i.Status=c.Value
where i.Id=@Id
",
                PkeyFid = "Id",
                Col4 = new string[] { "Creator", "Created" },
                Items = new EitemDto[] {
                    new() { Fid = "Id" },
                    new() { Fid = "Status" },
                    //new() { Fid = "Creator" },
                    //new() { Fid = "Created" },
                },
                Childs = new EditDto[]
                {
                    new()
                    {
                        Table = "dbo.InboundItem",
                        ReadSql = $@"
select ii.*,
    ItemName=i.Name, i.TypeId
from dbo.InboundItem ii
inner join dbo.Item i on ii.ItemId=i.Id
where ii.InboundId=@Id
",
                        PkeyFid = "Id",
                        FkeyFid = "InboundId",
                        Col4 = null,
                        Items = new EitemDto[] {
                            new() { Fid = "Id" },
                            new() { Fid = "InboundId" },
                            new() { Fid = "ItemId" },
                            new() { Fid = "Amount" },

                        },
                    },
                },
            };
        
        }

    } //class
}
