﻿namespace Mars.Common
{
    public class ServiceResult
    {
        public string Message { get; set; }

        public bool Status { get; set; }

        public static ServiceResult Fail(string message)
        {
            return new ServiceResult { Status = false, Message = message };
        }

        public static ServiceResult Success()
        {
            return new ServiceResult { Status = true };
        }

        public static ServiceResult Success(string message)
        {
            return new ServiceResult { Status = true, Message = message };
        }
    }
}
