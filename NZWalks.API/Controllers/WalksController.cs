﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
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
        public async Task<IActionResult> AddWalk([FromBody] AddWalkRequest_DTO addWalkRequest_DTO)
        {
            // Map dTo to domain model => AddWalkDTO to Walk domain model I mean.
            // So we don't want them manually we've already 'automapper'.

          var walkDomainModel =  _mapper.Map<Walk>(addWalkRequest_DTO);

            await _walkRepository.AddWalkAsync(walkDomainModel);


            // Map Domain Model to DTO

           var result =  _mapper.Map<WalkDto>(walkDomainModel);


            return Ok(result);


        }

        // Get: Walks
        //Get: /api/walks


        [HttpGet]

        public async Task<IActionResult> GetAllWalks()
        {
            var walkDomainModel = await _walkRepository.GetAllWalksAsync();

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

        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, )
        {

        }

    }
}
