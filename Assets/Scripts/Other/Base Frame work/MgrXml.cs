using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class SerializerDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{    
    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        XmlSerializer TKeyS = new XmlSerializer(typeof(TKey));
        XmlSerializer TValueS = new XmlSerializer(typeof(TValue));

        reader.Read();
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            TKey key = (TKey)TKeyS.Deserialize(reader);
            TValue value = (TValue)TValueS.Deserialize(reader);
            this.Add(key, value);
        }
        reader.Read();
    }

    public void WriteXml(XmlWriter writer)
    {
        XmlSerializer TKeyS = new XmlSerializer(typeof(TKey));
        XmlSerializer TValueS = new XmlSerializer(typeof(TValue));

        foreach (KeyValuePair<TKey, TValue> item in this)
        {
            TKeyS.Serialize(writer, item.Key);
            TValueS.Serialize(writer, item.Value);
        }
    }
}

public class MgrXml : InstanceBaseAuto_Mono<MgrXml>
{
    /// <summary>
    /// 这个路径只到文件夹路径
    /// </summary>
    public string filePath;

    protected override void Awake()
    {
        base.Awake();

        filePath = Application.persistentDataPath + "/Data/XmlData";        
    }

    public void Save(object data, string fileName)
    {
        if (!File.Exists(filePath))
            Directory.CreateDirectory(filePath);

        string path = filePath + fileName + ".xml";

        using (StreamWriter writer = new StreamWriter(path))
        {
            XmlSerializer s = new XmlSerializer(data.GetType());
            s.Serialize(writer, data);
        }
    }
    
    public T Load<T>(string fileName) where T : class, new()
    {
        if (!File.Exists(filePath))
            Directory.CreateDirectory(filePath);

        string path = filePath + fileName + ".xml";
        
        if (!File.Exists(path)) 
            return Activator.CreateInstance(typeof(T)) as T;

        using (StreamReader reader = new StreamReader(path))
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            return s.Deserialize(reader) as T;
        }            
    }
}
