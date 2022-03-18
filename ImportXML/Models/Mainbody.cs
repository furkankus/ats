using System.ComponentModel.DataAnnotations.Schema;

namespace ImportXML.Models
{
    [Table("Mainbody")]
    public class Mainbody
    {
        public string OrderNo { get; set; }

        public string OrderDesc { get; set; }

        public string OrderQuentity { get; set; }
    }
}
