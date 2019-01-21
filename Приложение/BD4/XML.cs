using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using CafeLibrary;

namespace BD4
{
    class XML
    {
        public static string targetNamespace = "http://tempuri.org/XMLSchema1.xsd";
        public static string xds = "XMLSchema1.xsd";

        private static bool GetCafeSup(Cafe cafe, Supplier supplier)
        {
            if (cafe.idcafe == supplier.cafe.idcafe)
                return true;
            return false;
        }

        public static bool export(string f_name)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement cafeElement, SupElemnt, root;
            XmlDeclaration declaration;
            XmlAttribute attribute;

            doc.Schemas.Add(targetNamespace, xds);
            declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            root = doc.CreateElement("BDCafe");

            doc.AppendChild(root);
            List<Cafe> cafeList;
            cafeList = Cafe.Get();

            List<Supplier> supList;
            supList = Supplier.Get();

            foreach (Cafe cafe in cafeList)
            {
                cafeElement = doc.CreateElement("Cafe");

                //attribute = doc.CreateAttribute("idcafe");
                //attribute.Value = cafe.idcafe.ToString();
                //cafeElement.Attributes.Append(attribute);

                attribute = doc.CreateAttribute("owner");
                attribute.Value = cafe.owner;
                cafeElement.Attributes.Append(attribute);

                attribute = doc.CreateAttribute("title");
                attribute.Value = cafe.title;
                cafeElement.Attributes.Append(attribute);

                attribute = doc.CreateAttribute("address");
                attribute.Value = cafe.address;
                cafeElement.Attributes.Append(attribute);

                attribute = doc.CreateAttribute("phone");
                attribute.Value = cafe.phone.ToString();
                cafeElement.Attributes.Append(attribute);

                attribute = doc.CreateAttribute("rating");
                attribute.Value = cafe.rating.ToString();
                cafeElement.Attributes.Append(attribute);

                foreach (Supplier supplier in supList)
                {
                    if (GetCafeSup(cafe, supplier) == true)
                    {
                        SupElemnt = doc.CreateElement("Supplier");

                        //attribute = doc.CreateAttribute("idsupplier");
                        //attribute.Value = supplier.idsupplier.ToString();
                        //SupElemnt.Attributes.Append(attribute);

                        attribute = doc.CreateAttribute("title");
                        attribute.Value = supplier.title;
                        SupElemnt.Attributes.Append(attribute);

                        attribute = doc.CreateAttribute("product");
                        attribute.Value = supplier.product;
                        SupElemnt.Attributes.Append(attribute);

                        attribute = doc.CreateAttribute("Frequencyofdeliveries");
                        attribute.Value = supplier.FrequencyOfDeliveries.ToString();
                        SupElemnt.Attributes.Append(attribute);

                        attribute = doc.CreateAttribute("Volumeofdeliveries");
                        attribute.Value = supplier.VolumeOfDeliveries.ToString();
                        SupElemnt.Attributes.Append(attribute);


                        attribute = doc.CreateAttribute("cafeAddress");
                        attribute.Value = supplier.cafe.address; //ID
                        SupElemnt.Attributes.Append(attribute);

                        cafeElement.AppendChild(SupElemnt);
                    }
                }
                root.AppendChild(cafeElement);

            }
            doc.Save(f_name);
            try
            {
                doc.DocumentElement.SetAttribute("xmlns", targetNamespace);
                doc.Validate(null);
                return true;
            }
            catch
            {
                return false;
            }

        }

        static public void import(string f_name)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(f_name);
            XmlElement root = doc.DocumentElement;
            doc.Schemas.Add(targetNamespace, xds);
            if (string.IsNullOrEmpty(doc.DocumentElement.NamespaceURI))
            {
                doc.DocumentElement.SetAttribute("xmlns", targetNamespace);
                doc.LoadXml(doc.InnerXml);
            }
            //try
            //{
            //    doc.DocumentElement.SetAttribute("xmlns", targetNamespace);
            //    doc.Validate(null);
            //}
            //catch
            //{
            //    MessageBox.Show("Документ не соответсвует схеме", "Информация", MessageBoxButtons.OKCancel);
            //    return;
            //}

            foreach (XmlNode n in root)
            {
                Cafe c = new Cafe();
                List<Cafe> cafeList;
                cafeList = Cafe.Get();

                //c.idcafe = Int32.Parse(n.Attributes["idcafe"].Value);
                c.owner = n.Attributes["owner"].Value;
                c.title = n.Attributes["title"].Value;
                c.address = n.Attributes["address"].Value;
                c.phone = Int32.Parse(n.Attributes["phone"].Value);
                c.rating = Int32.Parse(n.Attributes["rating"].Value);

                Cafe np = new Cafe();
                np = np.search(c.address);
                if (np == null)
                {
                    c.add(c);
                    cafeList = Cafe.Get();
                    c.idcafe = cafeList.LastOrDefault().idcafe;
                }
                else
                {
                    c.change(np.idcafe, c);//обновляет
                    c.idcafe = np.idcafe;
                }

                foreach (XmlNode t in n)
                {
                    Supplier s = new Supplier();
                    if (t.Attributes["cafeAddress"].Value != c.address) break;
                    //s.idsupplier = Int32.Parse(t.Attributes["idsupplier"].Value);
                    s.title = t.Attributes["title"].Value;
                    s.product = t.Attributes["product"].Value;
                    s.FrequencyOfDeliveries = Int32.Parse(t.Attributes["Frequencyofdeliveries"].Value);
                    s.VolumeOfDeliveries = Int32.Parse(t.Attributes["Volumeofdeliveries"].Value);
                    s.cafe = Cafe.Get(c.idcafe);

                    Supplier sp = new Supplier();
                    sp = sp.search(s.title);
                    if (sp == null)
                    {
                        s.add(s);
                    }
                    else
                    {
                        s.change(sp.idsupplier, s);
                    }
                }
                
            }
        }
    }
}
