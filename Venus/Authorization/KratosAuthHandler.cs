using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Venus.Authorization;

public class KratosAuthenticationOptions : AuthenticationSchemeOptions
{
}

public class KratosAuthHandler : AuthenticationHandler<KratosAuthenticationOptions>
{
    private readonly string _sessionCookieName = "ory_kratos_session";
    private readonly KratosService _kratosService;

    public KratosAuthHandler(
        IOptionsMonitor<KratosAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        KratosService kratosService
    ) : base(options, logger, encoder)
    {
        _kratosService = kratosService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // ORY Kratos can authenticate against an API through two different methods:
        // Cookie Authentication is for Browser Clients and sends a Session Cookie with each request.
        // Bearer Token Authentication is for Native Apps and other APIs and sends an Authentication header with each request.
        // We are validating both ways here by sending a /whoami request to ORY Kratos passing the provided authentication
        // methods on to Kratos.
        try
        {                
            // Check, if Cookie was set
            if (Request.Cookies.ContainsKey(_sessionCookieName))
            {
                var cookie = Request.Cookies[_sessionCookieName];
                var id = await _kratosService.GetUserIdByCookie(_sessionCookieName, cookie);
                return ValidateToken(id);
            }

            // Check, if Authorization header was set
            if (Request.Headers.ContainsKey("Authorization"))
            {
                var token = Request.Headers["Authorization"];
                var id = await _kratosService.GetUserIdByToken(token);
                return ValidateToken(id);
            }

            // If neither Cookie nor Authorization header was set, the request can't be authenticated.
            return AuthenticateResult.NoResult();
        }
        catch (Exception ex)
        {
            // If an error occurs while trying to validate the token, the Authentication request fails.
            return AuthenticateResult.Fail(ex.Message);
        }
    }

    private AuthenticateResult ValidateToken(string userId)
    {            
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId),
        };
 
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new System.Security.Principal.GenericPrincipal(identity, null);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    } 
}