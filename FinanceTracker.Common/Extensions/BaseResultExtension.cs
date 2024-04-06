using FinanceTracker.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Common.Extensions
{
    public static class BaseResultExtension
    {
        public static ActionResult ToActionResult<T>(this BaseResult<T> response)
        {
            if(!response.IsSuccess)
            {
                return new BadRequestObjectResult(response.ErrorMessages);
            }

            return new OkObjectResult(response.Result);
        }

        public static ActionResult ToActionResult(this BaseResult response)
        {
            if (!response.IsSuccess)
            {
                return new BadRequestObjectResult(response.ErrorMessages);
            }

            return new OkObjectResult(new());
        }
    }
}