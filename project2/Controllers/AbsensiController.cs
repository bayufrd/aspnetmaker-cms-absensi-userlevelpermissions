namespace ASPNETMaker2024.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("AbsensiList/{id?}", Name = "AbsensiList-absensi-list")]
    [Route("Home/AbsensiList/{id?}", Name = "AbsensiList-absensi-list-2")]
    public async Task<IActionResult> AbsensiList()
    {
        // Create page object
        absensiList = new GLOBALS.AbsensiList(this);
        absensiList.Cache = _cache;

        // Run the page
        return await absensiList.Run();
    }

    // add
    [Route("AbsensiAdd/{id?}", Name = "AbsensiAdd-absensi-add")]
    [Route("Home/AbsensiAdd/{id?}", Name = "AbsensiAdd-absensi-add-2")]
    public async Task<IActionResult> AbsensiAdd()
    {
        // Create page object
        absensiAdd = new GLOBALS.AbsensiAdd(this);

        // Run the page
        return await absensiAdd.Run();
    }

    // view
    [Route("AbsensiView/{id?}", Name = "AbsensiView-absensi-view")]
    [Route("Home/AbsensiView/{id?}", Name = "AbsensiView-absensi-view-2")]
    public async Task<IActionResult> AbsensiView()
    {
        // Create page object
        absensiView = new GLOBALS.AbsensiView(this);

        // Run the page
        return await absensiView.Run();
    }

    // edit
    [Route("AbsensiEdit/{id?}", Name = "AbsensiEdit-absensi-edit")]
    [Route("Home/AbsensiEdit/{id?}", Name = "AbsensiEdit-absensi-edit-2")]
    public async Task<IActionResult> AbsensiEdit()
    {
        // Create page object
        absensiEdit = new GLOBALS.AbsensiEdit(this);

        // Run the page
        return await absensiEdit.Run();
    }

    // delete
    [Route("AbsensiDelete/{id?}", Name = "AbsensiDelete-absensi-delete")]
    [Route("Home/AbsensiDelete/{id?}", Name = "AbsensiDelete-absensi-delete-2")]
    public async Task<IActionResult> AbsensiDelete()
    {
        // Create page object
        absensiDelete = new GLOBALS.AbsensiDelete(this);

        // Run the page
        return await absensiDelete.Run();
    }
}
