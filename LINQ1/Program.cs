using System;
using System.Collections.Generic;
using System.Linq;

class LinqSolutions
{
    static void Main()
    {
        var ProductList = ListGenerators.ProductList;
        var CustomerList = ListGenerators.CustomerList;

        // 1. Seafood products: name and price
        Console.WriteLine("--- 1. Seafood products ---");
        var seafood = ProductList.Where(p => p.Category == "Seafood");
        foreach (var p in seafood)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

        // 2. Only the product names
        Console.WriteLine("\n--- 2. Product names ---");
        var names = ProductList.Select(p => p.ProductName);
        foreach (var n in names)
            Console.WriteLine(n);

        // 3. Sort by UnitPrice ascending
        Console.WriteLine("\n--- 3. Sorted by UnitPrice (asc) ---");
        var byPrice = ProductList.OrderBy(p => p.UnitPrice);
        foreach (var p in byPrice)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

        // 4. UnitPrice between 10 and 30
        Console.WriteLine("\n--- 4. UnitPrice between 10 and 30 ---");
        var midPrice = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
        foreach (var p in midPrice)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

        // 5. In stock AND Condiments
        Console.WriteLine("\n--- 5. In-stock Condiments ---");
        var inStockCondiments = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
        foreach (var p in inStockCondiments)
            Console.WriteLine($"{p.ProductName} (stock: {p.UnitsInStock})");

        // 6. Anonymous type with Name, Price, StockStatus
        Console.WriteLine("\n--- 6. Anonymous type with StockStatus ---");
        var withStatus = ProductList.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });
        foreach (var x in withStatus)
            Console.WriteLine($"{x.Name} | {x.Price:C} | {x.StockStatus}");

        // 7. Name with 1-based position (Select with index)
        Console.WriteLine("\n--- 7. Name with position ---");
        var numbered = ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
        foreach (var s in numbered)
            Console.WriteLine(s);

        // 8. Category ascending, then UnitPrice descending
        Console.WriteLine("\n--- 8. Category asc, UnitPrice desc ---");
        var sorted = ProductList
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice);
        foreach (var p in sorted)
            Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice:C}");

        // 9. Beverages sorted by UnitsInStock descending
        Console.WriteLine("\n--- 9. Beverages by stock (desc) ---");
        var beverages = ProductList
            .Where(p => p.Category == "Beverages")
            .OrderByDescending(p => p.UnitsInStock);
        foreach (var p in beverages)
            Console.WriteLine($"{p.ProductName} - stock: {p.UnitsInStock}");

        // 10. Query syntax, compound from: orders placed in 1997 or later
        Console.WriteLine("\n--- 10. Orders from 1997 onwards ---");
        var orders1997Plus =
            from c in CustomerList
            from o in c.Orders
            where o.OrderDate >= new DateTime(1997, 1, 1)
            select new { c.CustomerID, o.OrderDate };
        foreach (var o in orders1997Plus)
            Console.WriteLine($"{o.CustomerID} - {o.OrderDate:d}");

        // 11. ProductName with position number (query-style output)
        Console.WriteLine("\n--- 11. Position + ProductName ---");
        var positions = ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
        foreach (var x in positions)
            Console.WriteLine($"{x.Position}. {x.ProductName}");

        // 12. Sort by word length, then case-insensitively
        Console.WriteLine("\n--- 12. Length, then case-insensitive ---");
        string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        var sortedWords = Arr
            .OrderBy(w => w.Length)
            .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
        foreach (var w in sortedWords)
            Console.WriteLine(w);

        // 13. Digit names whose second letter is 'i', in reverse of original order
        Console.WriteLine("\n--- 13. Second letter 'i', reversed ---");
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var secondI = digits
            .Where(d => d.Length > 1 && d[1] == 'i')
            .Reverse();
        foreach (var d in secondI)
            Console.WriteLine(d);   // nine, eight, six, five
    }
}
