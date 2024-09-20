Databasen kommer med satt data för Customers, Tables samt Menyer men det går att tillägga självmant.


# API Endpoints 
////////////////////BOOKING/////////////////////////
GET
/api/Booking/getAllBookings
//Får en lista på alla bokningar

GET
/api/Booking/booking/{bookingId}
//Får ut en bokning

POST
/api/Booking/addBooking
//Lägga till en bokning via Customer id, table id och hur många man är.

PUT
/api/Booking/updateBooking/{bookingId}
//Ändra på hur många man är och tiden


DELETE
/api/Booking/deleteBooking/{bookingId}
// Ta bort en bokning via bookingid


////////////////Customer///////////////////////////

POST
/api/Customer/AddCustomer
//Lägga till customer. Jag la inte till en delete eftersom om telefonnummret redan finns i databasen kommer inte en ny customer att sparas.

///////////////////Menu////////////////////////


GET
/api/Menu/getAllDishes
// Skriver ut alla rätter

POST
/api/Menu/addDish
//lägger till rätter


POST
/api/Menu/updateDish
//Uppdatera pris

POST
/api/Menu/updateDishInStock
//Ändrar om maten är tillgänglig eller inte
//////////////////Table/////////////////////


GET
/api/Table/getAllTables
//Skriver ut alla bort med id och hur många platser


POST
/api/Table/addTables
//Lägger till bord

PUT
/api/Table/updateTables/{TableId}
//Ändrar hur många platser ett bord har.

