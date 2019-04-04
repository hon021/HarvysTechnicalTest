using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvy.Ordonez.Model
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            ErrorList = new List<string>();
        }
        public object Content { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> ErrorList { get; set; }

        public bool Warning { get; set; }
        public string WarningMsg { get; set; }
    }
}
