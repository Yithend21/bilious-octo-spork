using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    const int orthographicSizeMin = 5;
    const int orthographicSizeMax = 10;

    private int ifZoom;
    private float velocity;

    // Use this for initialization
    void Start()
    {
        ifZoom = 0;
        velocity = 3f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        ScreenScroll();
    }

    void Update()
    {
        CameraZoom();
    }

    void ScreenScroll()
    {
        float move_x, move_y;
        move_x = Input.GetAxis("Horizontal");
        move_y = Input.GetAxis("Vertical");
        if (Input.mousePosition.x < Screen.width * 0.02f) move_x = -1f;
        else if (Input.mousePosition.x > Screen.width * 0.98f) move_x = 1f;

        if (Input.mousePosition.y < Screen.height * 0.02f) move_y = -1f;
        else if (Input.mousePosition.y > Screen.height * 0.98f) move_y = 1f;

        Vector2 move = new Vector2(move_x, move_y);
        GetComponent<Rigidbody2D>().velocity = move * velocity;
    }

    void CameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {//forward 
            Camera.main.orthographicSize--;
            if (Camera.main.orthographicSize > orthographicSizeMax)
                ifZoom--;
            else ifZoom = 0;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {//forward 

            if (Camera.main.orthographicSize >= orthographicSizeMax)
                ifZoom++;
            else
            {
                Camera.main.orthographicSize++;
                ifZoom = 0;
            }
        }
        if (ifZoom >= 5)
        {
            ifZoom = Mathf.Min(ifZoom, 10);
            if (Camera.main.orthographicSize <= 50)
                Camera.main.orthographicSize++;
            velocity = 30f;
        }
        else
        {
            if (Camera.main.orthographicSize > orthographicSizeMax)
            {
                Camera.main.orthographicSize--;
                ifZoom = 0;
            }
            else
            {
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);
                //velocity = Camera.main.orthographicSize * 2f;
            }
            velocity = Camera.main.orthographicSize * 1.5f;
        }
    }
}
