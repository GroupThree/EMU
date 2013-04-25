using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web
{
    public static class Authentication
    {
        public static User CurrentUser
        {
            get { return HttpContext.Current.Session["UserInfo"] as User; }
            set { HttpContext.Current.Session["UserInfo"] = value; }
        }

        public static bool IsAuthenticated
        {
            get { return CurrentUser != null; }
        }

        public static bool IsAdmin
        {
            get 
            {
                return IsAuthenticated 
                    && CurrentUser.Type == UserType.AdminUser; 
            }
        }


    }
}