using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Here is a simple timer to change the map of the game during playing mood
public class repeatebackground : MonoBehaviour
{
    [SerializeField] int timer = 1;
    [SerializeField] List<GameObject> maps;
    TimeSpan time;
    int mapnumber = 0;
   



    [SerializeField]Animator transition;
    private void Start()
    {
        time = DateTime.Now.TimeOfDay;
        
    }

    private void Update()
    {
     
        
        if ((DateTime.Now.TimeOfDay.Minutes)>(time.Minutes+timer))
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
        

        transition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.4f);
        maps[(mapnumber+1) % 4].SetActive(true);
        maps[mapnumber % 4].SetActive(false);
        mapnumber++;
        transition.SetTrigger("FadeOut");
        
       
    }


}
