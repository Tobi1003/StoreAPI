using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreASPNet6_Data.Model.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> ErrorsMsg { get; set; }

        public ErrorResponse(string errorMsg) : this(new List<string>() { errorMsg }) { }

        public ErrorResponse(IEnumerable<string> errorMsg)
        {
            ErrorsMsg = errorMsg;
        }
    }
}
