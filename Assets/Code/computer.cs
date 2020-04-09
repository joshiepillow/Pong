using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : MonoBehaviour
{
    public float speed;
    public string name;
    public float x;
    public float y;
    private GameObject ball;
    //private bool isMove = true;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        Paddle paddle = new Paddle(x, y, gameObject);
        paddle.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Paddle paddle = new Paddle(transform.position.x, transform.position.y, gameObject);
        Vector3 position = ball.transform.position;
        if (Mathf.Abs(transform.position.y - position.y) < 0.5) {
        } else if (position.y > transform.position.y) {
            paddle.Update(1, speed);

        } else if (position.y < transform.position.y) {
            paddle.Update(-1, speed);
        } 
        /*if (isMove && Mathf.Abs(transform.position.y - position.y) < 0.1) {
            isMove = false;
        } else if (!(isMove) && Mathf.Abs(transform.position.y - position.y) > 0.5) {
            isMove = true;
        }*/
    }
}
