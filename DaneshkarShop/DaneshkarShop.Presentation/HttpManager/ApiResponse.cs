﻿using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.HttpManager
{
    //This is an Extension method that initializes a json result(returns Json result)
    public static class ApiResponse
    {
        public static JsonResult SetResponse(ApiResponseStatus status, object? data, string message = null)
        {
            return new JsonResult(new
            {
                status = Enum.GetName(status),
                data = data,
                message = message
            });
        }
    }
}
