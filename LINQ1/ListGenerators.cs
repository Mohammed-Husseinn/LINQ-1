using System;
using System.Collections.Generic;

public sealed class Product
{
    public int ProductID { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public decimal UnitPrice { get; init; }
    public int UnitsInStock { get; init; }
}

public sealed class Customer
{
    public string CustomerID { get; init; } = string.Empty;
    public List<Order> Orders { get; init; } = new();
}

public sealed class Order
{
    public int OrderID { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal Total { get; init; }
}

public static class ListGenerators
{
    public static List<Product> ProductList { get; } = new()
    {
        new() { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00m, UnitsInStock = 39 },
        new() { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00m, UnitsInStock = 17 },
        new() { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00m, UnitsInStock = 13 },
        new() { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
        new() { ProductID = 5, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00m, UnitsInStock = 120 },
        new() { ProductID = 6, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00m, UnitsInStock = 31 },
        new() { ProductID = 7, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.00m, UnitsInStock = 24 },
        new() { ProductID = 8, ProductName = "Longlife Tofu", Category = "Produce", UnitPrice = 10.00m, UnitsInStock = 4 },
        new() { ProductID = 9, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.00m, UnitsInStock = 0 },
        new() { ProductID = 10, ProductName = "Outback Lager", Category = "Beverages", UnitPrice = 15.00m, UnitsInStock = 15 }
    };

    public static List<Customer> CustomerList { get; } = new()
    {
        new()
        {
            CustomerID = "ALFKI",
            Orders = new()
            {
                new() { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25), Total = 814.42m },
                new() { OrderID = 10702, OrderDate = new DateTime(1997, 10, 13), Total = 330.00m }
            }
        },
        new()
        {
            CustomerID = "ANATR",
            Orders = new()
            {
                new() { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18), Total = 88.80m },
                new() { OrderID = 10856, OrderDate = new DateTime(1998, 1, 28), Total = 58.00m }
            }
        },
        new()
        {
            CustomerID = "ANTON",
            Orders = new()
            {
                new() { OrderID = 10365, OrderDate = new DateTime(1996, 11, 27), Total = 403.20m }
            }
        }
    };
}
