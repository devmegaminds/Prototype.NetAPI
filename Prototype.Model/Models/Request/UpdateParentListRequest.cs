using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Model.Models.Request
{
    public class UpdateParentListRequest
    {
        public string SamplingTime { get; set; }
        public string Properties { get; set; }
        public string stFilePath { get; set; }
    }
}
