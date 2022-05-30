using CommonServices.Utility.IUtilityServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CommonServices.Utility.IUtilityServices
{
    public abstract class XmlConfigBase 
    {

        protected PropertyInfo[] properties = null;

        private readonly string ConfigPath = string.Empty;

        public XmlConfigBase(string xmlPath)
        {
            if (string.IsNullOrWhiteSpace(xmlPath)) throw new ArgumentNullException(nameof(xmlPath));

            if (!File.Exists(xmlPath)) throw new FileNotFoundException(nameof(xmlPath));

            ConfigPath = xmlPath;

            GetConfig();
        }


        public void GetConfig()
        {
            if (properties == null)
                properties = this.GetType().GetProperties().ToArray();

            XmlDocument xmlDoc = LoadXml();

            foreach (PropertyInfo prop in properties)
            {
                PropertyInvoke(prop, xmlDoc, this, $"{Path.GetFileNameWithoutExtension(ConfigPath)}/{prop.Name}");
            }
        }


        private void PropertyInvoke(PropertyInfo prop, XmlDocument xmlDoc, object objToSetValue, string lastPath)
        {
            Type[] normalTypes = new Type[] { typeof(int), typeof(string), typeof(bool) };
            if (normalTypes.Contains(prop.PropertyType))
            {
                string result = xmlDoc.SelectSingleNode($"{lastPath}").InnerText;
                prop.SetValue(objToSetValue, StringToMappedObject(result, prop.PropertyType));
            }
            else
            {
                Type type = prop.PropertyType;
                PropertyInfo[] propProps = type.GetProperties();
                object propInstance = Activator.CreateInstance(type);
                prop.SetValue(objToSetValue, propInstance);
                foreach (PropertyInfo item in propProps)
                {
                    string newPath = $"{lastPath}/{item.Name}";

                    PropertyInvoke(item, xmlDoc, propInstance, newPath);
                }
            }
        }

        public void SaveConfig()
        {
            string root = Path.GetFileNameWithoutExtension(ConfigPath);

            XmlDocument xmlDoc = LoadXml();

            foreach (PropertyInfo prop in properties)
            {
                PropertyInvokeSave(prop, xmlDoc, this, $"{root}/{prop.Name}");
            }

            xmlDoc.Save(ConfigPath);
        }

        private void PropertyInvokeSave(PropertyInfo prop, XmlDocument xmlDoc, object objToGetValue, string lastPath)
        {
            Type[] normalTypes = new Type[] { typeof(int), typeof(string), typeof(bool) };
            if (normalTypes.Contains(prop.PropertyType))
            {
                xmlDoc.SelectSingleNode($"{lastPath}").InnerText = prop.GetValue(objToGetValue).ToString();
            }
            else
            {
                Type type = prop.PropertyType;
                PropertyInfo[] propProps = type.GetProperties();

                foreach (PropertyInfo item in propProps)
                {
                    object propInstance = prop.GetValue(objToGetValue);
                    string newPath = $"{lastPath}/{item.Name}";
                    PropertyInvokeSave(item, xmlDoc, propInstance, newPath);
                }
            }
        }

        private XmlDocument LoadXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigPath);
            return xmlDoc;
        }


        private object StringToMappedObject(string value, Type type)
        {
            switch (type.Name)
            {
                case "Boolean":
                    return bool.Parse(value);
                case "Int32":
                    return int.Parse(value);
                default:
                    return value;
            }
        }

    }
}
