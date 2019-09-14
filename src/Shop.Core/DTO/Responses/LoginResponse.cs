using System;

namespace Shop.Core.DTO.Responses
{
    public class LoginResponse : BaseCRUDResponse
    {
        public string token { get; protected set; }
        public DateTime expireDate { get; protected set; }

        public LoginResponse(string token, string title, int status, DateTime expireDate) : base(title, status)
        {
            this.token = token;
            this.expireDate = expireDate;
        }

        public override bool IsSuccess()
        {
            return true;
        }
    }
}