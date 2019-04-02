using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Client.Models
{
        public class BaseApiResult<T> : IApiResult<T>
        {
            public BaseApiResult()
            {

            }

            public T Result { get; set; }

            public string Code { get; set; }

            public string Message { get; set; }

            public object ModelState { get; set; }

            public bool Success { get; set; }

            public string Url { get; set; }

            public virtual object Minify()
            {
                return this;
            }
    }
}
