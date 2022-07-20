# ASP.NET

## Introduction

This is where are the ASP.NET framework studies.


## Controllers

This are the classes that handles the HTTP requests received by the servers and deliver responses. The default endpoint URI is defined by `/[controlername]/[methodname]` where the `[controllername]` is the name of the controller class without the "controller" word and the `[actionname]` is the name of the controller action that will handle the request. The controller implementation must be a public concrete class, with "Controller" at the and of the name, that inherit from `System.Web.Mvc.Controller`:

```
namespace MyAPI.Controllers

using System.Web.Mvc;

class ProductController : Controller
{
    // Actions
}
```


### Controller Actions

The controller actions are the methods that contains the logic that will be triggered by a specific HTTP request. The actions implementation must be public, non-static methods and can not be overloaded. They handle GET requests by default, but can handle other HTTP methods by using the attributes [HttpPost] for POST requests, [HttpPut] for PUT requests, [HttpPatch] for PATCH requests and [HttpDelete] for DELETE requests.

```
namespace MyAPI.Controllers

using System.Web.Mvc;

class ProductController : Controller
{

    // GET /product/index

    [HttpGet] // Optional
    public ActionResult Index()
    {
        // Action logics
        return View();
    }
}
```


### Action Results

Action result are the actual response to the HTTP request. ASP.NET supports several types of action results including:
- ViewResult - Represents HTML and markup.
- EmptyResult - Represents no result.
- RedirectResult - Represents a redirection to a new URL.
- JsonResult - Represents a JavaScript Object Notation result that can be used in an AJAX - application.
- JavaScriptResult - Represents a JavaScript script.
- ContentResult - Represents a text result.
- FileContentResult - Represents a downloadable file (with the binary content).
- FilePathResult - Represents a downloadable file (with a path).
- FileStreamResult - Represents a downloadable file (with a file stream).

All of these inherit from `System.Web.Mvc.ActionResult`. Notice that the example above does not return `ViewResult()`. It returns instead the View() method, a factory method inherited from `Controller` class. Other factory methods are:
- View - Returns a ViewResult action result.
- Redirect - Returns a RedirectResult action result.
- RedirectToAction - Returns a RedirectToRouteResult action result.
- RedirectToRoute - Returns a RedirectToRouteResult action result.
- Json - Returns a JsonResult action result.
- JavaScriptResult - Returns a JavaScriptResult.
- Content - Returns a ContentResult action result.
- File - Returns a FileContentResult, FilePathResult, or FileStreamResult depending on the - parameters passed to the method.


Any not `ActionResult` return type is automatically wrapped into a `ContentResult`.

### URL Parameters

A action can still receive values from GET request by declaring parameters:

```
namespace MyAPI.Controllers

using System.Web.Mvc;

class ProductController : Controller
{

    // GET /product/index/[id]
    public ActionResult Index(int? id)
    {
        // Action logics
        return Content(id);
    }
}
```

Also, if you expect to receive multiple arguments, you can use the `HttpRequest` property called `QueryString`. `QueryString` is a `Dictionary` with all the values passed by URL in the GET request. The property that stores the HTTP request information is the `Request` property, inhreritted from `Controller`.

```
class ProductController : Controller
{

    // GET /product/index/?name=foo
    public ActionResult Index()
    {
        string name = Request.QueryString["name"];
        return Content(name);
    }
}
```


## Routing