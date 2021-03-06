﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProntuarioApp.Client.Models
{
    public sealed class OkApiResult<T> : BaseApiResult<T>
    {
        public OkApiResult()
        {
            Success = false;
            ModelState = null;
            Code = null;
        }

        public OkApiResult(T data)
            : this()
        {
            Success = true;
            Result = data;
        }
    }
}
