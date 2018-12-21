using System.Diagnostics;
using System.Web.Mvc;
using AirlineDiscount.FlexRule;
using AirlineDiscount.Models;

namespace AirlineDiscount.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Process(DiscountInput model)
        {
            // Validates user input based on the validation rule
            var result = Rules.InputValidator.Run(model);
            if (!result.Outcome.Value)
                return PartialView("Results/ErrorResult", new ErrorResult(result.Context.Notifications));

            // Execute the decision to calculate discount
            result = Rules.DiscountDecision.Run(model);

            // Write log to know how the decision has been made for this amount of discount
            var reasons = result.ConclusionLog;
            Debug.WriteLine(reasons);

            // Read discount value
            object discount = result.Context.VariableContainer["discount"];

            // Update views
            if (discount != null && (int)discount > 0)
                return PartialView("Results/EligibleResult", new DiscountResult(model, (int)discount));

            return PartialView("Results/IneligibleResult");
        }
    }

}