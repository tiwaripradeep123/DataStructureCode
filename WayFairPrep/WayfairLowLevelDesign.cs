using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.WayFairPrep
{
    class WayfairLowLevelDesign
    {
        /*
         Design an application/ API user online shoping 
1. Catalog - 
2. builds the cart 
3. Address info 
4. Login/optional 
5. payment 
6. place order 

Catalog 
GetUserInfo/{userId} 


Database
 Master 
  1. User 

{pid} | small bike | 10  -> 15 

small bike 5 


REST - CRUD 


Version, 

POST Https://BikeShop.com/v1/Products
{
   ProuductID: int
   count :int 
}


PUT Https://BikeShop.com/v1/Products/{ProuductID}
{
   count :int (5)
}


POST Https://BikeShop.com/v1/Products/AddInventory/{ProuductID}
{
   count :int 
}

POST Https://BikeShop.com/Product/IncrementAvailability/{ProuductID}{count :int } 
POST Https://BikeShop.com/Customer request { name, phoneno. } 



GET Https://BikeShop.com/Customers?id={id}


GET Https://BikeShop.com/Customers?name?={name}&phoneno?={phoneno.} 
Response 
[
 { CustomerId name, phoneno}
]

GET Https://BikeShop.com/Products?name={productname} Response [ { productid, name,  SubType,  AvailableCount } ]  GET Https://BikeShop.com/Products?name={productname},Available={true} Response [ { productid, name,  SubType,  AvailableCount } ] 
Https://BikeShop.com/CheckOut { 1. if there is any past due - } request {DateRented DateDue ProductId CustomerId RentalRateId } Response: RentedInventoryId 

GET: Https://BikeShop.com/RentalRates?productID = {productId}[{ 1/daily 1w 1m ]

Https://BikeShop.com/Charges/RentedInventoryId?ReturnedDate={date/Today}{cost:}Https://BikeShop.com/Return/RentedInventoryId{1. Move that entry to RentedHistory2. Https://BikeShop.com/Product/IncrementAvailability/{ProuductID} {count:1}3. }
RentalHistory/{userId}[ { }]CurrentRental/{userId}[ { }]",







         
         */
    }
}

