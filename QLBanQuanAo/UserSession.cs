using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanQuanAo
{
    public static class UserSession
    {
        public static user CurrentUser { get; set; }
        public static bool IsLoggedIn { get; set; } = false;
        public static int CurrentUserId { get; set; } = 0;
        public static string CurrentUserName { get; set; } = "";
        public static string CurrentUserRole { get; set; } = "";

        public static void SetCurrentUser(user u)
        {
            CurrentUser = u;
            if (u != null)
            {
                IsLoggedIn = true;
                CurrentUserId = u.id;
                CurrentUserName = u.full_name;
               
            }
            else
            {
                Clear();
            }
        }

        public static void SetCurrentUser(int userId, string userName, string role = "customer")
        {
            IsLoggedIn = true;
            CurrentUserId = userId;
            CurrentUserName = userName;
            CurrentUserRole = role;
        }

        public static void Clear()
        {
            CurrentUser = null;
            IsLoggedIn = false;
            CurrentUserId = 0;
            CurrentUserName = "";
            CurrentUserRole = "";
        }

        public static void Login(int userId, string userName, string role = "customer")
        {
            SetCurrentUser(userId, userName, role);
        }

        public static void Logout()
        {
            Clear();
        }
    }
}
