using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Bank of Spain");
        }
        [Route("/accountdetails")]
        public IActionResult AccountDetails()
        {
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
            return Json(bankAccount);
        }
        [Route("/accountstatement")]
        public IActionResult AccountStatements()
        {
            return File("~/offer letter.pdf", "application/pdf");
        }
        [Route("/getcurrentbalance/")]
        public IActionResult BalanceDetails()
        {
            if(!Request.Query.ContainsKey("accNo"))
            {
                return BadRequest("Account no should be supplied");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["accNo"])))
            {
                return BadRequest("Account no cannot be empty");
            }
            int AccNo = Convert.ToInt32(Request.Query["accNo"]);
            if (AccNo != 1001)
            {
                return NotFound("Account not found");
            }
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
            return Content(bankAccount.currentBalance.ToString());
        }
    }
}
