namespace Shop.Core.DTO.Responses
{
    public class LoginResponse : BaseCRUDResponse
    {
        public string token { get; protected set; }

        public LoginResponse(string token, string title, int status) : base(title, status)
        {
            this.token = token;
        }

        public override bool IsSuccess()
        {
            return true;
        }
    }
}