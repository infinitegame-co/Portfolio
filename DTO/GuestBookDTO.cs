using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class GuestBookDTO
    {
        //private readonly GuestBookAccess GuestBook;
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Message { get; set; }
        public string NickName { get; set; }

        public GuestBookDTO(int Id,DateTime PostDate, string Message, string NickName)
        {
            this.Id = Id;
            this.PostDate = PostDate;
            this.Message = Message;
            this.NickName = NickName;
        }
    }
}
