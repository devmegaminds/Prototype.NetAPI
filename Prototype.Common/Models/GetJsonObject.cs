using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Common.Models
{
    public class GetJsonObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Data> Datas { get; set; }
    }

    public class Property
    {
        public int Id { get; set; }
        public object Value { get; set; }
        public string Label { get; set; }
        public int PropertyType { get; set; }
    }

    public class Data
    {
        public DateTime SamplingTime { get; set; }
        public List<Property> Properties { get; set; }
    }

}
