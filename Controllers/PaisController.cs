using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_desafio21dias.Models;
using api_desafio21dias.Servicos;
using MongoDB.Bson;

namespace api_desafio21dias.Controllers
{
    [ApiController]
    public class PaisController : ControllerBase
    {
        public PaisController()
        {
            this.paiMongoRepo = new PaisMongodb();
        }

        private PaisMongodb paiMongoRepo;

        // GET: /pais
        [HttpGet]
        [Route("/pais")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await paiMongoRepo.Todos());
        }

        // GET: /pais/5
        [HttpGet]
        [Route("/pais/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pai = await paiMongoRepo.BuscaPorId(ObjectId.Parse(id));
            if (pai == null)
            {
                return NotFound();
            }

            return StatusCode(200, pai);
        }

        // POST: /pais
        [HttpPost]
        [Route("/pais")]
        public async Task<IActionResult> Create(Pai pai)
        {
            if (ModelState.IsValid)
            {
                if(! (await AlunoServico.ValidarUsuario(pai.AlunoId)) )
                    return StatusCode(400, new { Mensagem = "O usuário passado não é válido ou não está cadastrado" });

                paiMongoRepo.Inserir(pai);

                return StatusCode(201, pai);
            }
            return StatusCode(400, new { Mensagem = "O Pai passado é inválido" });
        }

        // PUT: /pais/5
        [HttpPut]
        [Route("/pais/{id}")]
        public async Task<IActionResult> Edit(string id, Pai pai)
        {
            if (ModelState.IsValid)
            {
                if(! (await AlunoServico.ValidarUsuario(pai.AlunoId)) )
                    return StatusCode(400, new { Mensagem = "O usuário passado não é válido ou não está cadastrado" });

                try
                {
                    pai.Id = ObjectId.Parse(id);
                    paiMongoRepo.Atualizar(pai);
                }
                catch (Exception erro)
                {
                    if (! await PaiExists(pai.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return StatusCode(500, erro);
                    }
                }
                return StatusCode(200, pai);
            }
            return StatusCode(200, pai);
        }

        // DELETE: /pais/5
        [HttpDelete]
        [Route("/pais/{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            paiMongoRepo.RemovePorId(ObjectId.Parse(id));
            return StatusCode(204);
        }

        private async Task<bool> PaiExists(ObjectId id)
        {
            return (await paiMongoRepo.BuscaPorId(id)) != null;
        }
    }
}
