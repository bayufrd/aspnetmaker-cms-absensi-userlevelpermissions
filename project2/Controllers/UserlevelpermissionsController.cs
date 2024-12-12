namespace ASPNETMaker2024.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("UserlevelpermissionsList/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsList-userlevelpermissions-list")]
    [Route("Home/UserlevelpermissionsList/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsList-userlevelpermissions-list-2")]
    public async Task<IActionResult> UserlevelpermissionsList()
    {
        // Create page object
        userlevelpermissionsList = new GLOBALS.UserlevelpermissionsList(this);
        userlevelpermissionsList.Cache = _cache;

        // Run the page
        return await userlevelpermissionsList.Run();
    }

    // add
    [Route("UserlevelpermissionsAdd/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsAdd-userlevelpermissions-add")]
    [Route("Home/UserlevelpermissionsAdd/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsAdd-userlevelpermissions-add-2")]
    public async Task<IActionResult> UserlevelpermissionsAdd()
    {
        // Create page object
        userlevelpermissionsAdd = new GLOBALS.UserlevelpermissionsAdd(this);

        // Run the page
        return await userlevelpermissionsAdd.Run();
    }

    // view
    [Route("UserlevelpermissionsView/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsView-userlevelpermissions-view")]
    [Route("Home/UserlevelpermissionsView/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsView-userlevelpermissions-view-2")]
    public async Task<IActionResult> UserlevelpermissionsView()
    {
        // Create page object
        userlevelpermissionsView = new GLOBALS.UserlevelpermissionsView(this);

        // Run the page
        return await userlevelpermissionsView.Run();
    }

    // edit
    [Route("UserlevelpermissionsEdit/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsEdit-userlevelpermissions-edit")]
    [Route("Home/UserlevelpermissionsEdit/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsEdit-userlevelpermissions-edit-2")]
    public async Task<IActionResult> UserlevelpermissionsEdit()
    {
        // Create page object
        userlevelpermissionsEdit = new GLOBALS.UserlevelpermissionsEdit(this);

        // Run the page
        return await userlevelpermissionsEdit.Run();
    }

    // delete
    [Route("UserlevelpermissionsDelete/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsDelete-userlevelpermissions-delete")]
    [Route("Home/UserlevelpermissionsDelete/{UserLevelID?}/{_TableName?}", Name = "UserlevelpermissionsDelete-userlevelpermissions-delete-2")]
    public async Task<IActionResult> UserlevelpermissionsDelete()
    {
        // Create page object
        userlevelpermissionsDelete = new GLOBALS.UserlevelpermissionsDelete(this);

        // Run the page
        return await userlevelpermissionsDelete.Run();
    }
}
