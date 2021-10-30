using Microsoft.AspNetCore.Http;

namespace Web_953501_Skavarodnik.Extensions
{
    public static class RequestExtension
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request

            .Headers["x-requested-with"]
            .Equals("XMLHttpRequest");

        }
    }
}
