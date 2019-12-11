using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public class SomethingElectronic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
    }
}