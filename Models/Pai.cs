using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_desafio21dias.Models
{
  public partial class Pai
  {
    #region "Propriedades"
    [BsonId()]
    public ObjectId Id { get; set; }

    [BsonElement("nome")]
    [BsonRequired()]
    public string Nome { get; set; }

    [BsonElement("aluno_id")]
    [BsonRequired()]
    public int AlunoId { get; set; }

    #endregion

    #region Metodos
    

    #endregion
  }
}