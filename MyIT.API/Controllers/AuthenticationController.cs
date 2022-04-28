using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Mvc;
using MyIT.Contracts;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : Controller
{
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] UserProfile user){
        var cognito = new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName("eu-west-1"));

        var request = new InitiateAuthRequest
        {
            ClientId = "1hcjcjgumctg2ud7vetrbj0hra",
            AuthFlow = AuthFlowType.USER_PASSWORD_AUTH
        };

        request.AuthParameters.Add("USERNAME", user.Username);
        request.AuthParameters.Add("PASSWORD", user.Password);

        var response = await cognito.InitiateAuthAsync(request);

        return Ok(response.AuthenticationResult);
    }
}