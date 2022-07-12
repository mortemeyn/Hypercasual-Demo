using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] float turnSpeed = 10f;

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
                turnRotating = Vector3.forward;
                break;
            case turnLeftOrRight.Right:
                turnRotating = Vector3.back;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnRotating, turnSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
