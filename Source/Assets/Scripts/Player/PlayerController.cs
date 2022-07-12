using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] private float moveSpeed;
    private Animator animator;

    private bool mouseClick;

    private Vector3 mouseStartPoint;
    private Vector3 mouseEndPoint;


    private void Start() 
    {
       animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckMouse();
        CharacterRotate();
    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPoint = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            mouseClick = true;
        }

        if (Input.GetMouseButton(0))
        {
            mouseEndPoint = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        }
        else
        {
            mouseClick = false;
        }
    }

    private void CharacterRotate()
    {
        if(mouseClick)
        {
            Vector3 offset = mouseEndPoint - mouseStartPoint;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
            
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
                animator.SetBool("isRunning", true);
            }

            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        CharacterMove();
    }

    private void CharacterMove()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
}
