using UnityEngine;
using UnityEngine.UI;
public class CollisionDetector : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameManager gameManager;
    public GameObject lastPlatform;
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(collision.gameObject != lastPlatform)
            {
                lastPlatform = collision.gameObject;
                gameManager.IncrementPlatformCount();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMovement.OnGroundCollisionExit();
        }
    }
}
