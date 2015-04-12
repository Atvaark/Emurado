using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http
{
    internal static class ExtensionMethods
    {
        public static bool TryGetUserId(this ApiController apiController, out int userId)
        {
            userId = 0;
            var user = apiController.Request.GetOwinContext().Authentication.User;
            if (user == null)
            {
                return false;
            }
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "id");
            return userIdClaim != null && int.TryParse(userIdClaim.Value, out userId);
        }
    }
}