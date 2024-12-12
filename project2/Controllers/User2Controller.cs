namespace ASPNETMaker2024.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("User2List/{id?}", Name = "User2List-user2-list")]
    [Route("Home/User2List/{id?}", Name = "User2List-user2-list-2")]
    public async Task<IActionResult> User2List()
    {
        // Create page object
        user2List = new GLOBALS.User2List(this);
        user2List.Cache = _cache;

        // Run the page
        return await user2List.Run();
    }

    // add
    [Route("User2Add/{id?}", Name = "User2Add-user2-add")]
    [Route("Home/User2Add/{id?}", Name = "User2Add-user2-add-2")]
    public async Task<IActionResult> User2Add()
    {
        // Create page object
        user2Add = new GLOBALS.User2Add(this);

        // Run the page
        return await user2Add.Run();
    }

    // view
    [Route("User2View/{id?}", Name = "User2View-user2-view")]
    [Route("Home/User2View/{id?}", Name = "User2View-user2-view-2")]
    public async Task<IActionResult> User2View()
    {
        // Create page object
        user2View = new GLOBALS.User2View(this);

        // Run the page
        return await user2View.Run();
    }

    // edit
    [Route("User2Edit/{id?}", Name = "User2Edit-user2-edit")]
    [Route("Home/User2Edit/{id?}", Name = "User2Edit-user2-edit-2")]
    public async Task<IActionResult> User2Edit()
    {
        // Create page object
        user2Edit = new GLOBALS.User2Edit(this);

        // Run the page
        return await user2Edit.Run();
    }

    // delete
    [Route("User2Delete/{id?}", Name = "User2Delete-user2-delete")]
    [Route("Home/User2Delete/{id?}", Name = "User2Delete-user2-delete-2")]
    public async Task<IActionResult> User2Delete()
    {
        // Create page object
        user2Delete = new GLOBALS.User2Delete(this);

        // Run the page
        return await user2Delete.Run();
    }
}
