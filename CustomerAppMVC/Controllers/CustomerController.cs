using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CustomerAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        MFDDataClassDataContext dc = new MFDDataClassDataContext();


        // GET: Customer
        public ActionResult Index()
        {



            return View();
        }

        public ActionResult QueryCustomers()
        {
            IEnumerable<Customer> customers = (from customer in dc.Customers
                                               select customer).ToList();
            IEnumerable<CustomerAppMVC.Models.Customer> mycustomers = customers.Select(cust => new Models.Customer
            {
                CustomerName = cust.CustomerName,
                CustomerID = cust.CustomerID,
                Location = cust.Location
            }).ToList();

            return View(mycustomers);
        }

        //NOTE: in order for ModelState.IsValid to trigger properly, the input type of the post action result MUST be the model itself
        //duh I know
        [HttpPost]
        public ActionResult EditCustomer(CustomerAppMVC.Models.Customer model)
        {
            var currCust = (from cust in dc.Customers
                            where cust.CustomerID == model.CustomerID
                            select cust).FirstOrDefault();

            if (ModelState.IsValid)
            {
                var result = (from Customer in dc.Customers
                              where Customer.CustomerID == model.CustomerID
                              select Customer).FirstOrDefault();

                

                result.CustomerName = model.CustomerName;
                result.Location = model.Location;

                dc.SubmitChanges();
                return View((CustomerAppMVC.Models.Customer) result);

            }
            return View();
        }


        public ActionResult EditCustomer(int id)
        {
            CustomerAppMVC.Models.Customer myCust = (CustomerAppMVC.Models.Customer) (from customer in dc.Customers
                                              where customer.CustomerID == id
                                              select customer).FirstOrDefault();
            return View(myCust);
        }
    }
}