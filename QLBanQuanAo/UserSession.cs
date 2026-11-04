using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanQuanAo
{
    internal class UserSession
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static int CurrentUserId { get; set; } = 0;
        public static string CurrentUserName { get; set; } = "";
    }
}
