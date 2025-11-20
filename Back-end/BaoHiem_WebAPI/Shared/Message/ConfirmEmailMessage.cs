using Shared.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Message
{
    public class ConfirmEmailMessage
    {
        public static string Message(string Email, string confirmLink)
        {
            return $"Hi,\n" +
                $"Please enter link to confirm email {Email}.\n" +
                $"Link: {confirmLink}\n" +
                $"Thank you";
        }
    }
}
