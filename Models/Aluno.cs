using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_desafio21dias.Models
{
  public class Aluno
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Notas { get; set; }
  }
}