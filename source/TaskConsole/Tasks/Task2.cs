﻿using Microsoft.Extensions.Configuration;
using Shared.Helpers;
using Shared.Index;
using Shared.Index.Models;
using Struct.PIM.Api.Client;
using Struct.PIM.Api.Models.Product;
using Struct.PIM.Models;
using Shared.Index.Helpers;
using Struct.PIM.Api.Models.Variant;
using Struct.PIM.Api.Client.Endpoints;
using Struct.PIM.Api.Models.Language;

namespace TaskConsole.Tasks
{
    internal class Task2
    {
        private readonly IndexService _indexService;
        private readonly StructPIMApiClient _apiClient;
        private readonly MessageClient _messageClient;
        private readonly int _batchSize = 500;

        public Task2(IndexService indexService)
        {
            _indexService = indexService;

            var bootstrapOptions = ConfigHelper.GetConfigValue();
            
            _apiClient = new StructPIMApiClient(bootstrapOptions.ApiUrl, bootstrapOptions.ApiKey);

            _messageClient = new MessageClient(bootstrapOptions.MessageQueueName, bootstrapOptions.MessageQueueConnectionString, bootstrapOptions.BlobContainerConnectionString);
        }

        /// <summary>
        /// Read product data from PIM and index it using the index service
        /// </summary>
        /// <returns></returns>
        public void FullExportProductData()
        {            
            var language = _apiClient.Languages.GetLanguages().First(x => x.CultureCode == "en-GB");

            var productIds = new List<int>();

            //Start by fetching the products from PIM           

            var indexModels = FetchAndMapProductData(productIds, language);

            //create index using the index service
        }

        /// <summary>
        /// Read messages from message queue and update the index with the changes
        /// </summary>
        /// <returns></returns>
        public void ConsumeDeltaUpdates()
        {
            //fetch updates from servicebus
            var updates = new List<int?>();

            if (!updates.Any())
            {
                Console.WriteLine("No messages in queue. Generate a change in PIM first..");
                Console.ReadKey();
            }

            //Get language (en-GB).

            //Map the products using the FetchAndMapProductData method

            //Update the index with the changes using the index service

        }

        private List<ProductIndexModel> FetchAndMapProductData(List<int> productIds, LanguageModel language)
        {
            var batches = productIds.Batch(_batchSize);
            var totalBatchesCount = batches.Count();
            var processed = 0;

            var indexModels = new List<ProductIndexModel>();

            foreach (var batch in batches)
            {
                //Fetch product attribute values in batches in task 2.1a
                var productAttributeValues = new List<ProductAttributeValuesModel<ClothingProductModel>>();

                //fetch variants for products in task 2.1b
                var productToVariants = new Dictionary<int, List<int>>();

                //fetch variant attribute values and fetch values in batches in task 2.1b
                var allVariants = new List<VariantModel>();

                //fetch classification for products into productToClassification in task 2.1c
                var productToClassification = new Dictionary<int, List<ProductClassificationModel>>();

                var varintBatches = allVariants.Batch(_batchSize);
                var totalVariantBatchCount = varintBatches.Count();
                var processedVariantBatches = 0;

                var mappedVariants = new Dictionary<int, VariantIndexModel>();

                //Map variant data in task 2.1b 
                foreach (var variantBatch in varintBatches)
                {


                    Console.WriteLine($"Done processing variant batch {++processedVariantBatches}/{totalVariantBatchCount}");
                }

                //Map product data in task
                foreach (var productModel in productAttributeValues)
                {
                    var productVariants = new List<VariantIndexModel>();

                    //get variants belonging to product in task 2.1b


                    var productClassification = new List<int>();
                    //get classification for product in task 2.1c

                    indexModels.Add(Mapper.Map(language, productModel.ProductId, productModel.Values, productVariants, productClassification));
                }

                Console.WriteLine($"Done processing batch {++processed}/{totalBatchesCount}");
            }
            return indexModels;
        }
    }
}