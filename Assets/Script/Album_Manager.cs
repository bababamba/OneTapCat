using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Album_Manager : MonoBehaviour
{
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
        for (int i=0; i < 6; i++){

            //Debug.Log(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]);
            CurStars[i].SetActive(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]);
            RewardGuard[i].SetActive(!(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]));
            CGGuard[i].SetActive(!(Main_Manager.instance.cleared[(stageNum - 1) * 6 + i]));
            //Debug.Log(CheckedReward[(stageNum - 1) * 6 + i]);
            RewardCheck[i].SetActive(CheckedReward[(stageNum - 1) * 6 + i]);
            if (i < 2)
                Endings[i].sprite = Main_Manager.instance.Fail_Image[(stageNum - 1) * 2 + i];
            else
                Endings[i].sprite = Main_Manager.instance.Ending_Image[(stageNum - 1) * 4 + i - 2];

            Endings_Title[i].text = Main_Manager.instance.quest1[(stageNum - 1) * 10 + i + 4];


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
    }
    

}
