using Microsoft.Extensions.Options;
using MiniAPI.Definitions;
using MiniAPI.Repository;

namespace MiniAPI.Service
{
    public abstract class BaseService
    {
        protected readonly AppSettings _appSettings;
        protected readonly BaseRepository repository;

        public BaseService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            repository = new BaseRepository();
        }
    }
}
