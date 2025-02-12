using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class NumberInfo
    {
        public string Number { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTimeOffset DateOfRegistration { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset LastUpdateDate { get; set; } = DateTimeOffset.Now;
    }
}
