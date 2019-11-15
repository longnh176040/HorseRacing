using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int speed = 10;
    public bool canMove = false;
    public float getPowerTime = 10;
    public bool boostActive;
    public Text winText;

	
	void Start () {
        
        winText.text = "";
	}
	
	void Update () {
		Controller();
        getPowerTime -= Time.deltaTime;
        if (getPowerTime < 0 && Input.GetButtonDown("Jump"))
        {
            boostActive = true;                               
        }
        StartCoroutine(speedBoost());
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

    IEnumerator speedBoost()
    {
        
        if (boostActive)
        {
            speed = 20;
            yield return new WaitForSeconds(3f);
            boostActive = false;
            getPowerTime = 10;
        }
        else
        {
            speed = 10;
        }

    }

    void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.transform.tag == "Stopper")
        {
            canMove = false;
        }
        else if (otherObject.transform.tag == "AutoHorse")
        {
            speed--;
        }
        Debug.Log("Collision Detected" + otherObject.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            winText.text = "YOU WIN!!";
        }
    }
}
