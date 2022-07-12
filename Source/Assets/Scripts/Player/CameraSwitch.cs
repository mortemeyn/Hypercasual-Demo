using System.Collections;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    private WallPaint wallPaint;

    private void OnEnable()
    {
        wallPaint = FindObjectOfType<WallPaint>();
        StartCoroutine(WaitForThePainting());
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * rotationSpeed);
    }
        
    IEnumerator WaitForThePainting()
    {
        yield return new WaitForSeconds(2f);
        wallPaint.enabled = true;
        Destroy(this);
    }
}
