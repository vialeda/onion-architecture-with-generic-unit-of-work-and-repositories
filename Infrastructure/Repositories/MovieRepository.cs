using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Infrastructure.Repositories
{
    using Core.Domain.Models;
    using Core.Interfaces.IRepositories;

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
