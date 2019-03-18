using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRoutine.Core.Utility
{
    public class ServiceResult
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public static ServiceResult Okay()
        {
            return new ServiceResult
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت صورت گرفت"
            };
        }
        public static ServiceResult Error()
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Message = "در انجام عملیات خطایی صورت گرفت مجددا تلاش کنید"
            };
        }
    }
}
