namespace ASPNETMaker2024.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("UserlevelsList/{UserLevelID?}", Name = "UserlevelsList-userlevels-list")]
    [Route("Home/UserlevelsList/{UserLevelID?}", Name = "UserlevelsList-userlevels-list-2")]
    public async Task<IActionResult> UserlevelsList()
    {
        // Create page object
        userlevelsList = new GLOBALS.UserlevelsList(this);
        userlevelsList.Cache = _cache;

        // Run the page
        return await userlevelsList.Run();
    }

    // add
    [Route("UserlevelsAdd/{UserLevelID?}", Name = "UserlevelsAdd-userlevels-add")]
    [Route("Home/UserlevelsAdd/{UserLevelID?}", Name = "UserlevelsAdd-userlevels-add-2")]
    public async Task<IActionResult> UserlevelsAdd()
    {
        // Create page object
        userlevelsAdd = new GLOBALS.UserlevelsAdd(this);

        // Run the page
        return await userlevelsAdd.Run();
    }

    // view
    [Route("UserlevelsView/{UserLevelID?}", Name = "UserlevelsView-userlevels-view")]
    [Route("Home/UserlevelsView/{UserLevelID?}", Name = "UserlevelsView-userlevels-view-2")]
    public async Task<IActionResult> UserlevelsView()
    {
        // Create page object
        userlevelsView = new GLOBALS.UserlevelsView(this);

        // Run the page
        return await userlevelsView.Run();
    }

    // edit
    [Route("UserlevelsEdit/{UserLevelID?}", Name = "UserlevelsEdit-userlevels-edit")]
    [Route("Home/UserlevelsEdit/{UserLevelID?}", Name = "UserlevelsEdit-userlevels-edit-2")]
    public async Task<IActionResult> UserlevelsEdit()
    {
        // Create page object
        userlevelsEdit = new GLOBALS.UserlevelsEdit(this);

        // Run the page
        return await userlevelsEdit.Run();
    }

    // delete
    [Route("UserlevelsDelete/{UserLevelID?}", Name = "UserlevelsDelete-userlevels-delete")]
    [Route("Home/UserlevelsDelete/{UserLevelID?}", Name = "UserlevelsDelete-userlevels-delete-2")]
    public async Task<IActionResult> UserlevelsDelete()
    {
        // Create page object
        userlevelsDelete = new GLOBALS.UserlevelsDelete(this);

        // Run the page
        return await userlevelsDelete.Run();
    }
}
