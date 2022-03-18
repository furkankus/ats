using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Demo.Helpers.ExternalModels;

namespace Demo.Helpers
{
    public class XmlReader
    {
        public List<Products> RetrunListOfProducts()
        {  
            string xmlData = HttpContext.Current.Server.MapPath("~//Success//*.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);  
            var products = new List<Products>();
            products = (from rows in ds.Tables[0].AsEnumerable()
                select new Products  
                {  
                    OrderNo = rows[0].ToString(), //Convert row to int  
                    OrderDesc = rows[1].ToString(),  
                    OrderQuentity = rows[2].ToString(),  
                }).ToList();  
            return products;  
        }  
    }
}
