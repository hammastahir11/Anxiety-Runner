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
    int mapNumber;
    [SerializeField] int timer = 10;
   // [SerializeField]Animator transition;

    void Start()
    {
         time = DateTime.Now.TimeOfDay;
         mapNumber=1;

         StartCoroutine(ChangeBackground());
    }

    // Update is called once per frame
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.deltaTime, image.uvRect.size);
       
    }

    IEnumerator ChangeBackground() {
        while (true) {
            yield return new WaitForSeconds(timer);
            image.texture = maps[mapNumber++ % maps.Length];
        }
    }

}
