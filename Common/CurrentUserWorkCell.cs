﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Common
{
    [Serializable]
    public class CurrentUserWorkCell
    {
        public string code { get; set; }
        public string workCell { get; set; }
    }
}