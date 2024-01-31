using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main_Manager : MonoBehaviour
{
    public static Main_Manager instance;
    void Awake()
    {
        instance = this;
    }
    [SerializeField] int energy;
    [SerializeField] int energy_time;

    [SerializeField] Image Main_Sprite;
    [SerializeField] Image Right_Sprite;
    [SerializeField] Image Left_Sprite;

    [SerializeField] Sprite[] Main_Image;
    [SerializeField] Sprite[] Right_Image;
    [SerializeField] Sprite[] Left_Image;
    [SerializeField] public Sprite[] Ending_Image;
    [SerializeField] public Sprite[] Fail_Image;

    [SerializeField] TMP_Text UpperMessage;
    [SerializeField] GameObject Endcard;
    [SerializeField] TMP_Text EndMessage;
    [SerializeField] GameObject Failcard;
    [SerializeField] TMP_Text FailMessage;
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject SelectScreen;
    [SerializeField] GameObject[] StageSelect;
    [SerializeField] StaminaManager stamina;

    [SerializeField] GameObject Album;
    [SerializeField] Album_Manager AlManager;
    [SerializeField] GameObject Shop;

    [SerializeField] GameObject HavePopUp;
    [SerializeField] TMP_Text HaveText;
    [SerializeField] TMP_Text HaveCost;
    [SerializeField] GameObject DonHavePopUp;


    public bool[] cleared =  {  
        true, false, true, false, false, false,
        true, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false 
    } ;

    int stage = 0;
    int progress = 0;
    int EndA = 0;
    int EndB = 0;
    int[] cost = { 30, 35, 40, 45, 50, 55, 60 };
    int[] data1 = {
        0,5,1,2,3,4,6,0,
        1,2,5,0,3,4,6,0,
        1,2,0,5,6,0,3,4,
        1,2,5,0,6,0,3,4
    };
    string[] script1 = { 
        "\"�ľƾ�..\" \n�����ؼ� ȥ����. 5�и� �� �ܴٴ� �� 30���̳� �ڹ��ȴٴϡ�", //stage1
        "\"�� �� ���������..\" \n�����ϼ��� �� ����! ���� ������ ��� ���� ���ѹ��ȴ�.",
        "\"������ �ִ� ���� �� ����!!\" \n�ҷ���ǰ�� ��ܸԴٰ� �ҷ� ���̰� �Ǿ���ȴ�. ",
        "\"��.. ����..\" \nģ���� ��Ͱ� ������, �� �ɱ�� �������� �Ϳ��� �β� ���̰� �ƴ�!",
        "\"���� ���� �𿩶�! ���� ���ڳ�!\" \n��ΰ� �����ϴ� �ν� ���̰� �ƴ�! ",
        "\"�𸣴� �� ���ٳ�\" \n���ε� ü���� 1��! ���ϴ� �� ���� ���� 1�� ���̰� �ƴ�!",

        "\"��! ���� �絹���� �ƴ϶󱸿�!\"\n ������ �ʹ� ���� ������ ��¥ ��Ÿ�� ���� ����.",//stage2
        "\"��!\"\n ���� �����ϴ� '�ɳ� ����������'�� ���ǵ� �ƴ�! ���ο� ���� ã�Ҵ�.",
        "\"���̳���TV~ ������!\"\n �Ϳ��� �ܸ�� ����ް� �ִ� �ֵ��� ��Ʃ���� �ƴ�!",
        "\"�ñ��� �� �� ����! ������ ������?\"\n �������̵��� �ñ����� �ؼҽ����� ������ �ƴ�!",
        "\"����� �� �ּ���!\"\n ���� ���� 100����°.. ���� �԰� ���� �Ϳ��� ����� �ƴ�.",
        "\"�ɾ�� �Դϵ���! ����!\"\n �Ϳ�� ��������.. �ʵ��л��鿡�� ����޴� �ɾ�ϰ� �ƴ�!",

        "\"�ľ�.. �׹��帣..(�׸��ض�..)\"\n ���ο��� �ϴ� ���� �ʹ� ���� �¾Ƽ� ������� �ƴ١�",//stage3
        "\"���.. ��θ��� �ľ�..\"\n ������ ���� �Ծ����� �������� ����� �����.",
        "\"���� ���� �ְ�! ������ �� ����..\"\n ���� ���� ������ ���ø����� ���� ��հŸ��� �ִ�.",
        "\"�ϰ��ÿ� �Ͼ��@#$%\" 1�� 1�ʰ� �Ʊ�� ��ȹ���� ����! �ܿ���е� ������ ���´�.",
        "\"�帣�� Ǫ��\"\n ������ �Ḹ �ڴ� ��ٷ��� ���̰� �ƴ�! �� ������ ���� �ܿ� ������ ������...",
        "\"���� ���� ���ڳ�!\"\n �Ϸ� ���� ���� �������� �� ����! ��� �� ���� ���̰� �ƴ�.  ",

        "\"����.. �¾�?\"\n ��¥ ������ �޾Ҵ�. ��⸦ ���� ���� ����� �Ҿ��١�",//stage4
        "\"��..��..\"\n �������� ���� ���� ��������. ü���� �� ������ ���̴� �ᱹ ���߸� ���� ���ߴ�.",
        "\"���� �� ������ �� ���� �Ŵٳ�!\"\n Ÿ�� �ܸ�� �� �Ƿ����� ����޴� �����̰� �ƴ�!",
        "\"���̴� ������ ���� �ž�~\"\n ���ϴ� �� ���� ���̵��� ���̵� �������� �ƴ�!",
        "\"�򸣴� ����! ����ĵ�~\"\n �������� �ŷ��� ���ɽ��� �س��̰� �ƴ�!",
        "\"��� ������� ����ϰھ�~\"\n �۰ ��Ҹ��� ���� �Ƿ��� ���� �ɳɹ������� �ƴ�!",

        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };
    public string[] quest1 = { 
        "��ħ�̴�.. �ʹ� �ǰ��ѵ� �����?",//stage1
        "�б� ���� �� ���汸���� �� ����?",
        "���� ���� �ð��̴�! ���� �� �ұ�?",
        "ü�� �ð��� � ��� �ұ�?",
        "������ ����","�ǿ� �ɸ� ����",
        "������ �ɾ�ġ","�ҽ��� �β� ����","�α� ��Ÿ �ν� ����","���� 1�� ��� ����",
        "��Ʃ���� ����! � ������ �ø���?",
        "ũ���������� � ������ �ұ�?",
        "�����ڸ� �ø��� ���ؼ� ����?",
        "���� ������ ��� �ұ�?",
        "�絹���� �� �����","��۱� ���ǵ�",
        "�Ϳ��� Ű�� ��Ʃ��","�����ϴ� ����","�Թ� ��Ʃ�� ���","���ڰ� ���� �ɾ��",
        "�ܿ� ���� ����! ���п� ������ �ұ�?",//stage3
        "ģ������ ���ڰ� �Ѵ�. �� �ϰ� ����?",
        "�ܿ￡�� �̰���! ���� �����ϴ� ������?",
        "12�� 31���̴�! ������ ��� ������?",
        "������� �� ����","���� �� �ų���",
        "������ ����","1�ʵ� �Ʊ�� ����","�ܿ��� �ڴ� ����","��� �� ���� ����",
        "�� ���� ���̵�! � ����� �ؾ� �ұ�?",//stage4
        "���� �ȴ� ������ �޾Ҵ�. ��� �ұ�?",
        "�������� �ƴ�. ü�� ������ �����?",
        "���̵��� �� ���� � ���뿡 ���� �ɱ�?",
        "��� ���� ����","���� ���� ����",
        "���̺��� ������","������ž ������","���ɽ��� �س���","������ �ɳɹ�����",
        "���� ������ �� �԰� ����?",//stage5
        "������ ������ ���� ����?",
        "���� �̱� ����! ���� ����� ������?",
        "�� ���� ����! � ���� ����?",
         "�������� ����","��¡�� ���� ����",
        "�����ְ� �˼� ����","�谡 ������ ����","���� ���� �ַ� ����","����� ���� ����",
        "",
        "",
        "",
        "",
        "","",
        "","","",""
       };
    public string[] extraQuest = {
        "�����ϴ� Ÿ�ھ߳��� ���. ��� �ұ�?",//for stage5
        "�Ҳɳ��̰� ���۵ƴ�. ���� ������?"



    };


    // Start is called before the first frame update
    void Start()
    {
        stage = 1;progress = 0;// �ӽ�

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScreen(int progressNumber) {
        //Debug.Log(progress);
        UpperMessage.text = quest1[(stage - 1) * 10+progress];
        Main_Sprite.sprite = Main_Image[(stage - 1) * 4 + progressNumber];
        Right_Sprite.sprite = Right_Image[(stage - 1) * 4 + progressNumber];
        Left_Sprite.sprite = Left_Image[(stage - 1) * 4 + progressNumber];
    }
    public void FailScreen(int endNumber)
    {
        Main_Sprite.sprite = Fail_Image[(stage - 1) * 2 + endNumber-1];
        cleared[(stage - 1) * 6 + endNumber-1] = true;
        Failcard.SetActive(true);
        UpperMessage.text = quest1[(stage - 1) * 10 + 3 + endNumber];
        FailMessage.text = script1[(stage - 1) * 6 +endNumber - 1];

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
        EndMessage.text = script1[(stage-1)*6 + endNumber + 1];
        UpperMessage.text = quest1[(stage - 1) * 10 +5 + endNumber];
        Endcard.SetActive(true);
        cleared[(stage - 1) * 6 + endNumber+1] = true;

    }
    public void Retry()
    {
        progress = 0;
        Failcard.SetActive(false);
        UpdateScreen(progress);
    }
    public void ButtonLeft()
    {
        //Debug.Log((stage - 1) * 8 + (progress * 2) + " " + data1[(stage - 1) * 8 + (progress * 2)]);
        
        if (data1[(stage - 1) * 8 + (progress * 2)] == 5)
        {
            FailScreen(1);
        }
        else if (data1[(stage-1)*8+(progress * 2)] == 6)
        {
            FailScreen(2);
        }
        else if (data1[(stage-1)*8+(progress * 2)] == 1)
        {
            EndA = 1;
            progress++;
            if (progress == 4)
                EndingScreen(Ending());
            else
                UpdateScreen(progress);
        }
        else if (data1[(stage-1)*8+(progress * 2)] == 3)
        {
            EndB = 1;
            progress++;
            if (progress == 4)
                EndingScreen(Ending());
            else
                UpdateScreen(progress);
        }
        else if (data1[(stage-1)*8+(progress * 2)] == 0)
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
        //Debug.Log( +" "+data1[(stage - 1) * 8 + (progress * 2)] + 1);
        if (progress == 4)
            EndingScreen(Ending());
        else
        {
            if (data1[(stage-1)*8+(progress * 2 + 1)] == 5)
            {
                FailScreen(1);
            }
            else if (data1[(stage-1)*8+(progress * 2 + 1)] == 6)
            {
                FailScreen(2);
            }
            else if (data1[(stage-1)*8+(progress * 2 + 1)] == 2)
            {
                EndA = 2;
                progress++;
                if (progress == 4)
                    EndingScreen(Ending());
                else
                    UpdateScreen(progress);
            }
            else if (data1[(stage-1)*8+(progress * 2 + 1)] == 4)
            {
                EndB = 2;
                progress++;
                if (progress == 4)
                    EndingScreen(Ending());
                else
                    UpdateScreen(progress);
            }
            else if (data1[(stage-1)*8+(progress * 2 + 1)] == 0)
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
        Shop.SetActive(false);
        Album.SetActive(false);
        HavePopUp.SetActive(false);
        DonHavePopUp.SetActive(false);
    }
    public void OpenMainGame()
    {
        CloseAll();
        MainGame.SetActive(true);
    }
    public void OpenStageSelect(int select)
    {
        bool check = false;
        check = StaminaManager.instance.StaminaCheck(cost[select-1]);
        if (check)
        {
            stage = select;
            HavePopUpOn();
        }
        else
            DonHavePopUpOn();


    }
    public void StartGame()
    {
        StaminaManager.instance.StaminaDown(cost[stage - 1]);
        CloseAll();
        MainGame.SetActive(true);
        UpdateScreen(0);
    }
    public void OpenStagesSelectScreen()
    {
        CloseAll();
        progress = 0;
        UpdateScreen(0);
        SelectScreen.SetActive(true);
    }
    public void OpenShop()
    {
        CloseAll();

        Shop.SetActive(true);
    }
    public void OpenAlbum()
    {
        CloseAll();
        Album.SetActive(true);
        AlManager.ChangeStage(1);
    }
    public void HavePopUpOn()
    {
        HavePopUp.SetActive(true);
        switch (stage)
        {
            case 1:
                HaveText.text = "�б� ���� ��"; break;
            case 2:
                HaveText.text = "��Ʃ�� Ű���"; break;
            case 3:
                HaveText.text = "�ܿ� ���� ������"; break;
            case 4:
                HaveText.text = "���̵��� Ű���"; break;
        }
        HaveCost.text = "X " + cost[stage - 1].ToString();
        
        
       
    }
    public void DonHavePopUpOn()
    {
        DonHavePopUp.SetActive(true);
    }



}
