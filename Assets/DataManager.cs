using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    static DataManager _instance;
    public static DataManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataManager>();
            }
            return _instance;
        }
    }

    public List<Resource> list_resourceInfo = new List<Resource>();    // 조합 관련 정보. json으로 받아옴
    public List<Item> list_itemInfo = new List<Item>();

    void Awake()
    {
        // todo : 나눠놓은 itemdata, resourcedata json 파일 합치기
        list_resourceInfo = LoadData<Resource>("item")["resources"];
        list_itemInfo = LoadData<Item>("item")["items"];
    }

    public Dictionary<string, List<T>> LoadData<T>(string _dataType)
    {
        string fileName = "";
        switch (_dataType)
        {
            case "item":
                {
                    fileName = "itemData.json";
                }
                break;
            default:
                {
                    Debug.LogError("잘못된 데이터 타입 입력");
                }
                break;
        }

        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        string data = File.ReadAllText(path);


        var deserializedData = JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(data);
        return deserializedData;
    }
}
