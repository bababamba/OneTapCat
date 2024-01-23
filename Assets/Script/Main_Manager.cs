using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] GameObject Endcard;
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject StageSelect;


    int stage = 0;
    int progress = 0;
    int EndA = 0;
    int EndB = 0;
    int[] data = {0,5,1,2,3,4,6,0};

    // Start is called before the first frame update
    void Start()
    {
        stage = 1;progress = 0;// юс╫ц
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScreen(int progressNumber) {
        Debug.Log(progress);
        Main_Sprite.sprite = Main_Image[(stage - 1) * 4 + progressNumber];
        Right_Sprite.sprite = Right_Image[(stage - 1) * 4 + progressNumber];
        Left_Sprite.sprite = Left_Image[(stage - 1) * 4 + progressNumber];
    }
    public void FailScreen(int endNumber)
    {
        Main_Sprite.sprite = Fail_Image[(stage - 1) * 2 + endNumber-1];
        Endcard.SetActive(true);

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
        Endcard.SetActive(true);

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
        StageSelect.SetActive(false);
        MainGame.SetActive(false);
    }
    public void OpenMainGame()
    {
        CloseAll();
        MainGame.SetActive(true);
    }
    public void OpenStageSelect()
    {
        CloseAll();
        StageSelect.SetActive(true);
    }



}
