using System.Linq;
using System.Security.Claims;

namespace Collections.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetNameIdentifier(this ClaimsPrincipal principal) => int.TryParse(
            (principal?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier) ??
             principal?.Identities.Select(x => x.FindFirst(ClaimTypes.NameIdentifier)).FirstOrDefault())?.Value,
            out int v)
            ? v
            : 0;
    }
}