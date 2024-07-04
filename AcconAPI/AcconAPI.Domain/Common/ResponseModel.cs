﻿namespace AcconAPI.Domain.Common;

public class ResponseModel<T>
{
    public bool Succeeded { get; protected set; }
    public T Data { get; protected set; }
    public string Message { get; protected set; }
    public List<string> Errors { get; set; }
    public int StatusCode { get; set; }
    public ResponseModel() { }
    public ResponseModel(T data, string message)
    {
        Succeeded = true;
        Data = data;
        Message = message;
    }
    public ResponseModel(string message)
    {
        Succeeded = false;
        Message = message;
    }
    public ResponseModel(string message, int statusCode)
    {
        Succeeded = false;
        Message = message;
        StatusCode = statusCode;
    }
    public static ResponseModel<T> Success()
    {
        var result = new ResponseModel<T> { Succeeded = true };
        return result;
    }
    public static ResponseModel<T> Success(string message)
    {
        var result = new ResponseModel<T> { Succeeded = true, Message = message };
        return result;
    }
    public static ResponseModel<T> Success(T data, string message)
    {
        var result = new ResponseModel<T> { Succeeded = true, Data = data, Message = message };
        return result;
    }
    public static ResponseModel<T> Success(T data)
    {
        var result = new ResponseModel<T> { Succeeded = true, Data = data, Message = "Successful" };
        return result;
    }
    public static ResponseModel<T> Fail()
    {
        var result = new ResponseModel<T> { Succeeded = false };
        return result;
    }
    public static ResponseModel<T> Fail(string message)
    {
        var result = new ResponseModel<T> { Succeeded = false, Message = message };
        return result;
    }
    public static ResponseModel<T> Fail(string message, int statusCode)
    {
        var result = new ResponseModel<T> { Succeeded = false, Message = message, StatusCode = statusCode };
        return result;
    }
    public static ResponseModel<T> Fail(string message, List<string> errors)
    {
        var result = new ResponseModel<T> { Succeeded = false, Message = message, Errors = errors };
        return result;
    }
    public static ResponseModel<T> Fail(List<string> errors)
    {
        var result = new ResponseModel<T> { Succeeded = false, Errors = errors };
        return result;
    }
    public override string ToString()
    {
        if (Succeeded)
        {
            return Message;
        }
        else
        {
            if (Errors == null || Errors.Count == 0)
            {
                return Message;
            }
            return $"{Message} : {string.Join(",", Errors)}";
        }
    }
}