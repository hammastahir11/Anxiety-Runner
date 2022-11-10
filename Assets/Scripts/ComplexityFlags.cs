using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Here the redar diagram of the game is handled using flags on the radar
public class ComplexityFlags : MonoBehaviour
{
    [SerializeField] GameObject[] flags;
    public static int flag_count=9;

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
        if (flag_count != 9)
        {

            flag_count++;
        }
    
        flags[flag_count].SetActive(true);
    }
}
