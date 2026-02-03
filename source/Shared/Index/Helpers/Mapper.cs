using Shared.Index.Models;
using Struct.App.Api.Models.Language;
using Struct.App.Api.Models.Variant;
using Struct.PIM.Models;

namespace Shared.Index.Helpers
{
    public static class Mapper
    {
        public static ProductIndexModel Map(LanguageModel language, int productId, ClothingProductModel product, List<VariantIndexModel> productVariants, List<int> productClassification)
        {
            return new ProductIndexModel
            {
                Id = productId,
                ImageUrl = product.PrimaryImage ?? $"placeholder_{new Random().Next(1, 8)}.webp",
                //Name
                //StyleNumber
                //Description
                //Brand
                //Categories
                //Variants
            };
        }

        public static VariantIndexModel Map(LanguageModel language, VariantModel variant, ClothingVariantModel variantValues)
        {
            return new VariantIndexModel
            {
                Id = variant.Id,
                Name = variant.Name[language.CultureCode] ?? string.Empty,
                Price = variantValues.BaseCostPrice,
                SKU = variantValues.SKU,
                Material = variantValues.Material,
                PrimaryImage = variantValues.PrimaryImage,
                ExtraImages = variantValues.ExtraImages
            };
        }
    }
}
