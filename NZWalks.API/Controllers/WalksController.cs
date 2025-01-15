using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO.AddRegionDTOs;
using NZWalks.API.Model.DTO.DTOs;
using NZWalks.API.Model.DTO.UpdateRegionDTOs;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        // This is a comment from the Repositroy to visual studio.


        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        // create walk
        //  Post: /api/walks

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddWalk([FromBody] AddWalkRequest_DTO addWalkRequest_DTO)
        {
            // Map dTo to domain model => AddWalkDTO to Walk domain model I mean.
            // So we don't want them manually we've already 'automapper'.

            

          //var walkDomainModel =  _mapper.Map<Walk>(addWalkRequest_DTO);

          //  await _walkRepository.AddWalkAsync(walkDomainModel);


          //  // Map Domain Model to DTO

          // var result =  _mapper.Map<WalkDto>(walkDomainModel);


          //  return Ok(result);


            // Check for Model validation.

            //if(ModelState.IsValid)
            //{
                var walkDomainModel = _mapper.Map<Walk>(addWalkRequest_DTO);

                await _walkRepository.AddWalkAsync(walkDomainModel);


                // Map Domain Model to DTO

                var result = _mapper.Map<WalkDto>(walkDomainModel);


                return Ok(result);
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}


        }


        // Get: Walks
        //Get: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10


        [HttpGet]

        // Implementing filtering, and sorting
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? IsAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walkDomainModel = await _walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy, IsAscending ?? true,  pageNumber,  pageSize);

            // Map Domain Model to DTO

            var walk = _mapper.Map<List<WalkDto>>(walkDomainModel);

            return Ok(walk);
        
        }

        // Get walk by Id
        // Get: /api/walks/{id}
        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetWalkByIdAsync(id);

            if(walkDomainModel == null)
                return NotFound();

            // Map domain model to dto

            var walk = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walk);
        }



        //Update Walk By Id
        // PUT: /api/Walks/{id}

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, UpdateWalkRequest_DTO updateWalkRequest_DTO)
        {
           // // Map DTO to domain model .

           // var walkDomainModel = _mapper.Map<Walk>(updateWalkRequest_DTO);

           //walkDomainModel = await _walkRepository.UpdateWalkByIdAsync(id, walkDomainModel);

        
           // // Map Domain Model to DTO

           // return Ok(_mapper.Map<WalkDto>(walkDomainModel));


            // check for model validation.

            //if(ModelState.IsValid)
            //{
                // Map DTO to domain model .

                var walkDomainModel = _mapper.Map<Walk>(updateWalkRequest_DTO);

                walkDomainModel = await _walkRepository.UpdateWalkByIdAsync(id, walkDomainModel);


                // Map Domain Model to DTO

                return Ok(_mapper.Map<WalkDto>(walkDomainModel));
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}

        }


        // Delete Walk By Id
        // Delete : /api/Walks/{id}

        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
          var deletedWalkDomainModel =  await _walkRepository.DeleteByIdAsync(id);
        
            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map domain model to DTO

          var store =   _mapper.Map<WalkDto>(deletedWalkDomainModel);


            return Ok(store);
        
        
        
        }
    }  
}
