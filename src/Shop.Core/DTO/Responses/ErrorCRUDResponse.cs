namespace Shop.Core.DTO.Responses
{
    public class ErrorCRUDResponse : BaseCRUDResponse
    {
        public ErrorCRUDResponse(string title, int status) : base(title, status)
        {
        }
    }
}