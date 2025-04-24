﻿using Newtonsoft.Json;

namespace OnlineLibraryProject.WebApi.Middleware;

public sealed class ErrorResult : ErrorStatusCode
{
    public string Message { get; set; }
}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ValidationErrorDetails : ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }
}
