using System;

namespace Logic
{
    public class UserLogic
    {

        public bool CheckPasswords(string password, string email)
        {
            string tempPassword = password; //TODO: pass password through hashing and salting process
            return tempPassword == GetHashedPassword(email);
        }

        private string GetHashedPassword(string email)
        {
            //access database and request password from email
            return "";
        }
    }
}
