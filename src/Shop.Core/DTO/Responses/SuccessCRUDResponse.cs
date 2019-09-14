namespace Shop.Core.DTO.Responses
{
    public class SuccessCRUDResponse : BaseCRUDResponse
    {
        public dynamic Data { get; protected set; }

        public SuccessCRUDResponse(string title, dynamic data, int status = 200) : base(title, status)
        {
            this.Data = data;
        }

        public override bool IsSuccess()
        {
            return true;
        }
    }
}