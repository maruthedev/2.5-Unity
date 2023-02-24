using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGate : MonoBehaviour
{
    public new CameraFollowing camera;
    private bool enter;
    // Start is called before the first frame update
    void Start()
    {
        enter = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        camera.setMinY(-10f);
        enter = true;
    }

    public bool getEnter(){
        return enter;
    }
}
