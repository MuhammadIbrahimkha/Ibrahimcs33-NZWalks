﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/regions

    [Route("api/[controller]")]
    [ApiController]    
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {
            _context = context;
           _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // Get All Regions
        // Get: https://localhhost:1234/api/regions

        [HttpGet]
        public async  Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models

            //var regions = await _context.Regions.ToListAsync();
            // Now we don't need this '_context' any more. We will use the repository instead.

            var regions = await _regionRepository.GetAllAsync();

            // Map Domain Models to DTO
            //var regionDto = new List<RegionDto>();
            //foreach (var region in regions)
            //{
            //    regionDto.Add(new RegionDto
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}


            // Use automapper instead of the above code.
            // Map Domain Model to DTO

           //var regionDto = _mapper.Map<List<RegionDto>>(regions);
            // we can even make the code more simple like this:

            // Return DTO to the client.

            //return Ok(regionDto);

            // Like this :

            return Ok(_mapper.Map<List<RegionDto>>(regions));
        }

        // GET SINGLE REGION (Get Region By ID)
        //GET: https://localhost:1234/api/regions/{id}


        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = _context.Regions.Find(id);
            // Get Region Domain Model From Database

            //var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var region = await _regionRepository.GetByIdAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO

            //var regionDto = new RegionDto()
            //{
            //    Id = region.Id,
            //    Name = region.Name,
            //    Code = region.Code,
            //    RegionImageUrl = region.RegionImageUrl
            //};

            // You can do the above step which was in the Get Method to even more shorter the code.


            // Map/Convert Region Domain Model to Region DTO through Automapper

            var regionDto =  _mapper.Map<RegionDto>(region);


            // Return Region DTO to the client
            return Ok(regionDto);
        }


        // POST: https://localhost:1234/api/regions

        [HttpPost]

        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequest_DTO addRegionRequest_DTO)
        {
            // Map AddRegionRequest_DTO to Region Domain Model

            //var regionDomainModel = new Region
            //{
            //    Name = addRegionRequest_DTO.Name,
            //    Code = addRegionRequest_DTO.Code,
            //    RegionImageUrl = addRegionRequest_DTO.RegionImageUrl
            //};

            // Now automapper will do the above task for us.

            var regionDomainModel = _mapper.Map<Region>(addRegionRequest_DTO);

            // Use domain model to create region

            // await _context.Regions.AddAsync(regionDomainModel);

            // You can must write the following line to save the changes to the database.

            // await _context.SaveChangesAsync();

            regionDomainModel = await _regionRepository.AddRegionAsync(regionDomainModel);

            // Map Domain Model to DTO

            //var regionDto = new RegionDto()
            //{
            //    Id = regionDomainModel.Id,
            //    Name = regionDomainModel.Name,
            //    Code = regionDomainModel.Code,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};


            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            // Return 201 Created Status Code

            return CreatedAtAction(nameof(GetById), new  { id = regionDto.Id }, regionDto);

        }


        // Update Particular Region
        // PUT: https://localhost:1234/api/regions/{id}

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegion_DTO updateRegion_DTO)
        {
            //var regionDomainModel = await  _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //Map DTO to Domain Model

            //var regionDomainModel = new Region
            //{
            //    Code = updateRegion_DTO.Code,
            //    Name = updateRegion_DTO.Name,
            //    RegionImageUrl = updateRegion_DTO.RegionImageUrl
            //};

            var regionDomainModel = _mapper.Map<Region>(updateRegion_DTO);


            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // else, if the region is found then update the region

           
            // Save Changes to the database
          //await _context.SaveChangesAsync();


            // Convert Domain Model to DTO

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            // We always pass DTO to the client.
            return Ok(regionDto);
        }


        // Delete Region
        //Delete: https://localhost:portnumber/api/regions/{id}


        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteRegion([FromRoute]Guid id)
        {
            //var regionDomainModel = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomainModel = await _regionRepository.DeleteRegionAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // Delete region

            // Now we no longer need the following two lines because the Repository will handle the deletion.


            // await _regionRepository.Remove(regionDomainModel);

            //await _regionRepository.SaveChangesAsync(); 

            // return 204 No Content Status Code for successful deletion.

            // Map domain model classes to DTO

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }


    }
}
