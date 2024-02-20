using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fx_Manager : MonoBehaviour
{
    public static Fx_Manager instance;


    public ItemGetFx prefabItem;
    public Transform target;
    public Transform start;
    private void Awake()
    {
            instance = this;
    }
    private void Start()
    {
        //GetItemFx(10);
    }
    public void GetItemFx(int randCount)
    {
        
        for (int i = 0; i < randCount; ++i)
        {
            var itemFx = GameObject.Instantiate<ItemGetFx>(prefabItem, this.transform);
            itemFx.transform.SetParent(this.transform);
            itemFx.Explosion(start.position, target.position, 500.0f);
            
        }
    }
}
