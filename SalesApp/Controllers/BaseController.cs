using Microsoft.AspNetCore.Mvc;
using SalesApp.Domain;
using SalesApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Controllers
{
    public class BaseController: Controller
    {
        public BaseController()
        {
          
        }

        public User GetUserSession()
        {
            var userInfo = HttpContext.Session.GetObjectFromJson<User>("UserInfo");
            return userInfo;
        }
        public void SetUserSession(User ObjadminDataModel)
        {
            if(ObjadminDataModel == null)
            {
                HttpContext.Session.Remove("UserInfo");
            }
            else
            {
                ObjadminDataModel.Password = "";
                HttpContext.Session.SetObjectAsJson("UserInfo", ObjadminDataModel);
            }
    
        }
    }
}
