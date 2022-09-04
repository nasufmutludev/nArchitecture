using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
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
    }
}
