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
                Description = new List<LocalizedData<string>>
                {
                    new LocalizedData<string>
                    {
                        CultureCode = "da-DK",
                        Data = bogusModel.Description
                    },
                    new LocalizedData<string>
                    {
                        CultureCode = "en-GB",
                        Data = bogusModel.Description
                    }
                },

                //Map Name as List<LocalizedData<string>> with cultre codes da-DK and en-GB
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
                },

                //Style number is identifier for the product
                StyleNumber = bogusModel.StyleNo,

                //ERPType is used to map the product to a category
                ERPType = bogusModel.ErpType,
            };
        }

        public static ClothingVariantModel Map(VariantBogusModel bogusModel)
        {
            return new ClothingVariantModel
            {

                //Map Material as MaterialGlobalListModel and set CultureCode to List<LocalizedData<string>> with culture code da-DK
                Material = new MaterialGlobalListModel() { 
                    Name = new List<LocalizedData<string>>
                    {
                        new LocalizedData<string>
                        {
                            CultureCode = "da-DK",
                            Data = bogusModel.Material
                        }
                    }
                },

                //Map BaseCostPrice
                BaseCostPrice = bogusModel.BaseCostPrice,

                //Map Color as ColorsGlobalListModel and set CultureCode to List<LocalizedData<string>> with culture code da-DK
                Color = new ColorsGlobalListModel()
                {
                    Name = new List<LocalizedData<string>>
                    {
                        new LocalizedData<string>
                        {
                            CultureCode = "da-DK",
                            Data = bogusModel.Color
                        }
                    },
                    
                },

                //Map PackageSize as PackageSizeModel
                PackageSize = new PackageSizeModel()
                {
                    Height = bogusModel.PackageSize.Height,
                    Length = bogusModel.PackageSize.Length,
                    Width = bogusModel.PackageSize.Width
                },

                //Map Sku
                SKU = bogusModel.Sku,

                //Map Weight
                Weight = bogusModel.Weight,

                //Map Size
                Size = bogusModel.Size,
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
