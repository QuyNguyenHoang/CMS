using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;           // Dùng BadRequestObjectResult

namespace CMS.Api.Filters                // Namespace chứa các Filter của API
{
        public class ValidateModelAttribute : ActionFilterAttribute
    {
        // Hàm này chạy TRƯỚC khi action trong controller được gọi
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Kiểm tra dữ liệu client gửi lên có hợp lệ không
            // (dựa vào các attribute như [Required], [MaxLength], ...)
            if (!context.ModelState.IsValid)
            {
                // Nếu model không hợp lệ
                // → Trả về HTTP 400 Bad Request
                // → Kèm chi tiết lỗi validate
                // → Action sẽ KHÔNG được thực thi
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
