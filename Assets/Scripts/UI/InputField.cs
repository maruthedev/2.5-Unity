using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public GameObject inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            inputField.SetActive(false);
        }
    }
}
