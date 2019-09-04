using System.Collections.Generic;

namespace Shop.Core.DTO.Responses
{
    public class CreateUserResponse : BaseCRUDResponse
    {
        public string Id { get; }

        public IEnumerable<Error> Errors { get; }

        public CreateUserResponse(string id, string title, int status, IEnumerable<Error> errors = null) : base(title, status)
        {
            this.Id = id;
            this.Errors = errors;
        }

        public override bool IsSuccess()
        {
            return this.Errors == null;
        }
    }
}