using System.Net;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : Controller
{
    private IStudentService _studentService;

    private IPsychologistService _psychologistService;

    public AuthenticationController(IStudentService studentService, IPsychologistService psychologistService)
    {
        _studentService = studentService;
        _psychologistService = psychologistService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] UserSignIn user)
    {
        var cognito = new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName("eu-west-1"));

        var request = new InitiateAuthRequest
        {
            ClientId = "1hcjcjgumctg2ud7vetrbj0hra",
            AuthFlow = AuthFlowType.USER_PASSWORD_AUTH
        };

        request.AuthParameters.Add("USERNAME", user.Username);
        request.AuthParameters.Add("PASSWORD", user.Password);

        var response = await cognito.InitiateAuthAsync(request);

        return Ok(new AuthResponse()
        {
            Token = response.AuthenticationResult.AccessToken,
            Id = user.Username
        });
    }

    [HttpPost]
    [Route("changePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordModel changePasswordRequest)
    {
        var client = new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName("eu-west-1"));

        var response = await client.AdminSetUserPasswordAsync(new AdminSetUserPasswordRequest()
        {
            Password = changePasswordRequest.NewPassword,
            Permanent = true,
            UserPoolId = "eu-west-1_xrBWzeoaT",
            Username = changePasswordRequest.Username
        });

        return Ok(response);
    }

    [HttpPost]
    [Route("signUp")]
    public async Task<IActionResult> SignUp([FromBody] UserProfile user)
    {
        var client = new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName("eu-west-1"));

        var response = await client.AdminCreateUserAsync(new AdminCreateUserRequest()
        {
            UserPoolId = "eu-west-1_xrBWzeoaT",
            Username = user.Username,
            TemporaryPassword = user.Password
        });

        if (response.HttpStatusCode == HttpStatusCode.OK)
        {
            switch (user.UserRole)
            {
                case "student":
                    break;
                case "psychologist":
                    var psychDto = new PsychologistDto()
                    {
                        FullName = user.FullName,
                        DOB = user.DOB,
                        Email = user.Username
                    };
                    await _psychologistService.AddPsychologistAsync(psychDto);
                    break;
            }
        
            return Ok(response);
        }
        
        return BadRequest();
    }
}