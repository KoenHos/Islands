using static Aruba.Core.ClimateTypes;

namespace Aruba.Core
{
    public class Island
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public ClimateType ClimateType{ get; set; }
    }
}
