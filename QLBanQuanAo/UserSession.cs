using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanQuanAo
{
    internal class UserSession
    {
        public static bool IsLoggedIn { get; private set; } = false;
        public static int CurrentUserId { get; private set; } = 0;
        public static string CurrentUserName { get; private set; } = "";

        public static void SetCurrentUser(user loggedInUser)
        {
            if (loggedInUser == null || loggedInUser.id <= 0)
            {
                Clear();
                return;
            }

            IsLoggedIn = true;
            CurrentUserId = loggedInUser.id;
            CurrentUserName = loggedInUser.full_name ?? "";
        }

        public static void Clear()
        {
            IsLoggedIn = false;
            CurrentUserId = 0;
            CurrentUserName = "";
        }
    }
}
