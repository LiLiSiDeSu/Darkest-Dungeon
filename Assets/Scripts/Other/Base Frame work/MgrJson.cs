using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class MgrJson : InstanceBaseAuto_Mono<MgrJson>
{    
    public string filePath = "";

    private void Awake()
    {        
        filePath = Application.persistentDataPath + "/Data/JsonData";
    }

   /// <summary>
   /// 存储
   /// </summary>
   /// <param name="data">要存储的对象</param>
   /// <param name="path">文件名前面的路径 直到filePath那边 开头要带/</param>
   /// <param name="fileName">文件名 开头要带/</param>
    public void Save(object data, string path,string fileName)
    {
        if (!Directory.Exists(filePath + path))
            Directory.CreateDirectory(filePath + path);        
        
        File.WriteAllText(filePath + path + fileName + ".Json", JsonConvert.SerializeObject(data, Formatting.Indented));
    }



    /// <summary>
    /// 数据读取
    /// </summary>
    /// <typeparam name="T">读取的数据的类型</typeparam>
    /// <param name="path">文件名前面的路径 直到filePath那边 开头要带/</param>
    /// <param name="fileName">文件名 开头要带/</param>
    /// <param name="callback">回调委托</param>
    /// <returns></returns>
    public T Load<T>(string path, string fileName, UnityAction<T> callback = null) where T : class, new()
    {
        if (!Directory.Exists(filePath + path))
            Directory.CreateDirectory(filePath + path);        
        
        if (!File.Exists(filePath + path + fileName + ".Json"))
        {
            Debug.Log("--- MgrJson: " + filePath + path + fileName + ".Json" + " is null ---");
            return null;
        }

        T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath + path + fileName + ".Json"));

        callback?.Invoke(data);

        return data;
    }
}