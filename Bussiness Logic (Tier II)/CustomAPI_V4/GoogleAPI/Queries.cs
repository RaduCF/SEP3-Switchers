﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    public class Queries
    {
        [JsonProperty("request")]
        public NextPage[] Request { get; set; }
    }
}
