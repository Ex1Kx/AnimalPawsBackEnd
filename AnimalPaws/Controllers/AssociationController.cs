using AnimalPaws.Data.Repositories;
using AnimalPaws.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalPaws.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AssociationController : Controller
    {
        private readonly AssociationInterface _association;

        public AssociationController(AssociationInterface associationInterface)
        {
            _association = associationInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssociations()
        {
            return Ok(await _association.GetAssociations()); 
        }
        [HttpPost]
        public async Task<IActionResult> CretaeAssociation([FromBody] Associations associations)
        {
            if (associations == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _association.updloadAssociation(associations);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> updateAssociation([FromBody] Associations associations)
        {
            if (associations == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _association.updateAssociation(associations);
            return NoContent();
        }
        [HttpDelete("{id_association}")]
        public async Task<IActionResult> DeleteAssociation(int id_association)
        {
            await _association.deleteAssociation(new Associations() { id_association = id_association });

            return NoContent();
        }
    }
}
