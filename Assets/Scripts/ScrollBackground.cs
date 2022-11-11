using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScrollBackground : MonoBehaviour
{

    [SerializeField] private float x, y;

    public RawImage image;
    public Texture[] maps= new Texture[4];
    TimeSpan time;
    int mapNumber=0;
    [SerializeField] int timer = 10;
   // [SerializeField]Animator transition;

    void Start()
    {
        time = DateTime.Now.TimeOfDay;
    }

    // Update is called once per frame
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.deltaTime, image.uvRect.size);
        if ((DateTime.Now.TimeOfDay.Seconds)>(time.Seconds+timer))
        {
            ChangeMap();
        }
    }

    public void ChangeMap()
    {  
        time = DateTime.Now.TimeOfDay;
            StartCoroutine(myfun());
        
    }

    IEnumerator myfun()
    {
        

       // transition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.4f);
        image.texture=maps[(mapNumber)];
        if(mapNumber>=3){
            mapNumber=0;
        }
        Debug.Log(mapNumber);
        mapNumber++;
        
  
       // transition.SetTrigger("FadeOut");
        
       
    }
}
