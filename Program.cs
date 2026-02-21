using ConnectorMemoryReader;

using (var reader = new ScaleMemoryReader())
{
    var data = reader.ReadData();

    Console.WriteLine($"Time (UTC): {data.TimestampUtc}");
    Console.WriteLine($"Weight: {data.Weight}");
    Console.WriteLine($"Length: {data.Length}");
    Console.WriteLine($"Scale: {data.ScaleNumber}");
}