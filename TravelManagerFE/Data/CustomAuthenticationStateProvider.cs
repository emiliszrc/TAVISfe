using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace TravelManagerFE.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService sessionStorageService;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            this.sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var currentUser = await sessionStorageService.GetItemAsync<string>("user");

            ClaimsIdentity identity;

            if (currentUser != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, currentUser),
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(User user)
        {
            var userSerialized = JsonConvert.SerializeObject(user);

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userSerialized),
            }, "apiauth_type");

            var newUser = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(newUser)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await sessionStorageService.RemoveItemAsync("user");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

            var serializedUser = JsonConvert.SerializeObject(user);
            await sessionStorageService.SetItemAsync("user", serializedUser);

        }

        public async Task<User> GetCurrentUser()
        {
            try
            {
                var user = await sessionStorageService.GetItemAsync<string>("user");
                var deserializedUser = JsonConvert.DeserializeObject<User>(user);

                return deserializedUser;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
