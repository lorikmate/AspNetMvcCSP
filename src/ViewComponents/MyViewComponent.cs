using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCSP.ViewComponents;

public class MyViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var dropdownData = new List<string>
        {
            "Data1",
            "Data2"
        };

        return View(dropdownData);
    }
}
