using CentricaStoresApi.Data;
using CentricaStoresApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CentricaStoresApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SalePersonController : ControllerBase
{
    private readonly ILogger<SalePersonController> _logger;
    private readonly IDistrictsRepo _districtRepo;

    public SalePersonController(ILogger<SalePersonController> logger, IDistrictsRepo districtRepo)
    {
        _logger = logger;
        _districtRepo = districtRepo;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var _list = await _districtRepo.GetAll();
        if (_list != null)
        {
            return Ok(_list);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("GetDetailsByDistrict/{district}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDetailsByDistrict([FromRoute] string district)
    {
        var _list = await _districtRepo.GetDetailsByDistrict( district);
        if (_list != null)
        {
            return Ok(_list);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("InsertSalePerson")]
    [ProducesResponseType(  StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertSalePerson([FromBody] DistrictSalePerson districtSalePerson)
    {

     try
        {
            await _districtRepo.InsertSalePerson(districtSalePerson.name, districtSalePerson.districtname);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpPut("UpdateSalePerson")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateSalePerson([FromBody] DistrictSalePerson districtSalePerson)
    {

        try
        {
            await _districtRepo.UpdateSalePerson(districtSalePerson.name, districtSalePerson.districtname);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpDelete("DeleteSalePerson/{districtname}/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteInsertSalePerson([FromRoute] DistrictSalePerson districtSalePerson)
    {

        try
        {
            await _districtRepo.DeleteSalePerson(districtSalePerson.name, districtSalePerson.districtname);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }
}
