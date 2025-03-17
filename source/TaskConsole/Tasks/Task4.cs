using Microsoft.Extensions.Configuration;
using Shared.Helpers;
using Shared.Import;
using Shared.Models;
using Struct.App.Api.Client;
using Struct.App.Api.Models.DataConfiguration;
using Struct.App.Api.Models.Dimension;
using Struct.App.Api.Models.Shared;
using Struct.App.Api.Models.Variant;

namespace TaskConsole.Tasks
{
    internal class Task4
    {
        private readonly StructApiClient _apiClient;

        public Task4(ImportService importService)
        {

            //Init config reading and ApiClient
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();

            var bootstrapOptions = ConfigHelper.GetConfigValue();

            _apiClient = new StructApiClient(bootstrapOptions.ApiUrl, bootstrapOptions.ApiKey);
        }

        /// <summary>
        /// Find all products in PIM with 100% completeness in the enrichment insight "Ready for website"
        /// </summary>
        internal void SearchEnrichedProducts()
        {
            var queryableFields = _apiClient.Products.GetQueryableFields();

            var completenessField = queryableFields.Single(x => x.Name == "Completeness: Ready for website");

            var searchModel = new SearchModel()
            {
                IncludeArchived = false,
                QueryModel = new SimpleQueryModel()
                {
                    BooleanOperator = BooleanOperator.And,
                    Filters = new List<FieldFilterModel>
            {
                new FieldFilterModel {FieldUid = completenessField.Uid, FilterValue = 100, QueryOperator = QueryOperator.Equals}
            }
                }
            };

            var fullyEnrichedProducts = _apiClient.Products.Search(searchModel);
            if (fullyEnrichedProducts.Count < 1)
            {
                Console.WriteLine("No fully enriched products was found");
            }
            else
            {
                Console.WriteLine($"Found {fullyEnrichedProducts.Count} fully enriched products");
            }
        }

        /// <summary>
        /// Setup segmented attribute data and enrich on variants
        /// </summary>
        internal void EnrichSegmentedData()
        {
            //Create dimension
            var retailerDimension = _apiClient.Dimensions.GetDimensions().FirstOrDefault();

            if (retailerDimension == null)
            {
                _apiClient.Dimensions.CreateDimension(new Struct.App.Api.Models.Dimension.DimensionModel
                {
                    Alias = "Retailer",
                    Uid = Guid.NewGuid(),
                    Segments = new List<DimensionSegmentModel>
        {
            new DimensionSegmentModel
            {
                Identifier = "A",
                Name = "CompanyA",
                Uid = Guid.NewGuid(),
            },
            new DimensionSegmentModel
            {
                Identifier = "B",
                Name = "CompanyB",
                Uid = Guid.NewGuid(),
            }
        }
                });
            }

            retailerDimension = _apiClient.Dimensions.GetDimensions()
                .Single(x => x.Alias == "Retailer");

            //Create attribute
            var marketingHeadlineAttribute = _apiClient.Attributes.GetAttributes().FirstOrDefault(x => x.Alias == "MarketingHeadline");

            if (marketingHeadlineAttribute == null)
            {
                var masterDataScope = _apiClient.Attributes.GetAttributeScopes().Single(x => x.Alias == "MasterData");
                _apiClient.Attributes.CreateAttribute(new Struct.App.Api.Models.Attribute.TextAttribute
                {
                    Uid = Guid.NewGuid(),
                    Alias = "MarketingHeadline",
                    Name = new Dictionary<string, string> { { "da-DK", "Marketing overskrift" }, { "en-GB", "Marketing headline" } },
                    BackofficeName = "Marketing headline",
                    DimensionUid = retailerDimension.Uid,
                    AttributeScopes = new List<Guid> { masterDataScope.Uid }
                });
            }

            marketingHeadlineAttribute = _apiClient.Attributes.GetAttributes()
                .Single(x => x.Alias == "MarketingHeadline");

            //Add attribute to variant model
            var clothingProductStructure = _apiClient.ProductStructures.GetProductStructures().Single(x => x.Alias == "Clothing");

            var firstSection = ((DynamicSectionSetup)((DynamicTabSetup)clothingProductStructure.VariantConfiguration.Tabs.First()).Sections.First());

            if (!firstSection.Properties.Any(x => ((AttributeSetup)x).AttributeUid == marketingHeadlineAttribute.Uid))
            {
                var marketingHeadLineProperty = (AttributeSetup)Activator.CreateInstance(typeof(AttributeSetup));
                marketingHeadLineProperty.AttributeUid = marketingHeadlineAttribute.Uid;
                marketingHeadLineProperty.ReadOnly = false;
                marketingHeadLineProperty.Unchangeable = false;

                firstSection.Properties.Insert(0, marketingHeadLineProperty);

                _apiClient.ProductStructures.UpdateProductStructure(clothingProductStructure);
            }

            //Update some variants with the data
            var updateModel = new Dictionary<int, UpdateVariantModel<UpdateSegmentedDataModel>>();

            var variantsToUpdate = _apiClient.Variants.GetVariantIds().Take(10);

            foreach (var variantId in variantsToUpdate)
            {
                updateModel.Add(variantId, new UpdateVariantModel<UpdateSegmentedDataModel>
                {
                    Values = new UpdateSegmentedDataModel
                    {
                        MarketingHeadline = new List<SegmentedData<string>>
        {
            new SegmentedData<string>
            {
                Data = "Headline A",
                Dimension = retailerDimension.Alias,
                Segment = "A"
            },
            new SegmentedData<string>
            {
                Data = "Headline B",
                Dimension = retailerDimension.Alias,
                Segment = "B"
            }
        }
                    }
                });
            }

            _apiClient.Variants.UpdateVariants<UpdateSegmentedDataModel>(updateModel);
        }
    }
}
