using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web
{
    public static class Authentication
    {
        static bool requireAuthentication = false;

        public static User CurrentUser
        {
            get { return HttpContext.Current.Session[ "UserInfo" ] as User; }
            set { HttpContext.Current.Session[ "UserInfo" ] = value; }
        }

        public static bool IsAuthenticated
        {
            get { return requireAuthentication == false || CurrentUser != null; }
        }

        public static bool IsAdmin
        {
            get
            {
                return requireAuthentication == false 
                    || (IsAuthenticated
                    && CurrentUser.UserType == UserType.Admin);
            }
        }

        public static User AuthenticateUser( string username, string password )
        {
            using( var db = new EmuDb() )
            {
                var result = db.Users.SingleOrDefault( user => user.UserName == username && user.Password == password );
                if( result != null )
                {
                    CurrentUser = result;
                }
                return result;
            }
        }

        public static void LogOut()
        {
            CurrentUser = null;
        }

    }
}