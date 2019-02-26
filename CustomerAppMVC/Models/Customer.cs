using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CustomerAppMVC.Models
{
    public class Customer
    {
        private string _CustomerName;
        private string _Location;

        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName
        {
            get
            {
                if (this._CustomerName == null)
                    return null;
                else
                    return this._CustomerName.Trim(); }
            set { this._CustomerName = value; }
            
        }
        [Required]
        public string Location
        {
            get
            {
                if (this._Location == null)
                    return null;
                else
                    return this._Location.Trim(); }
            set{ this._Location = value; }
        }

        public static explicit operator Customer(CustomerAppMVC.Customer other)
        {
            return new Customer { CustomerID = other.CustomerID, CustomerName = other.CustomerName, Location = other.Location };
        }

    }
}