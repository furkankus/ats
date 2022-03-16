using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ats
{
    public class ConfigManager
    {
        private static XmlTextReader txtReader = null;

        static ConfigManager()
        {
            try
            {
                FileStream fic = null;
                string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string path = AppPath + @"\\document.xml";
                fic = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                txtReader = new XmlTextReader(fic);
            }
            catch { }
        }

        /// <summary>
        /// Provided the reference customer identifier.
        /// </summary>
        /// <returns></returns>

        public static int getRefClientId()
        {
            try
            {
                while (txtReader.Read())
                {
                    XmlNodeType nType = txtReader.NodeType;
                    if (nType == XmlNodeType.Element)
                    {
                        if (txtReader.Name.Equals("Mainbody") && txtReader.GetAttribute("Orders").Equals("OrdersNo"))
                        {
                            string strValue = txtReader.GetAttribute("value");
                            return Convert.ToInt32(strValue);
                        }
                    }
                }
            }
            catch { }
            return -1;
        }
    }
}
