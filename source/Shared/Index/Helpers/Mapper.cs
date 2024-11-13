﻿using Shared.Index.Models;
using Struct.PIM.Api.Models.Language;
using Struct.PIM.Api.Models.Variant;
using Struct.PIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Index.Helpers
{
    public static class Mapper
    {
        public static ProductIndexModel Map(LanguageModel language, int productId, ClothingProductModel product, List<VariantIndexModel> productVariants, List<int> productClassification)
        {
            return new ProductIndexModel
            {
                Id = productId,
                Name = product.Name.FirstOrDefault(x=>x.CultureCode == language.CultureCode)?.Data ?? string.Empty,
                StyleNumber = product.StyleNumber,                
                Description = product.Description.FirstOrDefault(x => x.CultureCode == language.CultureCode)?.Data ?? string.Empty,
                Brand = product.Brand,
                Categories = productClassification,
                Variants = productVariants,
                ImageUrl = product.PrimaryImage ?? $"placeholder_{new Random().Next(1, 8)}.webp"
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