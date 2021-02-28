using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination_Core_Api.Helpers
{
    public class Response <T>
    {

        public Response()
        {

        }

        public Response(T data)
        {
            Succeeded = true;
            Data = data;
            Message = string.Empty;
            Errors = null;
        }


        public T Data { get; set; }

        public bool Succeeded { get; set; }


        public string[] Errors { get; set; }

        public string Message { get; set; }
    }
}
