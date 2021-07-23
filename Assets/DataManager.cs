using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    Dictionary<string, List<Resource>> dic_CombinationManual = new Dictionary<string, List<Resource>>();     // 조합 관련 정보. json으로 받아옴

    void Awake()
    {
        LoadData("resource");
        Debug.Log(dic_CombinationManual["resources"][0].ResourceKind);
    }

    public void LoadData(string _dataType)
    {
        string fileName = "";
        switch (_dataType)
        {
            case "resource":
                {
                    fileName = "resourceData.json";
                }
                break;
            default:
                {
                    Debug.LogError("잘못된 데이터 타입 입력");
                }
                break;
        }

        string path = Path.Combine(Application.dataPath, fileName);
        string data = File.ReadAllText(path);

        dic_CombinationManual = JsonConvert.DeserializeObject<Dictionary<string, List<Resource>>>(data);
    }
}
