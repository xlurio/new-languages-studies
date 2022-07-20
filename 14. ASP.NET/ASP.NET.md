# ASP.NET

## Introduction

This is where are the ASP.NET framework studies.


## Controllers

This are the classes that handles the HTTP requests received by the servers and deliver responses. The default endpoint URI is defined by `/[controler-name]/[method-name]` where the `[controller-name]` is the name of the controller class without the "controller" word and the `[action-name]` is the name of the controller action that will handle the request. The controller implementation must be a public concrete class, with "Controller" at the and of the name, that inherit from `System.Web.Mvc.Controller`:

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
        return View()
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

All of these inherit from `System.Web.Mvc.ActionResult`. Notice that the example above does not return `ViewResult()`. It returns instead the View() method, a factory method inherited from `Controller` class. Other factory method are 