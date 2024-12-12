namespace ASPNETMaker2024.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("UsersList/{user_id?}", Name = "UsersList-users-list")]
    [Route("Home/UsersList/{user_id?}", Name = "UsersList-users-list-2")]
    public async Task<IActionResult> UsersList()
    {
        // Create page object
        usersList = new GLOBALS.UsersList(this);
        usersList.Cache = _cache;

        // Run the page
        return await usersList.Run();
    }

    // add
    [Route("UsersAdd/{user_id?}", Name = "UsersAdd-users-add")]
    [Route("Home/UsersAdd/{user_id?}", Name = "UsersAdd-users-add-2")]
    public async Task<IActionResult> UsersAdd()
    {
        // Create page object
        usersAdd = new GLOBALS.UsersAdd(this);

        // Run the page
        return await usersAdd.Run();
    }

    // view
    [Route("UsersView/{user_id?}", Name = "UsersView-users-view")]
    [Route("Home/UsersView/{user_id?}", Name = "UsersView-users-view-2")]
    public async Task<IActionResult> UsersView()
    {
        // Create page object
        usersView = new GLOBALS.UsersView(this);

        // Run the page
        return await usersView.Run();
    }

    // edit
    [Route("UsersEdit/{user_id?}", Name = "UsersEdit-users-edit")]
    [Route("Home/UsersEdit/{user_id?}", Name = "UsersEdit-users-edit-2")]
    public async Task<IActionResult> UsersEdit()
    {
        // Create page object
        usersEdit = new GLOBALS.UsersEdit(this);

        // Run the page
        return await usersEdit.Run();
    }

    // delete
    [Route("UsersDelete/{user_id?}", Name = "UsersDelete-users-delete")]
    [Route("Home/UsersDelete/{user_id?}", Name = "UsersDelete-users-delete-2")]
    public async Task<IActionResult> UsersDelete()
    {
        // Create page object
        usersDelete = new GLOBALS.UsersDelete(this);

        // Run the page
        return await usersDelete.Run();
    }
}
