using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Model;
using RepositoryPattern.Models;
using RepositoryPattern.Repository.Interface;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private ISampleRepository _sampleRepository;
        public SampleController(ISampleRepository sampleRepository)
        {
            this._sampleRepository = sampleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Sample> samples = await this._sampleRepository.GetAllAsync();
            return Ok(samples);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]APISample apiSample)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            Sample sample = new Sample();
            sample.Name = apiSample.Name;
            sample.CreatedBy = 1;//todo
            sample.ModifiedBy = 1;//todo
            sample.ModifiedDate = DateTime.Now;
            sample.CreatedDate = DateTime.Now;
            this._sampleRepository.Insert(sample);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Sample sample = this._sampleRepository.Get(id);
            return Ok(sample);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]APISample apiSample)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Sample sample = new Sample();
            sample.Id = apiSample.Id;
            sample.Name = apiSample.Name;
            sample.CreatedBy = 1; //todo
            sample.ModifiedBy = 1; //todo
            sample.ModifiedDate = DateTime.Now;
            sample.CreatedDate = DateTime.Now;
            this._sampleRepository.Update(sample);
            return Ok();
        }
    }
}