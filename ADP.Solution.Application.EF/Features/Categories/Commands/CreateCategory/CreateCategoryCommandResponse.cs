﻿using ADP.Solution.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {

        }

        public CreateCategoryDto Category { get; set; }
    }
}
