using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int speed;
    public int powerAccumulation;
    public bool canMove = false;
    //public Transform forwardMatch;
    public float timeLeft = 3;
	
	void Start () {
        
	}
	
	void Update () {
		Controller();
        Power();
        
           // this.gameObject.transform.Translate(forwardMatch.forward * speed);
        
         
    }

    void Controller()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            transform.position += movement * speed;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            canMove = !canMove;
        }
    }

    void Power()
    {
        int powerCountdown = 3;
        for (powerAccumulation = 10; powerAccumulation>=0; powerAccumulation--)
        {
            if (powerAccumulation == 0 && Input.GetButtonDown("Jump"))
            {   
                if (powerCountdown > 0 && timeLeft > 0)
                {
                    speed = speed * 2;
                    powerCountdown--;
                   
                }
     
            }
        }
        //powerAccumulation = 10;
        //speed = 10;
    }

    void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.transform.tag == "Stopper")
        {
            canMove = false;
        }
        Debug.Log("Collision Detected" + otherObject.gameObject.name);
    }
}
