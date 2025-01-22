using Shared.Models;
using Struct.PIM.Api.Models.Shared;
using Struct.PIM.Models;

namespace Shared.Import.Helpers
{
    public static class Mapper
    {
        public static MasterCategoryModel Map(CategoryBogusModel bogusModel)
        {
            return new MasterCategoryModel
            {
                Alias = bogusModel.Alias,
                Name = new List<LocalizedData<string>>
                {
                    new LocalizedData<string>
                    {
                        CultureCode = "da-DK",
                        Data = bogusModel.NameDa
                    },
                    new LocalizedData<string>
                    {
                        CultureCode = "en-GB",
                        Data = bogusModel.NameEng
                    }
                }
            };
        }

        public static ClothingProductModel Map(ProductBogusModel bogusModel)
        {
            var salesChannels = new List<SaleChannelsGlobalListModel>();
            foreach (var saleChannel in bogusModel.SaleChannels)
            {
                salesChannels.Add(new SaleChannelsGlobalListModel() { Name = saleChannel, Alias = saleChannel });
            }

            return new ClothingProductModel
            {
                //Set SaleChannels to mapped value above.
                SalesChannels = salesChannels,

                //Map Brand as BrandsGlobalListModel
                Brand = new BrandsGlobalListModel() { Name = bogusModel.Brand },

                //Map CountryOfOrigin as List<LocalizedData<string>> with cultre codes da-DK and en-GB
                CountryOfOrigin = new List<LocalizedData<string>>
                {
                    new LocalizedData<string>
                    {
                        CultureCode = "da-DK",
                        Data = bogusModel.CountryOfOrigin
                    },
                    new LocalizedData<string>
                    {
                        CultureCode = "en-GB",
                        Data = bogusModel.CountryOfOrigin
                    }
                },

                //Map Description as List<LocalizedData<string>> with cultre codes da-DK and en-GB

                //Map Name as List<LocalizedData<string>> with cultre codes da-DK and en-GB

                //Style number is identifier for the product

                //ERPType is used to map the product to a category
            };
        }

        public static VariantDeltaERPUpdateModel Map(VariantBogusModel bogusModel)
        {
            return new VariantDeltaERPUpdateModel
            {
                //Map Weight
            };
        }

        public static ClothingVariantModel MapNewVariant(VariantBogusModel bogusModel)
        {
            return new ClothingVariantModel
            {
                //Map Material as MaterialGlobalListModel and set CultureCode to List<LocalizedData<string>> with culture code da-DK

                //Map BaseCostPrice

                //Map Color as ColorsGlobalListModel and set CultureCode to List<LocalizedData<string>> with culture code da-DK

                //Map PackageSize as PackageSizeModel

                //Map Sku

                //Map Weight

                //Map Size
            };
        }

        public static SuppliersGlobalListModel Map(GlobalListBogusModel globalListValue)
        {
            return new SuppliersGlobalListModel
            {
                SupplierId = globalListValue.Id,
                Name = globalListValue.Name,
                Phone = globalListValue.Phone,
                Email = globalListValue.Email
            };
        }
    }
}
