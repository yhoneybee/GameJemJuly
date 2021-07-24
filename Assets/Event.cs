using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< Updated upstream
using TMPro;
=======
>>>>>>> Stashed changes

public class Event : MonoBehaviour
{
    public int Day=0; //진행 날짜
    public int windchance = 33; // 배 타고 바람불 확률
    public int Daytime = 600;
    public Player player;
    public Image Screen;
<<<<<<< Updated upstream
    private float time=1000;
    private int PriateDay;
    private bool PriateInvade;
=======
    private float time;
    private int PriateDay;
    private bool PriateInvade;
    public bool mainisland;
>>>>>>> Stashed changes
    private bool ship;
    public bool mainisland;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        PriateDay = 6 + Random.Range(-2, 2);
        Debug.Log($"해적등장일 {PriateDay}");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > Daytime)
        {
            Day++;
<<<<<<< Updated upstream
            Text.GetComponent<TextMeshProUGUI>().text ="Day "+ Day;
=======
>>>>>>> Stashed changes

            Debug.Log($"지난 날 {Day}");
            time = 0;
            if (ship)
            {
                if (Random.Range(1, 101) > windchance)
                {
                    //여기는 배 시스템이 생겨야 만들수 있을듯 합니다.
                }
            }
            if (Day >= PriateDay)
            {
                PriateEvent();
                PriateDay = (Day + 6) + Random.Range(-2, 2);
                Debug.Log($"다음 해적 등장일 {PriateDay}");
            }
        }
        if (!PriateInvade)
        {
            if (mainisland)
                time += Time.deltaTime;
            else if (ship)
            {
                time += Time.deltaTime * 25;
            }
        }
    }
    void PriateEvent()
    {
        PriateInvade = true;
        if (ship)
        {

            //이 부근은 전체적인 시스템이 만들어야 패널티를 부여할듯 합니다.
        }
        else
        {
            StartCoroutine(Priate());
        }
    }
    IEnumerator Priate()
    {
        Debug.Log("메인섬에서의 해적이벤트 발동");
        for (float alpah = 0.1f; alpah <= 1.1f; alpah += 0.1f)
        {
            Screen.color = new Color(0f, 0f, 0f, alpah);
<<<<<<< Updated upstream
            yield return new WaitForSeconds(0.05f);
        }
        //Firework 소리재생

        //이곳에 인벤 없애는 함수와 함께 집부수는 함수
        player.Invoke("Pirate", 0);
        yield return new WaitForSeconds(3);
        for (float alpah = 1f; alpah >= -0.1f; alpah -= 0.1f)
        {
            Screen.color = new Color(0f, 0f, 0f, alpah);
            yield return new WaitForSeconds(0.05f);
        }
        PriateInvade = false;
=======
            yield return new WaitForSeconds(0.1f);
        }
        //Firework 소리재생
        yield return new WaitForSeconds(5);
        for (float alpah = 1f; alpah >= -0.1f; alpah -= 0.1f)
        {
            Screen.color = new Color(0f, 0f, 0f, alpah);
            yield return new WaitForSeconds(0.1f);
        }
        player.Invoke("Pirate", 0);
>>>>>>> Stashed changes
    }
}
