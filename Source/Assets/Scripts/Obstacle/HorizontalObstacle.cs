using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    private Vector3 minXPos;
    private Vector3 maxXPos;
    
    [Header("Obstacle Settings")]
    [SerializeField] float minX;
    [SerializeField] float maxX;    
    [SerializeField] float obstacleSpeed = 2f;

    
    void Start()
    {
        minXPos = new Vector3(minX, transform.localPosition.y, transform.localPosition.z);
        maxXPos = new Vector3(maxX, transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(minXPos, maxXPos, (Mathf.Sin(obstacleSpeed * Time.time) + 1.0f) / 2.0f);
    }
}
