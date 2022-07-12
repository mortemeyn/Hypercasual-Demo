using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float turnSpeed = 25f;

    public enum turnLeftOrRight 
	{
		Left, Right
	}
    [SerializeField] private turnLeftOrRight leftOrRight;
    
    private Vector3 turnRotating;

    void Start()
    {
        switch(leftOrRight){
            case turnLeftOrRight.Left:
                turnRotating = Vector3.down;
                break;
            case turnLeftOrRight.Right:
                turnRotating = Vector3.up;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnRotating, turnSpeed * Time.deltaTime);
    }
}
