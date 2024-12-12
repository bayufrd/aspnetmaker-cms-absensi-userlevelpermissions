using ApplicationUser = ASPNETMaker2024.Models.ApplicationUser;

namespace ASPNETMaker2024.Controllers;

// Partial class
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi=true)]
public partial class HomeController : Controller
{
    private IMemoryCache _cache;

    // Constructor
    public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
    {
        _cache = memoryCache;
        GLOBALS.Logger = logger;
    }

    // Destructor
    protected override void Dispose(bool disposing)
    {
        if (disposing) {
            // Clean up temp folder if not add/edit/export
            dynamic page = CurrentPage;
            if (page != null) {
                string pageId = page.PageID;
                if (GetProperty(page, "TableName") != null &&
                    !(new [] { "add", "register", "edit", "update" }).Contains(pageId) &&
                    !(pageId == "list" && page.IsAddOrEdit) &&
                    !(!Empty(GetPropertyValue(page, "Export")) && page.Export != "print" && page.UseCustomTemplate))
                CleanUploadTempPaths(Session.SessionId);
            }
        }
        base.Dispose(disposing);
    }

    // Personal Data
    [Route("personaldata/{cmd?}", Name = "personaldata")]
    [Route("Home/personaldata/{cmd?}", Name = "personaldata-2")]
    public async Task<IActionResult> PersonalData()
    {
        // Create page object
        personalData = new GLOBALS.PersonalData(this);

        // Run the page
        return await personalData.Run();
    }

    // Login
    [Route("login/{provider?}", Name = "login")]
    [Route("Home/login/{provider?}", Name = "login-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        // Create page object
        login = new GLOBALS.Login(this);

        // Run the page
        return await login.Run();
    }

    // Change Password
    [Route("changepassword", Name = "changepassword")]
    [Route("Home/changepassword", Name = "changepassword-2")]
    public async Task<IActionResult> ChangePassword()
    {
        // Create page object
        changePassword = new GLOBALS.ChangePassword(this);

        // Run the page
        return await changePassword.Run();
    }

    // Userpriv
    [Route("userpriv/{UserLevelID?}", Name = "userpriv")]
    [Route("Home/userpriv/{UserLevelID?}", Name = "userpriv-2")]
    public async Task<IActionResult> Userpriv()
    {
        // Create page object
        userpriv = new GLOBALS.Userpriv(this);

        // Run the page
        return await userpriv.Run();
    }

    // Logout
    [Route("logout", Name = "logout")]
    [Route("Home/logout", Name = "logout-2")]
    public async Task<IActionResult> Logout()
    {
        // Create page object
        logout = new GLOBALS.Logout(this);

        // Run the page
        return await logout.Run();
    }

    // Index
    [Route("")]
    [Route("index", Name = "index")]
    [Route("Home/index", Name = "index-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        // Create page object
        index = new GLOBALS.Index(this);

        // Run the page
        return await index.Run();
    }

    // Error
    [Route("error", Name = "error")]
    [Route("Home/error", Name = "error-2")]
    [AllowAnonymous]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> Error()
    {
        // Create page object
        error = new GLOBALS.Error(this);

        // Run the page
        return await error.Run();
    }

    // Swagger
    [Route("swagger/swagger", Name = "swagger")]
    [Route("Home/swagger/swagger", Name = "swagger-2")]
    [AllowAnonymous]
    public IActionResult Swagger()
    {
        Language = ResolveLanguage();
        ViewData["Title"] = Language.Phrase("ApiTitle");
        ViewData["Version"] = Config.ApiVersion;
        ViewData["BasePath"] = Request.PathBase.ToString();
        return View();
    }

    // Dispose
    // protected override void Dispose(bool disposing) {
    //     try {
    //         base.Dispose(disposing);
    //     } finally {
    //         CurrentPage?.Terminate();
    //     }
    // }
}
