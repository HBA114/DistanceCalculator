using DistanceCalculator.Entities;
using DistanceCalculator.Helpers;

Coordinate coordinate1 = new(41.0853120, 28.9770658);
Coordinate coordinate2 = new(41.0558508, 29.1054691);

var res = Calculator.Calculate(coordinate1, coordinate2);
res = Math.Round(res, 2);
Console.WriteLine($"Distance: {res} meters");
