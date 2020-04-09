using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private float speedHold;
    public Vector2 direct;
    private GameObject lose; 
    private GameObject win; 
    private SpriteRenderer computerCountObj; 
    private SpriteRenderer humanCountObj;
    private int humanCount;
    private int computerCount;
    public Sprite[] nums;

    // Start is called before the first frame update
    void Start()
    {

        speedHold = speed;

        win = GameObject.Find("text").transform.Find("win").gameObject;
        lose = GameObject.Find("text").transform.Find("lose").gameObject;
        computerCountObj = GameObject.Find("computerCount").GetComponent<SpriteRenderer>();
        humanCountObj = GameObject.Find("humanCount").GetComponent<SpriteRenderer>();

        gameObject.transform.position = new Vector3(0, 0, 0);
        float randAngle = Random.Range(-Mathf.PI/6, Mathf.PI/6); //22.5 to -22.5 degrees
        int randX = Random.Range(0, 2)*2-1; //returns 1 or -1
        direct.x = Mathf.Cos(randAngle)*randX;
        direct.y = Mathf.Sin(randAngle);
    
        win.SetActive(false);
        lose.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Worked");
        if (other.gameObject.tag == "Wall") {
            direct.y = direct.y * -1;
        } else if (other.gameObject.tag == "Paddle") {
            Vector3 raw = gameObject.transform.position-other.gameObject.transform.position;
            raw.x *= 2;
            float factor = (Mathf.Sqrt(Mathf.Pow(raw.x, 2) + Mathf.Pow(raw.y, 2)));
            direct.x = raw.x / factor;
            direct.y = raw.y / factor;
            //Debug.Log(raw.ToString());
            //Debug.Log(factor);
            //Debug.Log(direct.x + " " + direct.y);
            speedHold *= 1.1f;
        } else if (other.gameObject.tag == "win") {
            humanCount++;
            Debug.Log(humanCount);
            humanCountObj.sprite = nums[humanCount];
            if (humanCount == 5) {
                win.SetActive(true); 
            } else {
                Start();
            }
        } else if (other.gameObject.tag == "lose") {
            computerCount++;
            Debug.Log(computerCount);
            computerCountObj.sprite = nums[computerCount];
            if (computerCount == 5) {
                lose.SetActive(true); 
            } else {
                Start();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float tempSpeed = speedHold * Time.deltaTime;
        gameObject.transform.position = new Vector2 (transform.position.x + direct.x * tempSpeed, transform.position.y + direct.y * tempSpeed);
    }
}
