using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class Paddle
{
    float x;
    float y;
    GameObject paddle;

    public Paddle(float x, float y, GameObject paddle) {
        this.x = x;
        this.y = y;
        this.paddle = paddle;
    }
    public void Start() {
        //BoxCollider2D boxCollider = paddle.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        //Debug.Log("This works! --" + paddle.name);
        paddle.transform.position = new Vector3(x, y, 0);
        //Debug.Log("Wow!");

    }
    public void Update(float h, float speed)
    {
        speed = speed * Time.deltaTime;
        float y = paddle.transform.position.y + h * speed;
        paddle.transform.position = new Vector2 (paddle.transform.position.x, Mathf.Min(Mathf.Max(y, -3.9f), 3.9f));
    }
}
