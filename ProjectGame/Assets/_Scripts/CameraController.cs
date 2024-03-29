using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variables
    [SerializeField] private float mouseSensitivity;

    //references 
    private Transform parent;

    // Start is called before the first frame update
    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Rotate();
        
    }

    //rotates camera with mouse movement 
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);
    }

    //locks mouse in centre of screen 
    void OnApplicationFocus(bool ApplicationisBack)
    {
        if (ApplicationisBack == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
