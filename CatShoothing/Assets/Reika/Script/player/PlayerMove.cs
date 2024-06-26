using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 currentPosition = transform.position;

        float newXPosition = currentPosition.x + x * Time.deltaTime * speed;
        newXPosition = Mathf.Clamp(newXPosition,-8.3f,8.5f);

        transform.position = new Vector2(newXPosition, 0.0f);
    }
}
