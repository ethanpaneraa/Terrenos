using UnityEngine;

public class Camera : MonoBehaviour
{
    public float smoothing = 0.5f;
    public Transform playerTransform;
    public GameStartScreen GameStartScreen; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameStartScreen.gameStarted) {
            Transform cameraTransform = GetComponent<Transform>();
            var playerX = Mathf.Lerp(cameraTransform.position.x, playerTransform.position.x, smoothing);
            var playerY = Mathf.Lerp(cameraTransform.position.y, playerTransform.position.y, smoothing);
            Vector3 pos = new Vector3(playerX, playerY, cameraTransform.position.z);
            cameraTransform.position = pos;
        }
    }
}
