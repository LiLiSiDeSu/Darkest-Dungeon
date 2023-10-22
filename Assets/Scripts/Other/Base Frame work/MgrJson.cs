using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MgrJson : InstanceBaseAuto_Mono<MgrJson>
{
    /// <summary>
    /// 这个路径只到文件夹路径
    /// </summary>
    public string filePath;

    protected override void Awake()
    {
        base.Awake();

        filePath = Application.persistentDataPath + "/Data/JsonData";
    }

    public void Save(object data, string fileName)
    {
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);        
        
        File.WriteAllText(filePath + fileName + ".Json", JsonConvert.SerializeObject(data, Formatting.Indented));
    }

    public T Load<T>(string fileName) where T : class, new()
    {
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);        
        
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath + fileName + ".Json"));
    }
}