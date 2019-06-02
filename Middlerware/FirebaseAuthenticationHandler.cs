using System;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FoodService.Models;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NeighborFoodBackend.Middleware;

namespace NeighborFoodBackend.Middleware
{
    public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public FirebaseAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            UserRecord user = null;
            try
            {

                //string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjVjZWVhNDg5Y2QyZmQ2NDEzMTIwNDIzMjRjOTFjMTcyMGM2NmE1N2IiLCJ0eXAiOiJKV1QifQ.eyJwaWN0dXJlIjoiaHR0cHM6Ly9maXJlYmFzZXN0b3JhZ2UuZ29vZ2xlYXBpcy5jb20vdjAvYi9uZWlnaGJvdXJmb29kLThiZDk5LmFwcHNwb3QuY29tL28vSW1hZ2VzJTJGaW1hZ2UlM0EyNzQ4Nz9hbHQ9bWVkaWEmdG9rZW49ZGMzODRjOTEtMTZhNy00ZmFiLWFmYTYtMGRlZDNlNjZiZDFhIiwiaXNzIjoiaHR0cHM6Ly9zZWN1cmV0b2tlbi5nb29nbGUuY29tL25laWdoYm91cmZvb2QtOGJkOTkiLCJhdWQiOiJuZWlnaGJvdXJmb29kLThiZDk5IiwiYXV0aF90aW1lIjoxNTU5NTA4MzcxLCJ1c2VyX2lkIjoibjdlYzdBMDFHa1JlYWRRZ09GbXB3SEpBNm5rMSIsInN1YiI6Im43ZWM3QTAxR2tSZWFkUWdPRm1wd0hKQTZuazEiLCJpYXQiOjE1NTk1MDgzNzgsImV4cCI6MTU1OTUxMTk3OCwicGhvbmVfbnVtYmVyIjoiKzkxOTg3NjU0MzIxMCIsImZpcmViYXNlIjp7ImlkZW50aXRpZXMiOnsicGhvbmUiOlsiKzkxOTg3NjU0MzIxMCJdfSwic2lnbl9pbl9wcm92aWRlciI6InBob25lIn19.WKeRWcTUOtbbURAMCwK7Lu-yh4FO-_TdROjEt303dTaI2wnnnmK2rjQ0MwmwlR9nPCW9hwQWTddpovd9Et9ZdTtbLMY44Q1Zo4ap_sJ60Xg8avnrFagsY7_Qbn5Hvg9zb082X4T5Aog8kAXKJ1bUhtUWvByEG6uOzYByClr41tFTL1BVNtFJ6DoGUtT8JHR4kkiFB7EE3pYi906x8LmjubK6AowzAzlsCk4Zknrp5U5U5ItanZh_NpfaoDZEF8bXeir1PY4E-FQSi_88c68u_xdhMeaL-mmjRV_g7_bTTRaypMxP_AlVHHf2d47JO1tUXt2FUy0oGdEBiW4OPI7MGQ";
                var firebaseApp = FirebaseApp.DefaultInstance;
                if (firebaseApp == null)
                {
                    FileStream serviceAccount = File.OpenRead("neighbourfood-8bd99-firebase-adminsdk-nfi5y-a4e15997ce.json");
                    FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromStream(serviceAccount),
                    });
                }


                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(authHeader.Parameter);
                string uid = decodedToken.Uid;

                user = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);

            }
            catch(Exception ex)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Uid.ToString())
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}