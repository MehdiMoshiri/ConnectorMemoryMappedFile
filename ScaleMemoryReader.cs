using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorMemoryReader
{
    using System;
    using System.IO.MemoryMappedFiles;

    public class ScaleMemoryReader : IDisposable
    {
        private const string MapName = "ConnectorMemory1";

        private readonly MemoryMappedFile _mmf;
        private readonly MemoryMappedViewAccessor _accessor;

        public ScaleMemoryReader()
        {
            _mmf = MemoryMappedFile.OpenExisting(MapName);
            _accessor = _mmf.CreateViewAccessor();
        }

        public ScaleData ReadData()
        {
            int position = 0;

            long ticks = _accessor.ReadInt64(position);
            position += sizeof(long);

            double weight = _accessor.ReadDouble(position);
            position += sizeof(double);

            double length = _accessor.ReadDouble(position);
            position += sizeof(double);

            int scaleNumber = _accessor.ReadInt32(position);

            return new ScaleData
            {
                TimestampUtc = new DateTime(ticks, DateTimeKind.Utc),
                Weight = weight,
                Length = length,
                ScaleNumber = scaleNumber
            };
        }

        public void Dispose()
        {
            _accessor?.Dispose();
            _mmf?.Dispose();
        }
    }

    public class ScaleData
    {
        public DateTime TimestampUtc { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public int ScaleNumber { get; set; }
    }
}
