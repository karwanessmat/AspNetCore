using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealDouble.Services.Extensions
{
    public static class IsAjaxConf
    {
        public static bool IsAjax(this HttpRequest req)
        {
            var result = false;

            var xreq = req.Headers.ContainsKey("x-requested-with");
            if (xreq)
            {
                result = req.Headers["x-requested-with"] == "XMLHttpRequest";
            }

            return result;

        }
    }
}
