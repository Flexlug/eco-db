using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

using eco_db_backend.Models;
using System.Text;

namespace eco_db_backend.Database
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class DBWorker
    {
        private static DBWorker dBWorker = null;
        private DBWorker()
        {
            dBWorker = this;
        }

        
        public static DBWorker GetInstance()
        {
            return dBWorker ?? new DBWorker();
        }

        /// <summary>
        /// Обновляет базу данных из Google Docs Spreadsheets
        /// </summary>
        public string UpdateDataBase()
        {
            MongoClient client = new MongoClient("mongodb://heroku_g259d10f:1kdem3vpv9ab30e6m24gngpi9v@ds143666.mlab.com:43666/heroku_g259d10f");

            client.StartSession();

            var database = client.GetDatabase("heroku_g259d10f");
            var collection = database.GetCollection<BsonDocument>("products");

            StringBuilder sb = new StringBuilder();

            var filter = new BsonDocument();
            var people = collection.Find(filter).ToList();
            foreach (var doc in people)
            {
                sb.AppendLine(doc.ToString());
            }

            return sb.ToString();
        }
    }
}
