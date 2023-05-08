using agrconclude.API.Controllers;
using agrconclude.API.DTOs.Response;
using agrconclude.Application.DTOs.Request;
using agrconclude.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/contracts")]
[Authorize]
public class ContractsController : FacadeController
{
    private readonly IContractService _contractService;

    public ContractsController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(bool isMine)
    {
        var result = await _contractService.GetAllAsync<IEnumerable<ContractResponse>>(UserId, isMine);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var result = await _contractService.GetByIdAsync<ContractResponse>(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CreateContractVM model)
    {
        await _contractService.CreateAsync<CreateContractVM>(UserId, model);
        
        return Created("api/contracts",null);
    }

    [HttpPatch("{contractId}")]

    public async Task<IActionResult> SignContract(string contractId, [FromBody]SignContractVM model)
    {
        await _contractService.SignContractAsync(contractId, model);
        
        return Ok();
    }
    
}