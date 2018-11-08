using System;
using System.Collections.Generic;
using System.Text;

namespace StringsClient.Contracts.Models
{
    public interface IHasId
    {
        Guid Id { get; }
    }
}
