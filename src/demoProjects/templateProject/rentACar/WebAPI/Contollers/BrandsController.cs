﻿using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandEntityCommand brandEntityCommand)
        {
            CreatedBrandEntityDto result = await Mediator.Send(brandEntityCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            //GetListBrandQuery getListBrandQuery=new GetListBrandQuery();
            //Yeni Kullanım
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }
    }
}
