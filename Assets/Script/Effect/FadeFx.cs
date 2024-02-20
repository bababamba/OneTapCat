using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeFx : MonoBehaviour
{
    public float time = 4;
    Image image;
    public float startY;
    public float VerticalMove;
    private void Start()
    {
        image = GetComponent<Image>();
        //image.color = new Color(1, 1, 1, 0);
        startY = this.transform.position.y;
        VerticalMove = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0.2f)
        {
            image.color = new Color(1, 1, 1, time / 0.2f);
            this.transform.position = new Vector3(this.transform.position.x, startY +VerticalMove-(VerticalMove * (time/0.2f)), this.transform.position.z);
            time += Time.deltaTime;
        }       

    }

    public void resetAnim()
    {
        this.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        this.transform.position = new Vector3(this.transform.position.x, startY+ VerticalMove, this.transform.position.z);
        time = 0;
    }
}
