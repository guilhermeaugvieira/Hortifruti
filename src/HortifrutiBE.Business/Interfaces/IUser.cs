using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace HortifrutiBE.Business.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string Role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
