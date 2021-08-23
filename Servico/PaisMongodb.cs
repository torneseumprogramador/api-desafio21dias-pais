
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using api_desafio21dias.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace api_desafio21dias.Servicos
{
    public class PaisMongodb
    {
        private IMongoDatabase mongoDatabase;
        public PaisMongodb()
        {
            var cnn = Program.MongoCnn.Split('#');
            this.mongoDatabase = new MongoClient(cnn[0]).GetDatabase(cnn[1]);            
        }

        private IMongoCollection<Pai> mongoCollection()
        {
           return this.mongoDatabase.GetCollection<Pai>("pais");
        }

        public async void Inserir(Pai pai)
        {
            await this.mongoCollection().InsertOneAsync(pai);
        }

        public async void Atualizar(Pai pai)
        {
            var filter = Builders<Pai>.Filter.Eq(c => c.Id == pai.Id, true);
            await this.mongoCollection().UpdateOneAsync(filter, new ObjectUpdateDefinition<Pai>(pai));
        }

        public async void RemovePorId(ObjectId id)
        {
            await this.mongoCollection().DeleteOneAsync(p=> p.Id == id);
        }

        public async Task<IList<Pai>> Todos()
        {
            return await this.mongoCollection().AsQueryable().ToListAsync();
        }

        public async Task<Pai> BuscaPorId(ObjectId id)
        {
            return await this.mongoCollection().AsQueryable().Where(p => p.Id == id).FirstAsync();
        }
    }
}