using Microsoft.AspNetCore.Mvc;

namespace Lurnyx.WebApp.Controllers
{
    public class ThemeController : Controller
    {

        /// <summary>
        /// Sets the theme cookie in the response.
        /// </summary>
        /// <param name="model">The theme model.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        [HttpPost]
        public IActionResult SetTheme([FromBody] ThemeModel model)
        {
            Response.Cookies.Append("Theme", model.IsDark ? "Dark" : "Light",
                new CookieOptions { Expires = DateTimeOffset.Now.AddYears(1) });
            return Ok();
        }

    }

    public class ThemeModel
    {
        public bool IsDark { get; set; }
    }
}
