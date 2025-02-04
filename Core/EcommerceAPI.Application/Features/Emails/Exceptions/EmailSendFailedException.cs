using EcommerceAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Application.Features.Emails.Exceptions
{
    public class EmailSendFailedException : BaseException
    {
        public EmailSendFailedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
