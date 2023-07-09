# SportsSln

### Creating the Add to Cart Button
	To prepare for this, need to add class UrlExtensions to the Infrastructure folder
	and define the extention method PathAndQuery that operates on the HttpRequest class.
	
	The extention method generates a URL that the browser will be returned to after the card has been updated
	Then need to add buttons to the ProductSummary.cshtml
	
### Enabling Sessions

	Enabling sessions requires adding services and middleware in the Program.cs file.
	The AddDistributedMamoryCache method call sets up in the in-memory data store.
	The AddSession method registers the services used to access session data, and
	the UseSession method allow the session system to automaticaly associate requests with sessions when they 
	arrive from the client.
	
### Implement the Cart Feature

	Adding class Cart.cs
	
### Defining Session State Extension Method

	The session state feature in ASP.NET Core stores only int, string, byte[] values
	Add a class file SessionExtensions to the Infrastructure folder with methods
	*SetJson
	*GetJson
	
	This methods serialize objects into JavaScript Object Notation format.
	
### Completing the Razor Page

	The Cart Razor PAge will receive the Http POST request when the user click an Add To Cart button.
	


	