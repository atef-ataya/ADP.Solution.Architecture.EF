﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
