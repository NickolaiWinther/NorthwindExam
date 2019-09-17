namespace NorthwindExam.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        private int orderId;
        private string customerId;
        private int? employeeId;
        private DateTime? shippedDate;

        /// <summary>
        /// Create a new object of the Order class
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Details = new HashSet<Order_Detail>();
        }
        /// <summary>
        /// The ID of the order
        /// </summary>
        public int OrderID
        {
            get => orderId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();
                else
                    orderId = value;
            }

        }

        /// <summary>
        /// The ID if the customer
        /// </summary>
        [StringLength(5)]
        public string CustomerID
        {
            get => customerId;
            set
            {
                if (value.Length != 5)
                    throw new ArgumentOutOfRangeException();
                if (value == null)
                    throw new NullReferenceException();
                else
                    customerId = value;
            }
        }

        /// <summary>
        /// The ID of the employee
        /// </summary>
        public int? EmployeeID
        {
            get => employeeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();
                if (value == null)
                    throw new NullReferenceException();
                else
                    employeeId = value;
            }
        }

        /// <summary>
        /// The date the eployee entered the order
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// The date the customer asked to get the delivery
        /// </summary>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// The date the order was sent
        /// </summary>
        public DateTime? ShippedDate
        {
            get => shippedDate;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException();
                shippedDate = value;
            }
        }

        /// <summary>
        /// The ship the order was sent with
        /// </summary>
        public int? ShipVia { get; set; }

        /// <summary>
        /// The price for the freigh
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }

        /// <summary>
        /// The name of the company
        /// </summary>
        [StringLength(40)]
        public string ShipName { get; set; }

        /// <summary>
        /// The receivers address
        /// </summary>
        [StringLength(60)]
        public string ShipAddress { get; set; }

        /// <summary>
        /// The receivers city
        /// </summary>
        [StringLength(15)]
        public string ShipCity { get; set; }

        /// <summary>
        /// The receivers region
        /// </summary>
        [StringLength(15)]
        public string ShipRegion { get; set; }

        /// <summary>
        /// The receivers postal code
        /// </summary>
        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// The receivers country
        /// </summary>
        [StringLength(15)]
        public string ShipCountry { get; set; }

        /// <summary>
        /// The customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// The employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// ICollection of order details
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Details { get; set; }

        /// <summary>
        /// The shipper
        /// </summary>
        public virtual Shipper Shipper { get; set; }
    }
}
