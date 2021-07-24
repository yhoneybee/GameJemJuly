using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSceneManager : MonoBehaviour
{
    public Player player;
    public TMPro.TMP_Text failedText;
    public GameObject btnRetry;
    // Start is called before the first frame update
    void Start()
    {
        btnRetry.SetActive(false);
        failedText.text = "사냥에 실패 했습니다.";
        failedText.gameObject.SetActive(false);
    }

    public void onRetry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SooBin");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Hp <= 0 && btnRetry.activeSelf == false)
        {
            btnRetry.SetActive(true);
            failedText.gameObject.SetActive(true);
        }
    }
}
