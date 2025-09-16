using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Test : MonoBehaviour
{

    int hp = 100;
    float timer = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        RandamTimer();
    }
    public void TakeDamege(int damege)
    {
        hp -= damege;
        if (hp < 0)
        {
            hp = 0;
        }


    }
    public void RandamTimer()
    {
        
        if(hp>0)timer += Time.deltaTime;
       
        if (hp == 0) Debug.Log("GAMEOVER");

    }
}
