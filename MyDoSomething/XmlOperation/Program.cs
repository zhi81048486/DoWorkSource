using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlOperation
{
    public enum ColumnEnum
    {

        Manage_Plan_Qh = 0,

        Manage_Group_Qh,

        Manage_Idea_Qh,

        Manage_Keyword_Qh,

        Manage_Sublink_Qh,

        Manage_Image_Qh,

        Manage_Phone_Qh,

        Manage_Plan_Baidu,

        Manage_Group_Baidu,

        Manage_Idea_Baidu,

        Manage_Keyword_Baidu,

        Manage_Sublink_Baidu,

        Manage_Image_Baidu,

        Bidding_Setting_Baidu,
        Bidding_Analyzes_Baidu,
        Bidding_Setting_Qh,
        Bidding_Analyzes_Qh,
        Bidding_Setting_Sogou,
        Bidding_Analyzes_Sogou
    }

    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                Bar = "some & value",
                Nested = "data"
            };
            new XmlSerializer(typeof(Foo)).Serialize(Console.Out, foo);



            XmlTextWriter myXmlTextWriter = new XmlTextWriter(@"..\..\Book1.xml", Encoding.UTF8);
            //使用 Formatting 属性指定希望将 XML 设定为何种格式。 这样，子元素就可以通过使用 Indentation 和 IndentChar 属性来缩进。
            myXmlTextWriter.Formatting = Formatting.Indented;
            //设置为true时，编码格式不起作用
            myXmlTextWriter.WriteStartDocument(false);
            myXmlTextWriter.WriteStartElement("SettingColumns");

            myXmlTextWriter.WriteComment("记录列的信息");
            foreach (var enumvalue in Enum.GetNames(typeof(ColumnEnum)))
            {
                myXmlTextWriter.WriteStartElement("BiddingColumns");

                myXmlTextWriter.WriteAttributeString("name", enumvalue);
                myXmlTextWriter.WriteStartElement("ColumnValue");
                myXmlTextWriter.WriteEndElement();
                myXmlTextWriter.WriteEndElement();
            }
            //myXmlTextWriter.WriteStartElement("BiddingColumns");

            //myXmlTextWriter.WriteAttributeString("name", ColumnEnum.Bidding_Analyzes_Baidu.ToString());
            ////myXmlTextWriter.WriteAttributeString("ColumnValue", "");
            //myXmlTextWriter.WriteStartElement("ColumnValue");
            //myXmlTextWriter.WriteEndElement();

            ////myXmlTextWriter.WriteElementString("author", "张三");
            ////myXmlTextWriter.WriteElementString("title", "职业生涯规划");
            ////myXmlTextWriter.WriteElementString("price", "16.00");

            //myXmlTextWriter.WriteEndElement();
            //myXmlTextWriter.WriteStartElement("BiddingColumns");

            //myXmlTextWriter.WriteAttributeString("name", "BiddingAd_Qh");
            ////myXmlTextWriter.WriteAttributeString("ColumnValue", "");
            //myXmlTextWriter.WriteStartElement("ColumnValue");

            //myXmlTextWriter.WriteEndElement();
            //myXmlTextWriter.WriteEndElement();
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.Flush();
            myXmlTextWriter.Close();
            Console.ReadKey();
        }


    }
    public class Foo
    {
        //[XmlAttribute]
        public string Bar { get; set; }
        public string Nested { get; set; }
    }

}
