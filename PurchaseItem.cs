// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace DataBindingToStringFomat
{

    abstract class strategy
    {
        public abstract Purchase _purchase();
    }

    class Purchase
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime OfferExpires { get; set; }

        public Purchase(string desc, double price, DateTime endDate)
        {
            Description = desc;
            Price = price;
            OfferExpires = endDate;
        }
        public Purchase(string desc, double price)
        {
            Description = desc;
            Price = price;
        }
        public Purchase(string desc)
        {
            Description = desc;
        }
        public Purchase(double price)
        {
            Price = price;
        }
        public Purchase(DateTime endDate)
        {
            OfferExpires = endDate;
        }
        public override string ToString() => $"{Description}, {Price:c}, {OfferExpires:D}";
    }

    class Description : strategy
    {
        public string description { get; set; }
        public override Purchase _purchase()
        {
            return new Purchase(description);
        }
    }
    class Price : strategy
    {
        public double price { get; set; }
        public override Purchase _purchase()
        {
            return new Purchase(price);
        }
    }
    class DateTime : strategy
    {
        public DateTime OfferExpires { get; set; }
        public override Purchase _purchase()
        {
            return new Purchase(OfferExpires);
        }
    }

    class CreateAttribute
    {
        public CreateAttribute(strategy method)
        {
            method._purchase();
        }
    }

}