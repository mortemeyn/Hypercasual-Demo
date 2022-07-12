using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Text rankText;
    [SerializeField] Text infoText;
    [SerializeField] GameObject progressBar;

    private GameObject _camera;
    private GameObject player;

    private void Start()
    {
        _camera = FindObjectOfType<FollowCamera>().gameObject;
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Animator>().SetBool("isRunning", false);

            _camera.GetComponent<FollowCamera>().enabled = false;
            _camera.GetComponent<CameraSwitch>().enabled = true;

            rankText.enabled = false;
            infoText.enabled = true;
            progressBar.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Opponent"))
        {
            other.GetComponent<OpponentController>().enabled = false;
            other.GetComponent<Animator>().SetBool("isRunning", false);
            other.GetComponent<OpponentController>().agent.ResetPath();
        }
    }
}
