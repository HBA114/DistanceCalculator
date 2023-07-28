using DistanceCalculator.Entities;
using DistanceCalculator.Enums;

namespace DistanceCalculator.Helpers;

public static class Calculator
{
    public static double Calculate(Coordinate coordinate1, Coordinate coordinate2, Metric metric = Metric.Meter)
    {
        var latitude1 = coordinate1.Latitude * (Math.PI / 180.0);
        var longitude1 = coordinate1.Longitude * (Math.PI / 180.0);

        var latitude2 = coordinate2.Latitude * (Math.PI / 180.0);
        var longitude2 = coordinate2.Longitude * (Math.PI / 180.0) - longitude1;

        var d3 = Math.Pow(Math.Sin((latitude2 - latitude1) / 2.0), 2.0) +
                    Math.Cos(latitude1) * Math.Cos(latitude2) * Math.Pow(Math.Sin(longitude2 / 2.0), 2.0);

        var result = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        
        return metric switch
        {
            Metric.Meter => result,
            Metric.Kilometer => result / 1000,
            _ => throw new Exception($"Metric not implemented: {metric}")
        };
    }
}
