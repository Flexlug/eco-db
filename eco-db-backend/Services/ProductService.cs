using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eco_db_backend.Models;

using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

using Newtonsoft.Json;

namespace eco_db_backend.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        #region snippet_BookServiceConstructor
        public ProductService(IProductsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }
        #endregion

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string barcodeType, string barcodeValue)
        {
            var filter = new BsonDocument("$and", new BsonArray()
            {
                new BsonDocument("BarcodeType", barcodeType),
                new BsonDocument("BarcodeValue", barcodeValue)
            });

            var result = _products.Find(filter).FirstOrDefault();

            return result;
        }

    public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string barcodeType, string barcodeValue, Product bookIn) =>
            _products.ReplaceOne(product => product.BarcodeType == barcodeType && product.BarcodeValue == barcodeValue, bookIn);

        public void Remove(string barcodeType, string barcodeValue) =>
            _products.DeleteOne(product => product.BarcodeType == barcodeType && product.BarcodeValue == barcodeValue);
    }
}
