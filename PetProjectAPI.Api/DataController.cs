using Microsoft.AspNetCore.Mvc;
using PetProjectAPI.Bll;
using PetProjectAPI.Dal;

namespace PetProjectAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly IDataService _service;
    public DataController(IDataService service)
    {
        _service = service;
    }

    [HttpPost("save")]
    public async Task<IActionResult> Save([FromBody] DataDto dto)
    {
        await _service.SaveDataAsync(dto.Id, dto.Name, dto.Value);
        return Ok();
    }

    [HttpGet("read")]
    public async Task<ActionResult<List<DataEntity>>> Read()
    {
        var data = await _service.ReadDataAsync();
        return Ok(data);
    }
}

public class DataDto
{
    public DateTime Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; }
}
