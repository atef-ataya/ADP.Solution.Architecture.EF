﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Models.Authenticaiton
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
