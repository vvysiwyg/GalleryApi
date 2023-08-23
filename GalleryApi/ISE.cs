using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GalleryApi
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class ISE : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        public ISE(object? value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
