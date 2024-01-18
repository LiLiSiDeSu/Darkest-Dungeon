using Newtonsoft.Json;
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
    /// <param name="folderPath">文件夹路径 直到filePath那边 开头要带/</param>
    /// <param name="fileName">文件名 开头要带/</param>
    public void Save(object data, string folderPath, string fileName)
    {
        if (!Directory.Exists(filePath + folderPath))
            Directory.CreateDirectory(filePath + folderPath);

        File.WriteAllText(filePath + folderPath + fileName + ".Json", JsonConvert.SerializeObject(data, Formatting.Indented));
    }

    /// <summary>
    /// 读取
    /// </summary>
    /// <typeparam name="T">读取的数据的类型</typeparam>
    /// <param name="folderPath">文件名夹路径 直到filePath那边 开头要带/</param>
    /// <param name="fileName">文件名 开头要带/</param>
    /// <param name="callback">回调委托</param>
    /// <returns></returns>
    public T Load<T>(string folderPath, string fileName, UnityAction<T> callback = null) where T : class, new()
    {
        if (!Directory.Exists(filePath + folderPath))
            Directory.CreateDirectory(filePath + folderPath);

        if (!File.Exists(filePath + folderPath + fileName + ".Json"))
        {
            Debug.Log("--- MgrJson: " + filePath + folderPath + fileName + ".Json" + " is null ---");
            return null;
        }

        T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath + folderPath + fileName + ".Json"));

        callback?.Invoke(data);

        return data;
    }
}