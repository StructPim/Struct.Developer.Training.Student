using Microsoft.Extensions.Configuration;
using Shared.Helpers;
using Shared.Import;
using Shared.Models;
using Struct.PIM.Api.Client;
using Struct.PIM.Api.Models.DataConfiguration;
using Struct.PIM.Api.Models.Dimension;
using Struct.PIM.Api.Models.Shared;
using Struct.PIM.Api.Models.Variant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsole.Tasks
{
    internal class Task4
    {
        private readonly StructPIMApiClient _apiClient;

        public Task4(ImportService importService)
        {

            //Init config reading and ApiClient
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();

            var bootstrapOptions = ConfigHelper.GetConfigValue();

            _apiClient = new StructPIMApiClient(bootstrapOptions.ApiUrl, bootstrapOptions.ApiKey);
        }

        /// <summary>
        /// Find all products in PIM with 100% completeness in the enrichment insight "Ready for website"
        /// </summary>
        internal void SearchEnrichedProducts()
        {
            var queryableFields = _apiClient.Products.GetQueryableFields();

            //Find the correct field from "queryableFields", and utilize it in a searchmodel for the /search product endpoint
        }

        /// <summary>
        /// Setup segmented attribute data and enrich on variants
        /// </summary>
        internal void EnrichSegmentedData()
        {
            //Create dimension

            //Create attribute assigning the newly created dimension as its DimensionUid

            //Add the attribute to the clothing variant model using the code below
            //var clothingProductStructure = _apiClient.ProductStructures.GetProductStructures().Single(x => x.Alias == "Clothing");

            //var firstSection = ((DynamicSectionSetup)((DynamicTabSetup)clothingProductStructure.VariantConfiguration.Tabs.First()).Sections.First());

            //if (!firstSection.Properties.Any(x => ((AttributeSetup)x).AttributeUid == marketingHeadlineAttribute.Uid))
            //{
            //    var marketingHeadLineProperty = (AttributeSetup)Activator.CreateInstance(typeof(AttributeSetup));
            //    marketingHeadLineProperty.AttributeUid = marketingHeadlineAttribute.Uid;
            //    marketingHeadLineProperty.ReadOnly = false;
            //    marketingHeadLineProperty.Unchangeable = false;

            //    firstSection.Properties.Insert(0, marketingHeadLineProperty);

            //    _apiClient.ProductStructures.UpdateProductStructure(clothingProductStructure);
            //}

            //Update some variants with the data

            //_apiClient.Variants.UpdateVariants<UpdateSegmentedDataModel>(updateModel);
        }
    }
}
