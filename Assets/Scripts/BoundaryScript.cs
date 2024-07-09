using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        // Sets boundary of object to screen size.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewPos;
    }

}