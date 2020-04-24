using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    class L
    {
        // Liskov Substitution Principle

        private class BadLCustomer
        {
            public virtual double getDiscount(double amount)
            {
                return amount;
            }

            public virtual void AddToDb()
            {
                // add
            }
        }

        private class SilverCustomer : BadLCustomer
        {
            public override double getDiscount(double amount)
            {
                return amount - 50;
            }
        }

        private class GoldCustomer : BadLCustomer
        {
            public override double getDiscount(double amount)
            {
                return amount - 100;
            }
        }

        private class Enquiry : BadLCustomer
        {
            public override double getDiscount(double amount)
            {
                return amount - 3;
            }

            public override void AddToDb()
            {
                throw new Exception("Can't do that");
            }
        }

        private class ViolateLiskov
        {
            void ParseCustomers()
            {
                List<BadLCustomer> customers = new List<BadLCustomer>()
                {
                    new SilverCustomer(),
                    new GoldCustomer(),
                    new Enquiry()
                };

                foreach (var customer in customers)
                {
                    customer.AddToDb(); // This will trow exception on runtime, because
                    // enquiry have't support add
                }
            }
        }


        // Good Liskov

        private interface IDiscount
        {
            double GetDiscount(double amount);
        }

        private interface IAddToDb
        {
            void AddToDb();
        }

        private class GoodLCustomer : IDiscount, IAddToDb
        {
            public virtual double GetDiscount(double amount)
            {
                return amount;
            }

            public virtual void AddToDb()
            {
                // add
            }
        }

        private class GoodSilverCustomer : GoodLCustomer
        {
            public override double GetDiscount(double amount)
            {
                return amount - 50;
            }
        }

        private class GoodGoldCustomer : GoodLCustomer
        {
            public override double GetDiscount(double amount)
            {
                return amount - 100;
            }
        }

        private class GoodEnquiry : IDiscount
        {
            public double GetDiscount(double amount)
            {
                return amount - 3;
            }
        }

        private class AdheringLiskov //(adhere - to stick firmly)
        {
            void ParseCustomers()
            {
                List<GoodLCustomer> customers = new List<GoodLCustomer>()
                {
                    new GoodSilverCustomer(),
                    new GoodGoldCustomer(),
                    // new GoodEnquiry() // will give compiler error, rather than runtime error
                };

                foreach (var customer in customers)
                {
                    customer.AddToDb();
                }
            }
        }
    }
}
