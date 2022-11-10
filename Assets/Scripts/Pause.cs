using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenuScreen;
    
    public GameObject obj;
    public Animator animator;
    public PlayerMovement pm;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        obj=GameObject.FindGameObjectWithTag("Player");   
        animator=obj.GetComponent<Animator>();
        pm=obj.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void PauseGame(){
        Time.timeScale=0;
        pauseMenuScreen.SetActive(true); 
        animator.enabled= false;
        pm.enabled=false;  
    }

    public void ResumeGame(){
        Time.timeScale=1;
        pauseMenuScreen.SetActive(false);
        animator.enabled= true;
        pm.enabled=true; 

    }

    public void goToMenu(){

    }
}
