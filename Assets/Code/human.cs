using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    public float speed;
    public string name;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        Paddle paddle = new Paddle(x, y, gameObject);
        paddle.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Paddle paddle = new Paddle(transform.position.x, transform.position.y, gameObject);
        float h = Input.GetAxisRaw("Vertical");
        paddle.Update(h, speed);
    }
}
