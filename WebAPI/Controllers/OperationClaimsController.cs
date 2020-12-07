﻿using Business.Handlers.OperationClaims.Commands;
using Business.Handlers.OperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    ///  
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseApiController
    {
        ///<summary>
        ///OperationClaims listeler
        ///</summary>
        ///<remarks>bla bla bla OperationClaims</remarks>
        ///<return>OperationClaims Listesi</return>
        ///<response code="200"></response>  
        [HttpGet("getall")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetOperationClaimsQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// OperationClaim Günceller.
        /// </summary>
        /// <param name="updateOperationClaim"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaim)
        {
            var result = await Mediator.Send(updateOperationClaim);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}

