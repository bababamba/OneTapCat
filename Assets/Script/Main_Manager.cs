using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main_Manager : MonoBehaviour
{
    [SerializeField] int energy;
    [SerializeField] int energy_time;

    [SerializeField] Image Main_Sprite;
    [SerializeField] Image Right_Sprite;
    [SerializeField] Image Left_Sprite;

    [SerializeField] Sprite[] Main_Image;
    [SerializeField] Sprite[] Right_Image;
    [SerializeField] Sprite[] Left_Image;
    [SerializeField] Sprite[] Ending_Image;
    [SerializeField] Sprite[] Fail_Image;

    [SerializeField] TMP_Text UpperMessage;
    [SerializeField] GameObject Endcard;
    [SerializeField] TMP_Text EndMessage;
    [SerializeField] GameObject Failcard;
    [SerializeField] TMP_Text FailMessage;
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject SelectScreen;
    [SerializeField] GameObject[] StageSelect;
    [SerializeField] StaminaManager stamina;
    


    int stage = 0;
    int progress = 0;
    int EndA = 0;
    int EndB = 0;
    int[] data = {0,5,1,2,3,4,6,0};
    string[] script = { 
        "\"냐아앙..\" \n지각해서 혼났다. 5분만 더 잔다는 게 30분이나 자버렸다니…", 
        "\"나 좀 도와조라냥..\" \n움직일수록 더 꼬여! 실을 가지고 놀다 몸에 엉켜버렸다.",
        "\"가지고 있는 생선 다 내놔!!\" \n불량식품을 즐겨먹다가 불량 냥이가 되어버렸다. ",
        "\"저.. 저기..\" \n친구를 사귀고 싶지만, 말 걸기는 무서워… 귀여운 부끄 냥이가 됐다!",
        "\"여기 여기 모여라! 나랑 놀자냥!\" \n모두가 좋아하는 인싸 냥이가 됐다! ",
        "\"모르는 게 없다냥\" \n공부도 체육도 1등! 못하는 게 없는 전교 1등 냥이가 됐다!",
    };
    string[] quest = { "아침이다.. 너무 피곤한데 어떡하지?","학교 가기 전 문방구에서 뭐 사지?","드디어 쉬는 시간이다! 나는 뭘 할까?","체육 시간에 어떤 운동을 할까?",
        "지각한 냥이","실에 걸린 냥이",
        "골목대장 냥아치","소심한 부끄 냥이","인기 스타 인싸 냥이","전교 1등 모범 냥이" };

    // Start is called before the first frame update
    void Start()
    {
        stage = 1;progress = 0;// 임시
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScreen(int progressNumber) {
        Debug.Log(progress);
        UpperMessage.text = quest[progress];
        Main_Sprite.sprite = Main_Image[(stage - 1) * 4 + progressNumber];
        Right_Sprite.sprite = Right_Image[(stage - 1) * 4 + progressNumber];
        Left_Sprite.sprite = Left_Image[(stage - 1) * 4 + progressNumber];
    }
    public void FailScreen(int endNumber)
    {
        Main_Sprite.sprite = Fail_Image[(stage - 1) * 2 + endNumber-1];
        
        Failcard.SetActive(true);
        UpperMessage.text = quest[3 + endNumber];
        FailMessage.text = script[endNumber - 1];

    }
    int Ending()
    {
        int temp = 0;
        if (EndA == 1)
        {
            if (EndB == 1)
                temp = 1;
            else
                temp = 2;
        }
        else
        {
            if (EndB == 1)
                temp = 3;
            else
                temp = 4;
        }


        return temp;
    }
    public void EndingScreen(int endNumber)
    {
        Main_Sprite.sprite = Ending_Image[(stage - 1) * 4 + endNumber-1];
        EndMessage.text = script[endNumber + 1];
        UpperMessage.text = quest[5 + endNumber];
        Endcard.SetActive(true);

    }
    public void Retry()
    {
        progress = 0;
        Failcard.SetActive(false);
        UpdateScreen(progress);
    }
    public void ButtonLeft()
    {
        
        
        if (data[progress * 2] == 5)
        {
            FailScreen(1);
        }
        else if (data[progress * 2] == 6)
        {
            FailScreen(2);
        }
        else if (data[progress * 2] == 1)
        {
            EndA = 1;
            progress++;
            if (progress == 4)
                EndingScreen(Ending());
            else
                UpdateScreen(progress);
        }
        else if (data[progress * 2] == 3)
        {
            EndB = 1;
            progress++;
            if (progress == 4)
                EndingScreen(Ending());
            else
                UpdateScreen(progress);
        }
        else if (data[progress * 2] == 0)
        {
            progress++;
            if (progress == 4)
                EndingScreen(Ending());
            else
                UpdateScreen(progress);
        }
        
    }
    public void ButtonRight()
    {
        if (progress == 4)
            EndingScreen(Ending());
        else
        {
            if (data[progress * 2+1] == 5)
            {
                FailScreen(1);
            }
            else if (data[progress * 2 + 1] == 6)
            {
                FailScreen(2);
            }
            else if (data[progress * 2 + 1] == 2)
            {
                EndA = 2;
                progress++;
                if (progress == 4)
                    EndingScreen(Ending());
                else
                    UpdateScreen(progress);
            }
            else if (data[progress * 2 + 1] == 4)
            {
                EndB = 2;
                progress++;
                if (progress == 4)
                    EndingScreen(Ending());
                else
                    UpdateScreen(progress);
            }
            else if (data[progress * 2 + 1] == 0)
            {
                progress++;
                if (progress == 4)
                    EndingScreen(Ending());
                else
                    UpdateScreen(progress);
            }
        }
    }

    public void CloseAll()
    {

        SelectScreen.SetActive(false);
        Failcard.SetActive(false);
        Endcard.SetActive(false);
        MainGame.SetActive(false);
    }
    public void OpenMainGame()
    {
        CloseAll();
        MainGame.SetActive(true);
    }
    public void OpenStageSelect(int select)
    {
        CloseAll();
        stage = select;
        StageSelect[select-1].SetActive(true);
    }
    public void OpenStagesSelectScreen()
    {
        CloseAll();
        progress = 0;
        UpdateScreen(0);
        SelectScreen.SetActive(true);
    }



}
