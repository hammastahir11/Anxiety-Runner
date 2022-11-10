using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 farword = new Vector3(0.01f, 0, 0);
    [SerializeField] Transform playertranform;
    private void Update()
    {
        playertranform.position += farword;
    }
}
