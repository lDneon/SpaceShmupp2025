using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S { get; private set; } //slingshot

    //this control the movement of the ship
    [Header("Inscribed")]
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Dynamic")]
    [Range(0, 4)]
    public float shieldLevel = 1;

    private void Awake()
    {
        if(S == null)
        {
            S = this; //set the slingeton
        }
        else
        {
            Debug.LogError("Hero.Awake() -Attempted to assign second Hero.S!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //change transform position based on axes
        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;
        //this ensures that each movement is similiar to any other easing function
        transform.rotation = Quaternion.Euler(vAxis * pitchMult, hAxis * rollMult, 0);
    }
    
}
