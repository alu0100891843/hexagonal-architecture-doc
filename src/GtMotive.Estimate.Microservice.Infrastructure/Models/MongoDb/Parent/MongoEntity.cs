#pragma warning disable IDE0060 // Quitar el parámetro no utilizado
using System;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Models.MongoDb.Parent
{
    public abstract class MongoEntity
    {
        public static void ConfigureRestrictions<T>(IMongoCollection<T> collection)
        {
            throw new NotImplementedException("ConfigureRestrictions no implementado para tipo " + typeof(T).Name);
        }
    }
}
