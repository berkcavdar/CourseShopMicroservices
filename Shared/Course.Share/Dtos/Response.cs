using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Course.Share.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessfull { get; private set; }
        public List<string> Errors { get; set; }

        //Static Factory Method 
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessfull = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Data = default(T), IsSuccessfull = true };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Errors = errors, IsSuccessfull = false };
        }
        
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Errors = new List<string>() { error }, IsSuccessfull = false };
        }
    }
}
