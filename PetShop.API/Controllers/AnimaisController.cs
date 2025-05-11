using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Interfaces;
using PetShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.API.Controllers
{
    /// <summary>
    /// Gerencia as operações relacionadas aos animais no sistema.
    /// </summary>
    [ApiController]
    [Route("animais")]
    public class AnimaisController : ControllerBase
    {
        private readonly InterfaceAnimalService _animalService;
        public AnimaisController(InterfaceAnimalService animalService)
        {
            _animalService = animalService;
        }

        /// <summary>
        /// Retorna uma lista de todos os animais cadastrados.
        /// </summary>
        /// <returns>Uma lista de objetos Animal.</returns>
        /// <response code="200">Retorna a lista de animais com sucesso.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Animal>), 200)]
        public async Task<ActionResult<IEnumerable<Animal>>> Get()
        {
            var animais = await _animalService.GetAllAsync();
            return Ok(animais);
        }

        /// <summary>
        /// Retorna um animal específico com base no seu ID.
        /// </summary>
        /// <param name="id">O ID único do animal a ser buscado.</param>
        /// <returns>O objeto Animal correspondente ao ID.</returns>
        /// <response code="200">Retorna o animal encontrado com sucesso.</response>
        /// <response code="404">Se nenhum animal for encontrado com o ID fornecido.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Animal), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Animal>> Get(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        /// <summary>
        /// Adiciona um novo animal ao sistema.
        /// </summary>
        /// <param name="animal">Os dados do animal a serem adicionados no formato JSON.</param>
        /// <returns>O objeto Animal recém-criado.</returns>
        /// <response code="201">Retorna o animal recém-criado com sucesso.</response>
        /// <response code="400">Se os dados do animal forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Animal), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Animal>> Post([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _animalService.AddAsync(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        /// <summary>
        /// Atualiza as informações de um animal existente com base no seu ID.
        /// </summary>
        /// <param name="id">O ID único do animal a ser atualizado.</param>
        /// <param name="animal">Os dados atualizados do animal no formato JSON.</param>
        /// <returns>O objeto Animal com as informações atualizadas.</returns>
        /// <response code="200">Retorna o animal com as informações atualizadas com sucesso.</response>
        /// <response code="400">Se os dados do animal forem inválidos.</response>
        /// <response code="404">Se nenhum animal for encontrado com o ID fornecido.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Animal), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] Animal animal)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAnimal = await _animalService.GetByIdAsync(id);
            if (existingAnimal == null)
            {
                return NotFound();
            }

            existingAnimal.Nome = animal.Nome;
            existingAnimal.Raca = animal.Raca;
            existingAnimal.Idade = animal.Idade;

            await _animalService.UpdateAsync(existingAnimal);
            return Ok(existingAnimal);
        }

        /// <summary>
        /// Remove um animal do sistema com base no seu ID.
        /// </summary>
        /// <param name="id">O ID único do animal a ser removido.</param>
        /// <returns>Sem conteúdo (sucesso).</returns>
        /// <response code="204">O animal foi removido com sucesso.</response>
        /// <response code="404">Se nenhum animal for encontrado com o ID fornecido.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            await _animalService.DeleteAsync(id);
            return NoContent();
        }
    }
}