using Base.Enums;
using Base.Models;
using Base.Services;
using BaseWeb.Services;

namespace StoreAdm.Services
{
    public class OutboundCheckEdit : BaseEditSvc
    {
        public OutboundCheckEdit(string ctrl) : base(ctrl) { }


        override public EditDto GetDto()
        {
            var locale = _Xp.GetLocale0();
            return new EditDto
            {
                Table = "dbo.Outbound",
                FnGetNewKeyA = _Xp.GetOutboundIdA,
                ReadSql = $@"
select o.*,
    StatusName=c.Name_{locale},
	CheckStatusName=c2.Name_{locale},
    CreatorName=u.Name,
    {_Fun.FidUser}=u.Id, {_Fun.FidDept}=u.DeptId
from dbo.Outbound o
join dbo.[User] u on o.Creator=u.Id
join dbo.XpCode c on c.Type='Status' and o.Status=c.Value
join dbo.XpCode c2 on c2.Type='CheckStatus' and o.CheckStatus=c2.Value
where o.Id=@Id
",
                PkeyFid = "Id",
                Col4 = new string[] { "Creator", "Created" },
                Items = new EitemDto[] {
                    new() { Fid = "Id" },
                    new() { Fid = "CheckStatus" },
                    new() { Fid = "Checker" },
                    new() { Fid = "CheckNote" },
                    new() { Fid = "CheckTime" },
                    new() { Fid = "TakeTime" },
                    new() { Fid = "StatusName" },
                    //new() { Fid = "Creator" },
                    //new() { Fid = "Created" },
                },
                Childs = new EditDto[]
                {
                    new()
                    {
                        Table = "dbo.OutboundItem",
                        ReadSql = @"
select oi.*,
    ItemName=i.Name, TypeName=t.Name
from dbo.OutboundItem oi
inner join dbo.Item i on oi.ItemId=i.Id
join dbo.ItemType t on i.TypeId=t.Id
where oi.OutboundId=@Id
",
                        PkeyFid = "Id",
                        FkeyFid = "OutboundId",
                        Col4 = null,
                        Items = new EitemDto[] {
                            new() { Fid = "Id" },
                            new() { Fid = "TypeName" },
                            new() { Fid = "ItemName" },
                            new() { Fid = "Amount" },

                        },
                    },
                },
            };
        
        }

    } //class
}
