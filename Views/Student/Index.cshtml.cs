using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Views.Student
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
		protected void LinkButton1_Click(object sender, EventArgs e) {
			Response.Redirect("Create");//move to the next link i.e default.aspx
		}
	}
}
