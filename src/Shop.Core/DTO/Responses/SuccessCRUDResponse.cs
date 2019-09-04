namespace Shop.Core.DTO.Responses
{
    public class SuccessCRUDResponse : BaseCRUDResponse
    {
        public dynamic Data { get; protected set; }

        public SuccessCRUDResponse(string title, dynamic data) : base(title, 200)
        {
            this.Data = data;
        }

        public override bool IsSuccess()
        {
            return true;
        }
    }
}