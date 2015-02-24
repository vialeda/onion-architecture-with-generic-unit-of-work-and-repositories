using Infrastructure.Caching;

namespace Viainternet.OnionArchitecture.Core.Services
{
    using Core.Domain;
    using Core.Domain.Models;
    using Core.Interfaces.IRepositories;
    using Core.Interfaces.IServices;
    using Infrastructure.Repositories;
    
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IRepositoryAsync<Movie> _repository;

        public MovieService(IRepositoryAsync<Movie> repository)
            : base(repository)
        {
            _repository = repository;
        }

        [CachingInterceptor(CachingAction.Add)]
        public int CustomerOrderTotalByYear()
        {
            // add business logic here
            return _repository.blabla();
        }
    }
}
