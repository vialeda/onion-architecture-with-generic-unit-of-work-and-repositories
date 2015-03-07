using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Domain.Models;

namespace Viainternet.OnionArchitecture.Core.Interfaces
{
    public interface IAdress
    {
        int StreetNumber { get; set; }
        string StreetName { get; set; }
        string PostalCode { get; set; }
        string PostalBox { get; set; }
        Municipality Municipality { get; set; }
    }
}
