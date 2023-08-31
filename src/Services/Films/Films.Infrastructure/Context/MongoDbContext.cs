using Films.Domain.Models;
using MassTransit.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Context
{
	public class MongoDbContext
	{
		public readonly MongoClient client;
		public readonly IMongoDatabase database;
		public readonly IMongoCollection<FilmToMongo> mongoCollection;

		public MongoDbContext(IOptions<MongoDbSettings> options)
		{
			client = new MongoClient(options.Value.ConnectionString);
			database = client.GetDatabase(options.Value.DatabaseName);
			mongoCollection = database.GetCollection<FilmToMongo>(options.Value.CollectionName);
		}
	}
}
