using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Domain.Models;

namespace Viainternet.OnionArchitecture.Core.Interfaces.IServices
{
    public interface IMovieService : IService<Movie>
    {
        int CustomerOrderTotalByYear();
    }
}
