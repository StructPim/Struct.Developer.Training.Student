using System;
using System.Collections.Generic;
using Struct.PIM.Api.Models.Shared;
using Struct.PIM.Api.Models.Attribute;

namespace Struct.PIM.Models
{
    #region ProductModels
    public partial class ClothingProductModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Name
   /// </summary>
   public virtual List<LocalizedData<string>> Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(List<LocalizedData<string>>); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

   /// <summary>
   /// Style number
   /// </summary>
   public virtual string StyleNumber
   {
       get { dynamic value; return _values.TryGetValue("StyleNumber", out value) ? value : default(string); }
       set { _values["StyleNumber"] = value; }
   }

   public bool ShouldSerializeStyleNumber()
   {
       return _values.ContainsKey("StyleNumber");
   }

   /// <summary>
   /// Brand
   /// </summary>
   public virtual BrandsGlobalListModel Brand
   {
       get { dynamic value; return _values.TryGetValue("Brand", out value) ? value : default(BrandsGlobalListModel); }
       set { _values["Brand"] = value; }
   }

   public bool ShouldSerializeBrand()
   {
       return _values.ContainsKey("Brand");
   }

   /// <summary>
   /// Description
   /// </summary>
   public virtual List<LocalizedData<string>> Description
   {
       get { dynamic value; return _values.TryGetValue("Description", out value) ? value : default(List<LocalizedData<string>>); }
       set { _values["Description"] = value; }
   }

   public bool ShouldSerializeDescription()
   {
       return _values.ContainsKey("Description");
   }

   /// <summary>
   /// Country of origin
   /// </summary>
   public virtual List<LocalizedData<string>> CountryOfOrigin
   {
       get { dynamic value; return _values.TryGetValue("CountryOfOrigin", out value) ? value : default(List<LocalizedData<string>>); }
       set { _values["CountryOfOrigin"] = value; }
   }

   public bool ShouldSerializeCountryOfOrigin()
   {
       return _values.ContainsKey("CountryOfOrigin");
   }

   /// <summary>
   /// Sales channels
   /// </summary>
   public virtual List<SaleChannelsGlobalListModel> SalesChannels
   {
       get { dynamic value; return _values.TryGetValue("SalesChannels", out value) ? value : default(List<SaleChannelsGlobalListModel>); }
       set { _values["SalesChannels"] = value; }
   }

   public bool ShouldSerializeSalesChannels()
   {
       return _values.ContainsKey("SalesChannels");
   }

   /// <summary>
   /// ERP type
   /// </summary>
   public virtual string ERPType
   {
       get { dynamic value; return _values.TryGetValue("ERPType", out value) ? value : default(string); }
       set { _values["ERPType"] = value; }
   }

   public bool ShouldSerializeERPType()
   {
       return _values.ContainsKey("ERPType");
   }

   /// <summary>
   /// PrimaryImage
   /// </summary>
   public virtual string PrimaryImage
   {
       get { dynamic value; return _values.TryGetValue("PrimaryImage", out value) ? value : default(string); }
       set { _values["PrimaryImage"] = value; }
   }

   public bool ShouldSerializePrimaryImage()
   {
       return _values.ContainsKey("PrimaryImage");
   }

   /// <summary>
   /// Extra images
   /// </summary>
   public virtual List<string> ExtraImages
   {
       get { dynamic value; return _values.TryGetValue("ExtraImages", out value) ? value : default(List<string>); }
       set { _values["ExtraImages"] = value; }
   }

   public bool ShouldSerializeExtraImages()
   {
       return _values.ContainsKey("ExtraImages");
   }

}

    #endregion

    #region VariantModels
    public partial class ClothingVariantModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// SKU
   /// </summary>
   public virtual string SKU
   {
       get { dynamic value; return _values.TryGetValue("SKU", out value) ? value : default(string); }
       set { _values["SKU"] = value; }
   }

   public bool ShouldSerializeSKU()
   {
       return _values.ContainsKey("SKU");
   }

   /// <summary>
   /// Sales channels
   /// </summary>
   public virtual List<SaleChannelsGlobalListModel> SalesChannels
   {
       get { dynamic value; return _values.TryGetValue("SalesChannels", out value) ? value : default(List<SaleChannelsGlobalListModel>); }
       set { _values["SalesChannels"] = value; }
   }

   public bool ShouldSerializeSalesChannels()
   {
       return _values.ContainsKey("SalesChannels");
   }

   /// <summary>
   /// Base cost price
   /// </summary>
   public virtual decimal? BaseCostPrice
   {
       get { dynamic value; return _values.TryGetValue("BaseCostPrice", out value) ? value : default(decimal?); }
       set { _values["BaseCostPrice"] = value; }
   }

   public bool ShouldSerializeBaseCostPrice()
   {
       return _values.ContainsKey("BaseCostPrice");
   }

   /// <summary>
   /// Cost prices
   /// </summary>
   public virtual List<CostPricesModel> CostPrices
   {
       get { dynamic value; return _values.TryGetValue("CostPrices", out value) ? value : default(List<CostPricesModel>); }
       set { _values["CostPrices"] = value; }
   }

   public bool ShouldSerializeCostPrices()
   {
       return _values.ContainsKey("CostPrices");
   }

   /// <summary>
   /// Color
   /// </summary>
   public virtual ColorsGlobalListModel Color
   {
       get { dynamic value; return _values.TryGetValue("Color", out value) ? value : default(ColorsGlobalListModel); }
       set { _values["Color"] = value; }
   }

   public bool ShouldSerializeColor()
   {
       return _values.ContainsKey("Color");
   }

   /// <summary>
   /// Size
   /// </summary>
   public virtual string Size
   {
       get { dynamic value; return _values.TryGetValue("Size", out value) ? value : default(string); }
       set { _values["Size"] = value; }
   }

   public bool ShouldSerializeSize()
   {
       return _values.ContainsKey("Size");
   }

   /// <summary>
   /// Material
   /// </summary>
   public virtual MaterialGlobalListModel Material
   {
       get { dynamic value; return _values.TryGetValue("Material", out value) ? value : default(MaterialGlobalListModel); }
       set { _values["Material"] = value; }
   }

   public bool ShouldSerializeMaterial()
   {
       return _values.ContainsKey("Material");
   }

   /// <summary>
   /// Package size
   /// </summary>
   public virtual PackageSizeModel PackageSize
   {
       get { dynamic value; return _values.TryGetValue("PackageSize", out value) ? value : default(PackageSizeModel); }
       set { _values["PackageSize"] = value; }
   }

   public bool ShouldSerializePackageSize()
   {
       return _values.ContainsKey("PackageSize");
   }

   /// <summary>
   /// Weight
   /// </summary>
   public virtual decimal? Weight
   {
       get { dynamic value; return _values.TryGetValue("Weight", out value) ? value : default(decimal?); }
       set { _values["Weight"] = value; }
   }

   public bool ShouldSerializeWeight()
   {
       return _values.ContainsKey("Weight");
   }

   /// <summary>
   /// PrimaryImage
   /// </summary>
   public virtual string PrimaryImage
   {
       get { dynamic value; return _values.TryGetValue("PrimaryImage", out value) ? value : default(string); }
       set { _values["PrimaryImage"] = value; }
   }

   public bool ShouldSerializePrimaryImage()
   {
       return _values.ContainsKey("PrimaryImage");
   }

   /// <summary>
   /// Extra images
   /// </summary>
   public virtual List<string> ExtraImages
   {
       get { dynamic value; return _values.TryGetValue("ExtraImages", out value) ? value : default(List<string>); }
       set { _values["ExtraImages"] = value; }
   }

   public bool ShouldSerializeExtraImages()
   {
       return _values.ContainsKey("ExtraImages");
   }

}

    #endregion

    #region CategoryModels
    public partial class MasterCategoryModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Alias
   /// </summary>
   public virtual string Alias
   {
       get { dynamic value; return _values.TryGetValue("Alias", out value) ? value : default(string); }
       set { _values["Alias"] = value; }
   }

   public bool ShouldSerializeAlias()
   {
       return _values.ContainsKey("Alias");
   }

   /// <summary>
   /// Name
   /// </summary>
   public virtual List<LocalizedData<string>> Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(List<LocalizedData<string>>); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

}

    #endregion

    #region VariantGroupModels
    public partial class ClothingVariantGroupModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

}

    #endregion

    #region Attributes
    public partial class PackageSizeModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Height
   /// </summary>
   public virtual decimal? Height
   {
       get { dynamic value; return _values.TryGetValue("Height", out value) ? value : default(decimal?); }
       set { _values["Height"] = value; }
   }

   public bool ShouldSerializeHeight()
   {
       return _values.ContainsKey("Height");
   }

   /// <summary>
   /// Width
   /// </summary>
   public virtual decimal? Width
   {
       get { dynamic value; return _values.TryGetValue("Width", out value) ? value : default(decimal?); }
       set { _values["Width"] = value; }
   }

   public bool ShouldSerializeWidth()
   {
       return _values.ContainsKey("Width");
   }

   /// <summary>
   /// Length
   /// </summary>
   public virtual decimal? Length
   {
       get { dynamic value; return _values.TryGetValue("Length", out value) ? value : default(decimal?); }
       set { _values["Length"] = value; }
   }

   public bool ShouldSerializeLength()
   {
       return _values.ContainsKey("Length");
   }

}


    public partial class CostPricesModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Price
   /// </summary>
   public virtual decimal? Price
   {
       get { dynamic value; return _values.TryGetValue("Price", out value) ? value : default(decimal?); }
       set { _values["Price"] = value; }
   }

   public bool ShouldSerializePrice()
   {
       return _values.ContainsKey("Price");
   }

   /// <summary>
   /// Currency
   /// </summary>
   public virtual CurrencyGlobalListModel Currency
   {
       get { dynamic value; return _values.TryGetValue("Currency", out value) ? value : default(CurrencyGlobalListModel); }
       set { _values["Currency"] = value; }
   }

   public bool ShouldSerializeCurrency()
   {
       return _values.ContainsKey("Currency");
   }

}

    #endregion

    #region GlobalListModels
    public partial class BrandsGlobalListModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Name
   /// </summary>
   public virtual string Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(string); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

   /// <summary>
   /// Logo
   /// </summary>
   public virtual string Logo
   {
       get { dynamic value; return _values.TryGetValue("Logo", out value) ? value : default(string); }
       set { _values["Logo"] = value; }
   }

   public bool ShouldSerializeLogo()
   {
       return _values.ContainsKey("Logo");
   }

}

public partial class SaleChannelsGlobalListModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Alias
   /// </summary>
   public virtual string Alias
   {
       get { dynamic value; return _values.TryGetValue("Alias", out value) ? value : default(string); }
       set { _values["Alias"] = value; }
   }

   public bool ShouldSerializeAlias()
   {
       return _values.ContainsKey("Alias");
   }

   /// <summary>
   /// Name
   /// </summary>
   public virtual string Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(string); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

}

public partial class ColorsGlobalListModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Name
   /// </summary>
   public virtual List<LocalizedData<string>> Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(List<LocalizedData<string>>); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

   /// <summary>
   /// Hex code
   /// </summary>
   public virtual string HexCode
   {
       get { dynamic value; return _values.TryGetValue("HexCode", out value) ? value : default(string); }
       set { _values["HexCode"] = value; }
   }

   public bool ShouldSerializeHexCode()
   {
       return _values.ContainsKey("HexCode");
   }

}

public partial class MaterialGlobalListModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Name
   /// </summary>
   public virtual List<LocalizedData<string>> Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(List<LocalizedData<string>>); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

}

public partial class CurrencyGlobalListModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Name
   /// </summary>
   public virtual string Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(string); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

   /// <summary>
   /// Symbol
   /// </summary>
   public virtual string Symbol
   {
       get { dynamic value; return _values.TryGetValue("Symbol", out value) ? value : default(string); }
       set { _values["Symbol"] = value; }
   }

   public bool ShouldSerializeSymbol()
   {
       return _values.ContainsKey("Symbol");
   }

   /// <summary>
   /// Conversion factor
   /// </summary>
   public virtual decimal? ConversionFactor
   {
       get { dynamic value; return _values.TryGetValue("ConversionFactor", out value) ? value : default(decimal?); }
       set { _values["ConversionFactor"] = value; }
   }

   public bool ShouldSerializeConversionFactor()
   {
       return _values.ContainsKey("ConversionFactor");
   }

}

public partial class SuppliersGlobalListModel
{
   private Dictionary<string, dynamic> _values = new Dictionary<string, dynamic>();

   /// <summary>
   /// Name
   /// </summary>
   public virtual string Name
   {
       get { dynamic value; return _values.TryGetValue("Name", out value) ? value : default(string); }
       set { _values["Name"] = value; }
   }

   public bool ShouldSerializeName()
   {
       return _values.ContainsKey("Name");
   }

   /// <summary>
   /// SupplierId
   /// </summary>
   public virtual string SupplierId
   {
       get { dynamic value; return _values.TryGetValue("SupplierId", out value) ? value : default(string); }
       set { _values["SupplierId"] = value; }
   }

   public bool ShouldSerializeSupplierId()
   {
       return _values.ContainsKey("SupplierId");
   }

   /// <summary>
   /// Phone
   /// </summary>
   public virtual string Phone
   {
       get { dynamic value; return _values.TryGetValue("Phone", out value) ? value : default(string); }
       set { _values["Phone"] = value; }
   }

   public bool ShouldSerializePhone()
   {
       return _values.ContainsKey("Phone");
   }

   /// <summary>
   /// Email
   /// </summary>
   public virtual string Email
   {
       get { dynamic value; return _values.TryGetValue("Email", out value) ? value : default(string); }
       set { _values["Email"] = value; }
   }

   public bool ShouldSerializeEmail()
   {
       return _values.ContainsKey("Email");
   }

}


        #endregion
}

