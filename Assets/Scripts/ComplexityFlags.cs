using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Here the redar diagram of the game is handled using flags on the radar
public class ComplexityFlags : MonoBehaviour
{
    [SerializeField] GameObject[] flags;
    public int flag_count=9;
    public static ComplexityFlags Instance;
    private void Awake() {
        Instance=this;
    }
    public void RemoveFlag()
    {
        flags[flag_count].SetActive(false);
        if (flag_count != 0)
        {

            flag_count--;
        }
    }

    public void AddFlag()
    {
        // if (flag_count == 0)
        // {
        //     flags[flag_count].SetActive(true);
        // }
        flags[flag_count].SetActive(true);
        if (flag_count != 9)
        {
           // Debug.Log("Flag NO : "+flag_count);
            flag_count++;
            
        }

    }
}
