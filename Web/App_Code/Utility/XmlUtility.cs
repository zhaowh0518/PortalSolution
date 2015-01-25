using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


/// <summary>
/// Xml 序列化与反序列化
/// </summary>
public static class XmlUtility
{
    /// <summary>
    /// Xml 序列化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static string EntyToXml<T>(T t)
    {
        string xmlStr = string.Empty;
        using (MemoryStream stream = new MemoryStream())
        {
            XmlSerializer seriazlizer = new XmlSerializer(typeof(T));
            seriazlizer.Serialize(stream, t);
            using (StreamReader reader = new StreamReader(stream))
            {
                xmlStr = reader.ReadToEnd();
                reader.Close();
            }
            stream.Close();
        }
        return xmlStr;
    }
    /// <summary>
    /// Xml 转为对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str">xml字符串</param>
    /// <returns></returns>
    public static T XmlToEntity<T>(string str)
    {
        T obj = default(T);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        MemoryStream stream = new MemoryStream();
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(str);
            writer.Flush();
            obj = (T)serializer.Deserialize(stream);
        }
        return obj;
    }
    /// <summary>
    /// Xml 转为字典
    /// </summary>
    /// <param name="xmlStr"></param>
    /// <returns></returns>
    public static Dictionary<string, string> XmlToDictionary(string xmlStr)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        XElement xml = XElement.Parse(xmlStr);
        foreach (var item in xml.Elements())
        {
            list.Add(item.Name.LocalName, item.Value);
        }
        return list;
    }
    /// <summary>
    /// 字典列表 转为xml
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static string DictionaryToXml(Dictionary<string, string> list)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<xml>");
        foreach (var item in list)
        {
            sb.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", item.Key, item.Value);
        }
        sb.Append("</xml>");
        return sb.ToString();
    }
}
