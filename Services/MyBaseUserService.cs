using Base.Models;
using Base.Services;
using BaseApi.Services;
using BaseApi.Extensions;
using Base.Interfaces;

namespace StoreAdm.Services
{
    public class MyBaseUserService : IBaseUserSvc
    {
        //get base user info
        public BaseUserDto GetData()
        {
            return _Http.GetSession().Get<BaseUserDto>(_Fun.FidBaseUser);   //extension method
        }
    }
}
