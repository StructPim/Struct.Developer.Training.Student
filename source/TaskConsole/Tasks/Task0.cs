using Shared.Helpers;
using Shared.Import;
using Struct.PIM.Api.Client;

namespace TaskConsole.Tasks
{
    internal class Task0

    {
        private readonly StructPIMApiClient _apiClient;

        public Task0(ImportService importService)
        {
            var bootstrapOptions = ConfigHelper.GetConfigValue();

            _apiClient = new StructPIMApiClient(bootstrapOptions.ApiUrl, bootstrapOptions.ApiKey);
        }

        /// <summary>
        /// Test the connection to the PIM API with the heart beat endpoint
        /// </summary>
        /// <returns></returns>
        public string DoHeartBeat()
        {
            return _apiClient.Miscellaneous.Heartbeat();
        }

    }
}
