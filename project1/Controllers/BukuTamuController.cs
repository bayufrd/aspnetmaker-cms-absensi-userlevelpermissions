namespace ASPNETMaker2024.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("BukuTamuList/{id?}", Name = "BukuTamuList-buku_tamu-list")]
    [Route("Home/BukuTamuList/{id?}", Name = "BukuTamuList-buku_tamu-list-2")]
    public async Task<IActionResult> BukuTamuList()
    {
        // Create page object
        bukuTamuList = new GLOBALS.BukuTamuList(this);
        bukuTamuList.Cache = _cache;

        // Run the page
        return await bukuTamuList.Run();
    }

    // add
    [Route("BukuTamuAdd/{id?}", Name = "BukuTamuAdd-buku_tamu-add")]
    [Route("Home/BukuTamuAdd/{id?}", Name = "BukuTamuAdd-buku_tamu-add-2")]
    public async Task<IActionResult> BukuTamuAdd()
    {
        // Create page object
        bukuTamuAdd = new GLOBALS.BukuTamuAdd(this);

        // Run the page
        return await bukuTamuAdd.Run();
    }

    // view
    [Route("BukuTamuView/{id?}", Name = "BukuTamuView-buku_tamu-view")]
    [Route("Home/BukuTamuView/{id?}", Name = "BukuTamuView-buku_tamu-view-2")]
    public async Task<IActionResult> BukuTamuView()
    {
        // Create page object
        bukuTamuView = new GLOBALS.BukuTamuView(this);

        // Run the page
        return await bukuTamuView.Run();
    }

    // edit
    [Route("BukuTamuEdit/{id?}", Name = "BukuTamuEdit-buku_tamu-edit")]
    [Route("Home/BukuTamuEdit/{id?}", Name = "BukuTamuEdit-buku_tamu-edit-2")]
    public async Task<IActionResult> BukuTamuEdit()
    {
        // Create page object
        bukuTamuEdit = new GLOBALS.BukuTamuEdit(this);

        // Run the page
        return await bukuTamuEdit.Run();
    }

    // delete
    [Route("BukuTamuDelete/{id?}", Name = "BukuTamuDelete-buku_tamu-delete")]
    [Route("Home/BukuTamuDelete/{id?}", Name = "BukuTamuDelete-buku_tamu-delete-2")]
    public async Task<IActionResult> BukuTamuDelete()
    {
        // Create page object
        bukuTamuDelete = new GLOBALS.BukuTamuDelete(this);

        // Run the page
        return await bukuTamuDelete.Run();
    }
}
