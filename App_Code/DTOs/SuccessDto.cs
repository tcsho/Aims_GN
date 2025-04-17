using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SuccessDto
/// </summary>
public class SuccessDto
{
    public bool IsSuccess { get; set; }
    public bool IsWarning { get; set; }
    public bool IsError { get; set; }
    public string Message { get; set; }
}