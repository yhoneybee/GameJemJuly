using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public string MainSceneName = "SooBin";
    public static GameManager Instance = null;
    public CollectionSite CollectionSite { get; private set; }

    private int _day = 1;
    public int Day
    {
        get => _day;
        set
        {
            _day = value;
        }
    }
    [SerializeField]
    private float OneDay = 600.0f;

    public float CurTime
    {
        get => _curTime;
        set
        {
            _curTime = value;
            // 10분이 지나면 하루.
            if (_curTime > OneDay)
            {
                Day++;
                _curTime = 0;
            }
            
        }
    }
    private float _curTime = 0;
    public bool isPlaying = true;
    public string boatName = "";

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(isPlaying) CurTime += Time.deltaTime;
        // 플레이어가 밝고 있는 땅을 확인하여 CollectionSite를 변경함.
    }
    public void NewStart()
    {
        PlayerPrefs.SetInt("Hp", 100);
        PlayerPrefs.SetInt("Thirst", 100);
        PlayerPrefs.SetInt("Day", 1);
        Inventory.instance.ResetInventory();
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainSceneName);
    }
    public void LoadExitScene()
    {
        PlayerPrefs.SetInt("Day", Day);
        PlayerPrefs.SetString("Boat", boatName);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EscapeScene");
    }
    public void SavePlayerData(Player _player)
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == MainSceneName) Inventory.instance.SaveInventory();
        PlayerPrefs.SetInt("Hp", _player.Hp);
        PlayerPrefs.SetInt("Thirst", _player.Thirst);
        PlayerPrefs.SetInt("Day", Day);
    }
    public void LoadPlayerData(Player _player)
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == MainSceneName)
        {
            Inventory.instance.ReloadInvetory();
        }
        _player.Hp = PlayerPrefs.GetInt("Hp");
        _player.Thirst = PlayerPrefs.GetInt("Thirst");
        Day = PlayerPrefs.GetInt("Day", Day);
    }

}
