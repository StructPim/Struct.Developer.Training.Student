using Microsoft.Extensions.Configuration;
using Shared.Helpers;
using Shared.Import;
using Shared.Import.Helpers;
using Shared.Models;
using Struct.PIM.Api.Client;
using Struct.PIM.Api.Models.Catalogue;
using Struct.PIM.Api.Models.Product;
using Struct.PIM.Api.Models.Variant;
using Struct.PIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsole.Tasks
{
    internal class Task1
    {
        private readonly ImportService _importService;
        private readonly StructPIMApiClient _apiClient;
        private readonly int _writeBatchSize = 500;
        private readonly int _readBatchSize = 500;

        public Task1(ImportService importService)
        {
            _importService = importService;

            var bootstrapOptions = ConfigHelper.GetConfigValue();

            _apiClient = new StructPIMApiClient(bootstrapOptions.ApiUrl, bootstrapOptions.ApiKey);
        }

        /// <summary>
        /// Read the file category bogus data and create categories in pim with the data from the file
        /// </summary>
        /// <returns></returns>
        public void LoadCategoryDataIntoPIM()
        {
            //Get bogus data from file
            var categoryBogusData = _importService.ReadCategoryBogusData();

            //Get existing catalogues

            //Select the master catalogue
            

            var categoriesToCreate = new List<CreateCategoryModel<MasterCategoryModel>>();

            //Loop over the bogus categories and map them to a createmodel
            

            var batches = categoriesToCreate.Batch(_writeBatchSize);
            var totalBatchesCount = batches.Count();
            var processed = 0;

            foreach (var batch in batches)
            {
                Console.WriteLine($"Done processing batch {++processed}/{totalBatchesCount}");
                
            }
        }

        /// <summary>
        /// Read the file product bogus data and create products in PIM with the data from the file
        /// </summary>
        /// <returns></returns>
        public void LoadProductDataIntoPIM()
        {
            //Get bogus data from file
            var productBogusData = _importService.ReadProductBogusData();

            //Get existing category identifiers to determine placement/classification of products
            

            //Get the clothing product structure
            

            //Select the variation definition for clothing products from the product structure above
            

            var productsToCreate = new List<CreateProductModel<ClothingProductModel>>();

            //Loop over bogus products and map them to a createmodel
            foreach (var product in productBogusData)
            {
                
                //Using the ERP type value on the product to find a matching category.

                //Map the bogus data to the PIM data model                
            }

            //Now create the products in PIM. Remember ABB (Always Be Batching)
        }

        /// <summary>
        /// Read the file variant bogus data and create variants in PIM with the data from the file
        /// </summary>
        /// <returns></returns>
        public void LoadVariantDataIntoPIM()
        {
            //Get bogus data and map it to PIM data model
            var variantBogusData = _importService.ReadVariantBogusData();

            //Get existing product identifiers to determine what product each variant should be created under


            //Loop over bogus variants and map them to a createmodel

            //create the variants in PIM. Remember ABB (Always Be Batching)
        }
    }
}
