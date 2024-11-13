using Microsoft.Extensions.Configuration;
using Shared.Helpers;
using Shared.Import;
using Shared.Import.Helpers;
using Struct.PIM.Api.Client;
using Struct.PIM.Api.Models.GlobalList;
using Struct.PIM.Api.Models.Variant;
using Struct.PIM.Models;

namespace TaskConsole.Tasks
{
    internal class Task3
    {
        private readonly ImportService _importService;
        private readonly StructPIMApiClient _apiClient;
        private readonly int _writeBatchSize = 500;

        public Task3(ImportService importService)
        {
            _importService = importService;

            //Init config reading and ApiClient
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();

            var bootstrapOptions = ConfigHelper.GetConfigValue();

            _apiClient = new StructPIMApiClient(bootstrapOptions.ApiUrl, bootstrapOptions.ApiKey);
        }

        /// <summary>
        /// Read the file variant bogus data and update varriants in PIM with the data from the file
        /// </summary>
        /// <returns></returns>
        public void DeltaUpdateExistingVariants()
        {
            //Get bogus data and map it to PIM data model
            var variantBogusData = _importService.ReadExistingVariantDeltaBogusData();

            //Get existing variant identifiers to determine the variants to update
            

            //Loop over bogus variants and map them to a update model
           
        }

        /// <summary>
        /// Read the file variant bogus data and update or create varriants in PIM with the data from the file
        /// </summary>
        /// <returns></returns>
        public void DeltaUpdateExistingAndNewVariants()
        {
            //Get bogus data and map it to PIM data model
            var variantBogusData = _importService.ReadExistingAndNewVariantDeltaBogusData();

            //Get existing product identifiers to determine what product each variant should be created under
            

            //Get existing variant identifiers to determine if a variant should be updated or created
            

            //Loop over bogus variants and map them to a create or update model                     

           
        }

        internal void DeltaUpdateGlobalListValues()
        {
            //Get bogus data and map it to PIM global list model
            var globalListBogusData = _importService.ReadGlobalListBogusData();

            //Get existing global list
            

            //Get existing global list values
            


            //Loop over bogus global list data and map them to a create or update lists
            var globalListValuesToUpdate = new List<GlobalListValue<SuppliersGlobalListModel>>();
            var globalListValuesToCreate = new List<GlobalListValue<SuppliersGlobalListModel>>();


            //create new global list values

            //update existing global list values
        }

        /// <summary>
        /// Read current danish cost price and calculate new cost prices based on the conversion rates
        /// </summary>
        /// <returns></returns>
        public void UpdateCostPrices()
        {
            //Fetch all variantIds from PIM
            

            //Find the currencies global list
            

            //Fetch currencies which contains the conversionrates            
            
        }
    }
}
