using System;
using System.Collections.Generic;
using System.Text;

namespace StringsClient.Contracts.Models
{
    public class StringMessage : IHasId
    {
        public string Message { get; set; }
        public string IP { get; set; }

        public Guid Id { get; set; }
    }
}
