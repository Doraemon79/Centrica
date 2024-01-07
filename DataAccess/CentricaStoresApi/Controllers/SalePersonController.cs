﻿using CentricaStoresApi.BudsinessLogic;
using CentricaStoresApi.Data;
using CentricaStoresApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CentricaStoresApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SalePersonController : ControllerBase
{
    private readonly ILogger<SalePersonController> _logger;
    private readonly IDistrictsRepo _districtRepo;
    private readonly IResultChecker _resultChecker;

    public SalePersonController(ILogger<SalePersonController> logger, IDistrictsRepo districtRepo, IResultChecker resultChecker)
    {
        _logger = logger;
        _districtRepo = districtRepo;
        _resultChecker = resultChecker;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<string>> GetAll()
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
    public async Task<ActionResult<string>> GetDetailsByDistrict([FromRoute] string district)
    {
        var _list = await _districtRepo.GetDetailsByDistrict(district);
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<string>> InsertSalePerson([FromBody] DistrictSalePerson districtSalePerson)
    {

        try
        {
            var _list = await _districtRepo.GetDetailsByDistrict(districtSalePerson.districtname);
            if (_resultChecker.PresentInDistrict(_list, districtSalePerson.name))
            {
                return BadRequest("A saleperson with that name is present already");
            }
            else
            {
                await _districtRepo.InsertSalePerson(districtSalePerson.name, districtSalePerson.districtname);
                return Created();
            }

        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpPut("UpdateSalePerson")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<string>> UpdateSalePerson([FromBody] DistrictSalePerson districtSalePerson)
    {

        try
        {
            await _districtRepo.UpdateSalePerson(districtSalePerson.name, districtSalePerson.districtname);
            return NoContent();

        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpDelete("DeleteSalePerson/{districtname}/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteSalePerson([FromRoute] DistrictSalePerson districtSalePerson)
    {
        try
        {
            var _list = await _districtRepo.GetDetailsByDistrict(districtSalePerson.districtname);
            if (!_resultChecker.PresentInDistrict(_list, districtSalePerson.name))
            {
                return BadRequest("Delete was not done correctly please check again your request and try again");
            }
            if (_resultChecker.SalePersonIsPrimary(_list, districtSalePerson.name))
            {
                return BadRequest("Delete cannot be done on Primary Saleperson");
            }

            await _districtRepo.DeleteSalePerson(districtSalePerson.name, districtSalePerson.districtname);


            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }


    }
}
