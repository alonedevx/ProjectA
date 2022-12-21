using System;
using System.Collections.Generic;
using System.Text;
using static ProjectA.LoginFileSettigns;

namespace ProjectA
{
    class LoginSettings
    {
        private LoginFileSettigns file = new LoginFileSettigns("C:\\login.settings");

        bool IsUserAlready(string username)
        {
            if(file.Read("pw", username) == "")
            {
                return false;
            }
            return true;
        }

        string GetCurrentDate()
        {
            return DateTime.Now.ToString();
        }

        void WriteUser(string username, string password)
        {
            file.Write("pw", password, username);
            file.Write("date", GetCurrentDate(), username);
            //file.Write("date", username, GetCurrentDate());
        }

        public int IsRememberMe()
        {
            return Convert.ToInt32(file.Read("rememberMe", "user").ToString());
        }
        public string GetLastUserInformation(int infoCode)
        {
            if (infoCode == 0)
                return file.Read("username", "user");
            if (infoCode == 1)
                return file.Read("password", "user");

            return "null";
        }

        public int Register(string username, string password, string password_repeat)
        {
            if (password != password_repeat)
                return 0;

            if (IsUserAlready(username))
                return 1;

            WriteUser(username, password);
            return 10;
        }

        public int Login(string username, string password, int rememberMe)
        { 
            if (file.Read("pw", username) != password)
                return 0;

            file.Write("username", username, "user");
            file.Write("password", password, "user");
            file.Write("rememberMe", rememberMe.ToString(), "user");

            return 10;
        }

        public string GetUserRegisterDate(string username)
        { 
            return file.Read("date", username);
        }
    }
}
