using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour {

    public float speed;
    public float getPowerTime = 15;
    public bool boostActive;
    public bool rotateActive;
    public Transform[] targets;
    int nextTar;
    public Vector3 point;
    int y = 0;


	void Start () {
        transform.position = targets[0].position;
        speed = 13;
    }
	
	void Update () {
        Movement();
        getPowerTime -= Time.deltaTime;
        if (getPowerTime < 0)
        {
            boostActive = true;
        }
        if (rotateActive)
        {
            RotateModel();
        }
        StartCoroutine(speedBoost());
        
        
    }
    void Movement()
    {
        float distance = Vector3.Distance(transform.position, targets[nextTar].position);
        if (distance > 0)
        {
            float step = speed;
            transform.position = Vector3.MoveTowards(transform.position, targets[nextTar].position, step);
            rotateActive = false;
        }
        else
        {
            nextTar++;
            rotateActive = true;
        }
    }


    void RotateModel()
    {
           
         Debug.Log("run" + y);
         y++;
        
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
}
