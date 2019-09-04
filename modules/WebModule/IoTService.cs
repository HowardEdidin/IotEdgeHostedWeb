using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Client.Transport.Mqtt;
using System.IO;
using System.Text;

namespace WebModule
{
    public interface IIoTService
    {
        Task<int> SendEventAsync(string pipe, string jsonmessage);
    }

    public class IoTService : IIoTService 
    {
        private static ModuleClient _ioTHubModuleClient;

        public IoTService() {
            Init().Wait();
        }

        public async Task<int> SendEventAsync(string pipe, string jsonmessage) 
        {

                    
            var messageBytes = Encoding.UTF8.GetBytes(jsonmessage);
            var message = new Message(messageBytes);
            message.ContentEncoding = "utf-8"; 
            //message.Properties.Add("title", "value");
            await _ioTHubModuleClient.SendEventAsync(pipe, message);
            return 1;
        }

        static async Task Init()
        {
            MqttTransportSettings mqttSetting = new MqttTransportSettings(TransportType.Mqtt_Tcp_Only);
            ITransportSettings[] settings = { mqttSetting };

            // Open a connection to the Edge runtime
            _ioTHubModuleClient = await ModuleClient.CreateFromEnvironmentAsync(settings);
            await _ioTHubModuleClient.OpenAsync();
            Console.WriteLine("IoT Hub module client initialized.");

            // Register callback to be called when a message is received by the module
            // await ioTHubModuleClient.SetInputMessageHandlerAsync("input1", PipeMessage, ioTHubModuleClient);
        }

    }
    
}