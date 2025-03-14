using Newtonsoft.Json;
using Shared.Index.Models;
using Struct.App.Api.Models.Language;

namespace Shared.Index
{
    public class IndexService
    {
        private readonly string _basePath;
        public IndexService()
        {
            _basePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Website/Data";
        }

        public void CreateIndex<T>(List<T> documents, IndexType indexType, LanguageModel language) where T : IndexModel
        {
            //create an product index in a local json file
            var index = new Models.Index<T>();
            index.Uid = Guid.NewGuid();
            index.Type = indexType;
            index.Language = language.CultureCode;

            //add the documents
            index.Documents = documents;

            var slavePath = $"{_basePath}/{indexType}_{index.Language}_slave.json";
            //create slaveindex file on disc
            File.WriteAllText(slavePath, JsonConvert.SerializeObject(index));

            //delete current master index file and and rename our slave file to take its place
            File.Delete($"{_basePath}/{indexType}_{index.Language}.json");

            File.Move($"{_basePath}/{indexType}_{index.Language}_slave.json", $"{_basePath}/{indexType}_{index.Language}.json");

        }

        public void UpdateDocuments<T>(List<T> indexModels, IndexType indexType, string cultureCode) where T : IndexModel
        {
            var index = GetFullIndex<T>(indexType, cultureCode);

            //match indexModels with the existing documents in the index
            foreach (var indexModel in indexModels)
            {
                var existingDocumentIndex = index.Documents.FindIndex(x => x.Id == indexModel.Id);
                if (existingDocumentIndex != -1)
                {
                    //update the existing document
                    index.Documents[existingDocumentIndex] = indexModel;
                }
                else
                {
                    //add the new document
                    index?.Documents.Add(indexModel);
                }
            }

            //save the updated index
            File.WriteAllText($"{_basePath}/{indexType}_{cultureCode}.json", JsonConvert.SerializeObject(index));
        }


        #region lookup for product portal
        public List<ProductIndexModel> GetProducts(LookupRequest lookupModel)
        {
            //read entire json file into memory
            var index = GetFullIndex<ProductIndexModel>(IndexType.ProductIndex, lookupModel.CultureCode);

            var documents = JsonConvert.DeserializeObject<List<ProductIndexModel>>(JsonConvert.SerializeObject(index?.Documents));

            if (documents == null || !documents.Any())
                return new List<ProductIndexModel>();

            //filter the documents based on the lookup model
            if (lookupModel.CategoryId.HasValue)
            {
                documents = documents.Where(x => x.Categories.Contains(lookupModel.CategoryId.Value)).ToList();
            }

            if (!string.IsNullOrEmpty(lookupModel.SearchQuery))
            {
                documents = documents.Where(x => x.Name.Contains(lookupModel.SearchQuery) || x.Description.Contains(lookupModel.SearchQuery)).ToList();
            }

            //paginate the results
            documents = documents.Take(lookupModel.PageSize).ToList();
            return documents;
        }

        public ProductIndexModel? GetProduct(int productId, string cultureCode)
        {
            //read entire json file into memory
            var index = GetFullIndex<ProductIndexModel>(IndexType.ProductIndex, cultureCode);
            var documents = JsonConvert.DeserializeObject<List<ProductIndexModel>>(JsonConvert.SerializeObject(index?.Documents));

            if (documents == null || !documents.Any())
                return new ProductIndexModel();

            return documents?.FirstOrDefault(x => x?.Id == productId);
        }

        private Models.Index<T>? GetFullIndex<T>(IndexType indexType, string cultureCode) where T : IndexModel
        {
            var filePath = $"{_basePath}/{indexType}_{cultureCode}.json";
            var jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Models.Index<T>>(jsonContent);
        }


        #endregion
    }
}