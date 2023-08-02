using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAtRun : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    }
}
