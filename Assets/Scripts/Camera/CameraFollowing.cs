using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private float smoothTime = 0.2f;
    private Vector2 velocity;
    public Player player;
    private float posX;
    private float posY;
    private float maxX;
    private float minX;
    private float maxY;
    private float minY;

    // Start is called before the first frame update
    void Start()
    {
        maxX = 212f;
        minX = -5f;
        maxY = 2f;
        minY = -2f;
    }

    // Update is called once per frame 
    void Update()
    {
        posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothTime);
        posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);

        posX = Mathf.Clamp(posX, minX, maxX);
        posY = Mathf.Clamp(posY, minY, maxY);

        this.transform.position = new Vector3(posX, posY, this.transform.position.z);
    }

    public void setMinY(float m)
    {
        minY = m;
    }
}
