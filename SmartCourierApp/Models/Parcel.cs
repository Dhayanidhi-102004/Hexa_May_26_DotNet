using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCourierApp.Models
{
    public class Parcel
    {
        public double Weight { get; set; }
        public string SourceCity { get; set; } = string.Empty;
        public string DestinationCity { get; set; } = string.Empty;
        public string DeliveryType { get; set; } = string.Empty;
    }
}
