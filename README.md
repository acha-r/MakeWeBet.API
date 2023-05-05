# MakeWeBetAPI

This contains API endpoints for possible transactions in the MakeWeBet app

## Features
### Customer
* GetUserBarcodeInfo : This returns the user information - name, barcode unique id and wallet balance.

* MakePayment : This returns a payment summary. If unsuccessful due to insufficient funds, it provides information on how much more the user would need to secure purchase.

### Store
* RegiterProduct : Registers product on MakeWeBet. The assigns a unique barcode Id to the product.

### Product
* GetProductInfo : Scan product barcode to see the information about the store, the product as well as the amount to pay for the item. If the product has not been registered on MakeWeBet by the store, it returns a bad request error.

* AddProduct : Adds a product to the store. This does not make the product available for purchase because the store is yet to register it on MakeWeBet

## Tech Stack
C#, .NET 7.0

## Usage
* To get started with this, clone repo into IDE.
* Install missing Nuget packages
* Input your database connection string in the appsetting.json file
* Add migration and update database
* Start application

## Tests
Automated tests were implemented using xUnit. To confirm tests, 
* Open package manager console in Visual studio
* Type "dotnet test"
* Press enter

## API Endpoints
End point for this app is contained in a .yaml OpenAPI specification file

## Database design
The database design diagram is provided in the repo. Here is a link for a quick peek
https://shorturl.at/jpGQ6

