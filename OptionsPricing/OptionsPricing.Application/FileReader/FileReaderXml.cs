using OptionsPricing.Application.FileReader.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace OptionsPricing.Application.FileReader
{
    public class FileReaderXml : IFileReader
    {
        public List<TReturn> Read<TReturn>(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            List<TReturn> investiments = new List<TReturn>();
            foreach (XmlNode xmlNode in doc.SelectNodes("//trade"))
            {
                investiments.Add(ConvertToObject<TReturn>(xmlNode));
            }
            return investiments;
        }

        private TReturn ConvertToObject<TReturn>(XmlNode xmlNode)
        {
            TReturn objectToSet = (TReturn)Activator.CreateInstance(typeof(TReturn));

            foreach (PropertyInfo property in objectToSet.GetType().GetProperties())
            {
                string value = xmlNode.Attributes[property.Name.ToLower()].Value;
                if (property.PropertyType == typeof(Int32))
                {
                    property.SetValue(objectToSet, Convert.ToInt32(value));
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(objectToSet, Convert.ToDateTime(value));
                }
                else if (property.PropertyType == typeof(double))
                {
                    property.SetValue(objectToSet, Convert.ToDouble(value));
                }
                else if (property.PropertyType == typeof(char))
                {
                    property.SetValue(objectToSet, Convert.ToChar(value));
                }
                else
                {
                    property.SetValue(objectToSet, value);
                }
            }

            return objectToSet;
        }
    }
}