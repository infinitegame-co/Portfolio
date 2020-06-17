using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public class ConversionLogic
    {
        private readonly IAccountAccess Account;

        public ConversionLogic(IAccountAccess Account)
        {
            this.Account = Account;
        }
        public int GetAccountID(AccountDTO account)
        {
            AccountDTO temp = new AccountDTO(account.Id,account.Email,account.NickName,account.Password);
            temp.Password = CreateHashedString(account.Password);
            return Account.Get(temp).Id;
        }

        internal string CreateHashedString(string Value)
        {//TODO: add salting before publishing
            using (HashAlgorithm hash = SHA256.Create())
            {
                StringBuilder sb = new StringBuilder();
                string hashed = "";
                byte[] temp = hash.ComputeHash(Encoding.UTF8.GetBytes(Value));
                foreach (byte bt in temp)
                {
                    sb.Append(bt.ToString("X2"));
                }
                hashed = sb.ToString();
                return hashed;
            }
        }
    }
}
