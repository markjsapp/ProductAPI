using Restauraunt.Web.Models;

namespace Restauraunt.Web.Services.IServices
{
    // IDisposable has a single method, dispose(), which releases unmanaged sources like files, streams, databases, etc 
    public interface IBaseServices : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
