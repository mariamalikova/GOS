using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace GOS
{
    class XMLWorker
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>)); 
        public void SerializeXML(List<Book> list, string path) 
        {
            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(f))
            {
                serializer.Serialize(sw, list);
            } 
        }

        public List<Book> DesirealizeXML(string path) 
        {
            List<Book> list = new List<Book>();
            FileStream f2 = new FileStream(path, FileMode.Open);

            using (StreamReader sr = new StreamReader(f2))
            {
                list = serializer.Deserialize(sr) as List<Book>;                
            }

            return list;
        }

    }
}
