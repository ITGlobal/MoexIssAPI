using System.Threading;
using System.Threading.Tasks;

namespace MoexIssAPI
{
    public interface IGetRequest<TResponse>
    {
        public Task<TResponse> Get(CancellationToken token = default);
    }
}

