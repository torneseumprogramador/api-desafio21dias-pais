using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_desafio21dias.Models
{
  public partial class Pai
  {
    #region "Propriedades"
    [BsonId()]
    [JsonIgnore]
    public ObjectId Codigo { get; set; }

    public string Id 
    { 
        get
        {
            return this.Codigo.ToString();
        } 
        set
        {
            this.Codigo = ObjectId.Parse(value);
        }
    }

    [BsonElement("nome")]
    [BsonRequired()]
    public string Nome { get; set; }

    [BsonElement("aluno_id")]
    [BsonRequired()]
    public int AlunoId { get; set; }

    [BsonElement("aluno")]
    [BsonRequired()]
    public Aluno Aluno { get; set; }

    #endregion

    #region Metodos
    

    #endregion
  }
}