﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDaniels.IdentityServer.Domain.Models.Base
{
    public abstract class SearchRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
