using DTO;
using Poolside.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Logic;
using DAL;
using DAL.Access;

namespace Poolside
{
    internal class Conversions
    {
        private readonly ConversionLogic logic;
        public Conversions()
        {
            logic = new ConversionLogic(new AccountAccess());
        }

        /// <summary>
        /// Convert a LoginViewModel to accountDTO;
        /// </summary>
        /// <param name="login"> Model to convert to AccountDTO</param>
        /// <returns>The AccountDTO related to this login data</returns>
        internal AccountDTO ConvertToAccountDTO(LoginViewModel Model)
        {
            AccountDTO res = new AccountDTO();
            res.Email = Model.Email;
            res.NickName = Model.NickName;
            res.Password = Model.Password;
            res.Id = logic.GetAccountID(res);

            return res;
        }
        /// <summary>
        /// Convert an accountDTO to a LoginViewModel;
        /// </summary>
        /// <param name="login"> DTO to convert to LoginViewModel</param>
        /// <returns>The LoginViewModel related to this login data</returns>
        internal LoginViewModel ConvertToLoginViewModel(AccountDTO DTO)
        {
            LoginViewModel Model = new LoginViewModel();
            Model.Email = DTO.Email;
            Model.NickName = DTO.NickName;
            Model.Password = DTO.Password;
            return Model;
        }
        /// <summary>
        /// Convert a GuestBookViewModel to GuestBookDTO;
        /// </summary>
        /// <param name="login"> Model to convert to GuestBookDTO</param>
        /// <returns>The GuestBookDTO related to this login data</returns>
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
