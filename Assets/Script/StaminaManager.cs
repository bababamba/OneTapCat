using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager instance;
    void Awake()
    {
        instance = this;
    }
    //public static StaminaManager stamina;
    [SerializeField] TMP_Text time_text;
    [SerializeField] TMP_Text stamina_text;

    int CurStamina = 55;
    static int MaxStamina = 100;

    float CurStaminaTime = 30f;
    static float MaxStaminaTime = 60f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CurStamina < MaxStamina)
        {
            CurStaminaTime -= Time.deltaTime;
            UpdateDisplay();
        }
        if (CurStaminaTime < 0)
        {
            CurStaminaTime = MaxStaminaTime;
            //�ӽ� �ڵ� ���׹̳� ������
            StaminaUp(10);
            UpdateDisplay();
        }
    }
    //���׹̳� ���� �ÿ� ���
    public void StaminaUp(int value)
    {
        CurStamina += value;
        if (CurStamina > MaxStamina)
        {
            CurStamina = MaxStamina;
            CurStaminaTime = MaxStaminaTime;
            UpdateDisplay();
        }
    }
    //���׹̳� ���ҽ�, �����Ͽ��� ���� 0 �̸����� üũ
    public bool StaminaCheck(int value)
    {
        if (CurStamina - value >= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //���׹̳� ���� �� �� �Լ��� �Բ� ���
    public void StaminaDown(int value)
    {   
            CurStamina -= value;
    }
    //���� ���׹̳� ��
    public int GetStamina()
    {
        return CurStamina;
    }
    public void SetStamina(int value)
    {
        CurStamina = value;
        if (CurStamina > MaxStamina)
            CurStamina = MaxStamina;
        UpdateDisplay();
    }

    //���� ���׹̳� ���� �ð�
    public float GetStaminaTime()
    {
        return CurStaminaTime;
    }
    //���� ���׹̳� �����ð� ����
    public void SetStaminaTime(float time)
    {
        CurStaminaTime = time;
    }
    public void UpdateDisplay()
    {
        if (CurStamina == MaxStamina)
            stamina_text.text = "FULL";
        else
            stamina_text.text = CurStamina.ToString();
        time_text.text = ((int)CurStaminaTime / 60).ToString() +  ":" + ((int)CurStaminaTime % 60).ToString() + "��";
    } 

}