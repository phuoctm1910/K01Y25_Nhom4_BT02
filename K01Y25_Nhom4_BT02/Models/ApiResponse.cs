using Microsoft.AspNetCore.Mvc;

namespace K01Y25_Nhom4_BT02.Models
{
    public class ApiResponse<T>
    {
        public int Code { get; set; } // 0: success, 1: fail
        public string? Status { get; set; } // "success" hoặc "fail"
        public T? Data { get; set; } // Dữ liệu trả về khi thành công
        public string? Message { get; set; } // Thông báo lỗi khi thất bại


        // Trường hợp thành công
        public static ApiResponse<T> Success(T data, string? message)
        {
            return new ApiResponse<T>
            {
                Code = 0,
                Status = "success",
                Data = data,
                Message = message
            };
        }


        // Trường hợp thất bại
        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>
            {
                Code = 1,
                Status = "fail",
                Data = default,
                Message = message
            };
        }


    }

}
