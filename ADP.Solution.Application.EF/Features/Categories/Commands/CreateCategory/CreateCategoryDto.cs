﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
