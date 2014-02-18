using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigPandaHelper.Models
{
    public class DeploymentStartRequest
    {
        public string component { get; set; }
        public string version { get; set; }
        public List<string> hosts { get; set; }
        public string owner { get; set; }
        public string source { get; set; }
    }
}
