using CommonServices.Utility.IUtilityServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonServices.Utility.UtilityServices
{
    public class XmlSerializeHelper: IXmlSerializeHelper
    {
        public bool XmlSerialize<T>(T obj, string xmlPath)
        {

            try
            {
                using (StreamWriter sw = new StreamWriter(xmlPath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(sw, obj);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public T XmlDeSerialize<T>(string xmlPath) where T : class
        {
            try
            {
                if (!File.Exists(xmlPath))
                    return default(T);

                using (StreamReader reader = new StreamReader(xmlPath))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
                throw ex;
            }
        }
    }
}
