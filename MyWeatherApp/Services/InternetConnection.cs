using System.Threading.Tasks;
using MyWeatherApp.Responses;
using Plugin.Connectivity;

namespace MyWeatherApp.Services
{
	public class InternetConnection
    {
		public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
			
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please, check your internet connection.",
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }
    }
}
