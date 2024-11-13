using Newtonsoft.Json;
using Shared.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Shared.Import
{
    public class ImportService
    {
        /// <summary>
        /// Read the file category bogus data and deserializes it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public List<CategoryBogusModel> ReadCategoryBogusData()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Import\\Task1Data\\CategoryBogusData.json";

            var file = new FileInfo(filePath);
            string result;
            using (StreamReader r = new StreamReader(file.FullName))
            {
                result = r.ReadToEnd();

            }
            if (string.IsNullOrEmpty(result))
                throw new IOException("Nothing was read from file");

            List<CategoryBogusModel> items = JsonConvert.DeserializeObject<List<CategoryBogusModel>>(result);
            return items;
        }

        public IEnumerable<VariantBogusModel> ReadExistingVariantDeltaBogusData()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Import\\Task3Data\\ExistingVariantBogusData.json";

            var file = new FileInfo(filePath);
            string result;
            using (StreamReader r = new StreamReader(file.FullName))
            {
                result = r.ReadToEnd();

            }
            if (string.IsNullOrEmpty(result))
                throw new IOException("Nothing was read from file");

            List<VariantBogusModel> items = JsonConvert.DeserializeObject<List<VariantBogusModel>>(result);
            return items;
        }
        
        public IEnumerable<VariantBogusModel> ReadExistingAndNewVariantDeltaBogusData()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Import\\Task3Data\\ExistingAndNewVariantBogusData.json";

            var file = new FileInfo(filePath);
            string result;
            using (StreamReader r = new StreamReader(file.FullName))
            {
                result = r.ReadToEnd();

            }
            if (string.IsNullOrEmpty(result))
                throw new IOException("Nothing was read from file");

            List<VariantBogusModel> items = JsonConvert.DeserializeObject<List<VariantBogusModel>>(result);
            return items;
        }

        public IEnumerable<GlobalListBogusModel> ReadGlobalListBogusData()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Import\\Task3Data\\GlobalListBogusData.json";

            var file = new FileInfo(filePath);
            string result;
            using (StreamReader r = new StreamReader(file.FullName))
            {
                result = r.ReadToEnd();

            }
            if (string.IsNullOrEmpty(result))
                throw new IOException("Nothing was read from file");

            List<GlobalListBogusModel> items = JsonConvert.DeserializeObject<List<GlobalListBogusModel>>(result);
            return items;
        }

        /// <summary>
        /// Read the file product bogus data and deserializes it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public List<ProductBogusModel> ReadProductBogusData()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Import\\Task1Data\\ProductBogusData.json";

            var file = new FileInfo(filePath);
            string result;
            using (StreamReader r = new StreamReader(file.FullName))
            {
                result = r.ReadToEnd();

            }
            if (string.IsNullOrEmpty(result))
                throw new IOException("Nothing was read from file");

            List<ProductBogusModel> items = JsonConvert.DeserializeObject<List<ProductBogusModel>>(result);
            return items;
        }

        /// <summary>
        /// Read the file product bogus data and deserializes it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public List<VariantBogusModel> ReadVariantBogusData()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Import\\Task1Data\\VariantBogusData.json";

            var file = new FileInfo(filePath);
            string result;
            using (StreamReader r = new StreamReader(file.FullName))
            {
                result = r.ReadToEnd();

            }
            if (string.IsNullOrEmpty(result))
                throw new IOException("Nothing was read from file");

            List<VariantBogusModel> items = JsonConvert.DeserializeObject<List<VariantBogusModel>>(result);
            return items;
        }
    }
}
