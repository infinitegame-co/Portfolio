using DTO;
using Poolside.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poolside
{
    internal class Conversions
    {
        /// <summary>
        /// Convert a LoginViewModel to accountDTO;
        /// </summary>
        /// <param name="login"> Model to convert to AccountDTO</param>
        /// <returns>The AccountDTO related to this login data</returns>
        internal AccountDTO ConvertToAccountDTO(LoginViewModel Model)
        {
            int id = 0;
            string email = Model.Email;
            string nickname = Model.NickName;
            string password = Model.Password;

            return new AccountDTO(id, email, nickname, password);
        }

        internal LoginViewModel ConvertToLoginViewModel(AccountDTO DTO)
        {
            LoginViewModel Model = new LoginViewModel();
            Model.Email = DTO.Email;
            Model.NickName = DTO.NickName;
            Model.Password = DTO.Password;
            return Model;
        }

        internal GuestBookDTO ConvertToGuestBookDTO(GuestBookViewModel Model)
        {
            int id = 0;
            DateTime date = Model.PostDate;
            string message = Model.Message;
            string nickname = Model.UserNickName;
            return new GuestBookDTO(id, date, message, nickname);
        }
    }
}
