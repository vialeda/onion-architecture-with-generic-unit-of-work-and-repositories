using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Domain.Models;
using Viainternet.OnionArchitecture.Core.Interfaces.IRepositories;

namespace Viainternet.OnionArchitecture.Infrastructure.Repositories
{
    public static class MovieRepository
    {
        public static int test(this IRepositoryAsync<Movie> repository)
        {
            return 1;
        }
        public static int blabla(this IRepositoryAsync<Movie> repository)
        {
            return 3;
        }
    }
}
