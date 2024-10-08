using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using SRS_Game.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class ClaimsTransformation : IClaimsTransformation
{
    private readonly SRS_GameDbContext _context;

    public ClaimsTransformation(SRS_GameDbContext context)
    {
        _context = context;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        // Get the user's email or unique identifier (adjust according to your Azure AD setup)
        var email = principal.GetDisplayName();

        // Fetch the user from the database
        var user = await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user != null)
        {
            // Create a new claims identity to hold the roles
            var claimsIdentity = new ClaimsIdentity();

            // Add user roles from the database as claims
            foreach (var role in user.Roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            // Add the new identity to the current principal
            principal.AddIdentity(claimsIdentity);
        }

        return principal;
    }
}
