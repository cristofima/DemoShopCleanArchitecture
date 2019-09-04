namespace Shop.Core.DTO.Responses
{
    public abstract class BaseCRUDResponse
    {
        public string title { get; protected set; }
        public int status { get; protected set; }

        public BaseCRUDResponse(string title, int status)
        {
            this.title = title;
            this.status = status;
        }

        public virtual bool IsSuccess()
        {
            return false;
        }
    }
}