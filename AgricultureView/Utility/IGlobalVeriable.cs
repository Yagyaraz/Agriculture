using AgricultureView.Models;

namespace AgricultureView.Utility
{
    public interface IGlobalVeriable
    {
        Task<ApiResponse> GetMethod(string url);
        Task<ApiResponse> DeleteMethod(string url);
        Task<ApiResponse> PostMethod(string url, object model);
        Task<ApiResponse> PostFileMethod(string url, object model);
        Task<ApiResponse> PostFileMethodWithPartial(string url, HttpContent content);

        void SetToken(string Token);
        string BaseUrl();

    }
}
