using RestEase;
using ZbW.Testing.WpfSample.Client.Models;
using ZbW.Testing.WpfSample.Libs.IpInfoInterface.Api;

namespace ZbW.Testing.WpfSample.Client.Services
{
    internal class IpInfoReader
    {
        private readonly IIpInfoApi _ipInfoApi;

        public IpInfoReader()
        {
            string ApiUrl = "https://ipinfo.io";
            _ipInfoApi = RestClient.For<IIpInfoApi>(ApiUrl);
        }

        public IpDataObject GetData(string ip)
        {
            var data = _ipInfoApi.GetInfoAsync(ip).Result;

            var dataObject = new IpDataObject
            {
                Ip = data.Ip,
                City = data.City,
                Hostname = data.Hostname
            };

            return dataObject;
        }
    }
}
