using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo.Helpers.ExternalModels
{
    [Serializable]
    [XmlRoot("MainBody"), XmlType("MainBody")]
    public class Products
    {
        public string OrderNo { get; set; }
        public string OrderDesc { get; set; }
        public string OrderQuentity { get; set; }
    }
}
