using System.Collections.Generic;

namespace Shop.Core.DTO.Responses
{
    public class CreateUserResponse : BaseCRUDResponse
    {
        public IEnumerable<Error> Errors { get; }

        public CreateUserResponse(string title, int status, IEnumerable<Error> errors = null) : base(title, status)
        {
            if (errors == null)
            {
                errors = new List<Error>();
            }
            this.Errors = errors;
        }

        public override bool IsSuccess()
        {
            return this.Errors == null;
        }
    }
}