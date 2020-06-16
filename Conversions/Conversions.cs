using System;
using DTO;
using Poolside.Models;

namespace Conversions
{
    public class Conversions
    {
        /// <summary>
        /// Convert a LoginViewModel to accountDTO;
        /// </summary>
        /// <param name="login"> Model to convert to AccountDTO</param>
        /// <returns>The AccountDTO related to this login data</returns>
        public AccountDTO ConvertToAccountDTO(LoginViewModel Model)
        {
            int id = 0;
            string email = Model.Email;
            string nickname = Model.NickName;
            string password = Model.Password;

            return new AccountDTO(id, email, nickname, password);
        }

        public LoginViewModel ConvertToLoginViewModel(AccountDTO DTO)
        {
            string email = DTO.Email;
            string nickname = DTO.NickName;
            string password = DTO.Password;
            return new LoginViewModel(email,nickname,password);
        }

        public GuestBookDTO ConvertToGuestBookDTO(GuestBookViewModel Model)
        {
            int id = 0;
            DateTime date = Model.PostDate;
            string message = Model.Message;
            string nickname = Model.UserNickName;
            return new GuestBookDTO(id, date, message, nickname);
        }
    }
}
