using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    Dictionary<string, List<Resource>> dic_CombinationManual = new Dictionary<string, List<Resource>>();     // ���� ���� ����. json���� �޾ƿ�

    void Awake()
    {
        LoadData("item");
<<<<<<< Updated upstream
        Debug.Log(dic_CombinationManual["resources"][0].ResourceKind);
=======
>>>>>>> Stashed changes
    }

    public void LoadData(string _dataType)
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
                    Debug.LogError("�߸��� ������ Ÿ�� �Է�");
                }
                break;
        }

        string path = Path.Combine(Application.dataPath, fileName);
        string data = File.ReadAllText(path);

        dic_CombinationManual = JsonConvert.DeserializeObject<Dictionary<string, List<Resource>>>(data);
    }
}