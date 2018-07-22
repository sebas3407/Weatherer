using System;
using MyWeatherApp.ViewModels;

namespace MyWeatherApp.Responses
{
    public class Response : BaseViewModel
    {
        private bool isSuccess;
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { SetValue(ref isSuccess, value); }
        }

		private String message;
		public String Message
        {
			get { return message; }
			set { SetValue(ref message, value); }
        }
    }
}