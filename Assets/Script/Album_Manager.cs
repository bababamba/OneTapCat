using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Album_Manager : MonoBehaviour
{
    [SerializeField] TMP_Text[] StageTitles;
    [SerializeField] GameObject[] Stars;
    [SerializeField] GameObject[] CurStars;
    [SerializeField] Image[] Endings;

    [SerializeField] TMP_Text[] Endings_Title;
    [SerializeField] GameObject[] RewardGuard;
    [SerializeField] GameObject[] CGGuard;
    [SerializeField] GameObject[] RewardCheck;


    [SerializeField] GameObject[] Cats;
    bool[] CheckedReward = { 
        false, false, false, false, false, false,
        false, false, false, false, false, false, 
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false };
    int CurStage = 0;
    void Start()
    {
        ChangeStage(1);
    }
    public void ChangeStage(int stageNum)
    {
        CurStage = stageNum;
        CatSelect(stageNum);
        UpdateStars();
        StageTitles[0].text = "stage " + stageNum.ToString();
        StageTitles[1].text = Main_Manager.instance.stageName[stageNum - 1];
        for (int i=0; i < 6; i++){
            //Debug.Log(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]);
            int temp = 0;
            ActiveCurStars(stageNum);
            //CurStars[i].SetActive(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]);

            RewardGuard[i].SetActive(!(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]));
            CGGuard[i].SetActive(!(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]));
            //Debug.Log(CheckedReward[(stageNum - 1) * 6 + i]);
            RewardCheck[i].SetActive(CheckedReward[(stageNum - 1) * 6 + i]);
            if (i < 2)
                Endings[i].sprite = Main_Manager.instance.Fail_Sprite[(stageNum - 1) * 2 + i];
            else
                Endings[i].sprite = Main_Manager.instance.Ending_Sprite[(stageNum - 1) * 4 + i - 2];

            Endings_Title[i].text = Main_Manager.instance.quest1[(stageNum - 1) * 10 + i + 4];


        }
    }
    public void OpenAlbum()
    {
        ChangeStage(CurStage);
    }
    void ActiveCurStars(int stageNum)
    {
        // Cleared 배열에서 true인 요소의 개수를 세기
        int clearedCount = 0;
        for (int i = 0; i < 6; i++)
        {
            if (Main_Manager.instance.cleared[(stageNum - 1) * 6 + i])
            {
                clearedCount++;
            }
        }

        // 별들을 앞에서부터 clearedCount만큼 활성화
        for (int i = 0; i < 6; i++)
        {
            if (i < clearedCount)
            {
                CurStars[i].SetActive(true);
            }
            else
            {
                CurStars[i].SetActive(false);
            }
        }

    }
    public void UpdateStars()
    {
        int temp = 0;
        for(int i = 0; i < 5; i++)
        {
            temp = 0;
            for (int j = 0; j < 6; j++)
            {
                if (Main_Manager.instance.cleared[i * 6 + j])
                    temp++;
            }
            for (int j = 0; j < 6; j++)
            {
                if (j < temp)
                    Stars[i * 6 + j].SetActive(true);
                else
                    Stars[i * 6 + j].SetActive(false);
            }
        }
    }
    void CatSelect(int stageNum)
    {
        foreach (GameObject cat in Cats)
            cat.SetActive(false);
        Cats[stageNum - 1].SetActive(true);
    }
    public void PressButton(int Num)
    {
        CheckedReward[(CurStage - 1) * 6 + Num] = true;
        RewardCheck[Num].SetActive(CheckedReward[(CurStage - 1) * 6 + Num]);
        StaminaManager.instance.StaminaUp(5);
        Fx_Manager.instance.GetItemFx(5);
    }
    

}
