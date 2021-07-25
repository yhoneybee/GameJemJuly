using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaSceneManager : MonoBehaviour
{
    public Player player;
    public TMPro.TMP_Text failedText;
    public GameObject btnRetry;
    //public Slider BR;
    //public Slider Limit;
    // Start is called before the first frame update
    void Start()
    {
       // Limit.value = 60;
       // BR.value = 15;
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
/*        if(player.transform.position.y>= 3)
        {
            BR.value += 7 * Time.deltaTime;
        } 
        else*/
        //BR.value -= Time.deltaTime;
        //Limit.value -= Time.deltaTime;
    }
}
