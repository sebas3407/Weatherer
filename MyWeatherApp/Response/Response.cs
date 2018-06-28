using System;
using MyWeatherApp.ViewModels;

namespace MyWeatherApp.Response
{
    public class Response : BaseViewModel
    {

        private bool isSuccess;
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { SetValue(ref isSuccess, value); }
        }

        public Response()
        {
        }
    }
}
