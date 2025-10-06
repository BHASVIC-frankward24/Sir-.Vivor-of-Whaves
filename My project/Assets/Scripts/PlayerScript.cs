using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class Playerscript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
        
    
    // Update is called once per frame
    public void Update(){
        float horizontal = 0f;
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }
            Debug.Log(horizontal);
    }

}

