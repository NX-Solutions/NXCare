using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NXCare.Domain.Interfaces.Services;
using NXCare.Domain.Requests;
using NXCare.Domain.Responses.Auth;

namespace NXCare.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        // GET: AuthController
        private readonly ILogger<AuthController> logger;
        private readonly IAuthenticationService authenticationService;

        public AuthController(ILogger<AuthController> logger, IAuthenticationService authenticationService)
        {
            this.logger = logger;
            this.authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<ActionResult> AuthenticateAsync([FromBody] AuthenticationRequest authenticationRequest)
        {
            logger.LogInformation("Auth");

            AuthenticationResponse response = await authenticationService.AuthenticateAsync(authenticationRequest.Username, authenticationRequest.Password);


            return Ok(response);
        }

    }
}
