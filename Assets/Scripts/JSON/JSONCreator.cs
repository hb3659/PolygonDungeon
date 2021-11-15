using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class JSONCreator : MonoBehaviour
{
    private static JSONCreator instance;

    public static JSONCreator Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    void Awake()
    {
        Singleton();
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    // Newtonsoft.Json 사용
    public string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public T JsonToObject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    // JsonUtility 사용
    public string UObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public T UJsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }

    // Newtonsoft.Json 사용
    public void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    // JsonUtility 사용
    public void UCreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public T ULoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
}
