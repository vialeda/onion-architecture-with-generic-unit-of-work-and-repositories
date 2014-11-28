using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.IndustrieQuebec.Core.Models;
using Viainternet.OnionArchitecture.Core.Domain;
using Viainternet.OnionArchitecture.Core.Interfaces.IRepositories;
using Viainternet.OnionArchitecture.Core.Interfaces.IServices;
using Viainternet.OnionArchitecture.Infrastructure.Repositories;
namespace Viainternet.OnionArchitecture.Core.Services
{
    public interface IMovieService : IService<Movie>
    {
        int CustomerOrderTotalByYear();
    }

    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IRepositoryAsync<Movie> _repository;

        public MovieService(IRepositoryAsync<Movie> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public int CustomerOrderTotalByYear()
        {
            // add business logic here
            return _repository.blabla();
        }
    }
}
