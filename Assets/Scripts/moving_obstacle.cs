using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_obstacle : MonoBehaviour {

    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;

    private void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        pos1 = new Vector3(-4+x, y, 0);
        pos2 = new Vector3(4+x, y, 0);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
