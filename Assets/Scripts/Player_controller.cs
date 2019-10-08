using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    public float move_speed = 10.0f;

    public float score;
    public float scoreAmount;
    public Text scoreTxt;
    Vector2 input;
    public float scaleAmount = 2.0f;
    private bool scaled = false;
    public float scaledTimer = 5.0f;
    private float scaledTimerInit;
    private float InitScalefactor;
    // Start is called before the first frame update
    void Start()
    {
        scaledTimerInit = scaledTimer;
        InitScalefactor = transform.localScale.x;
    }


    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            if (score > 1)
            {
                LoseScore(1);
                scaled = true;
                scaledTimer = scaledTimerInit;
                transform.localScale += new Vector3(scaleAmount, 0, 0);
            }
        }

        if(scaled)
        {
            if (scaledTimer > 0.0f)
            {
                scaledTimer -= Time.deltaTime;
                
            }
            else
            {
                
                
                if (transform.localScale.x > InitScalefactor)
                    transform.localScale -= new Vector3(scaleAmount / 100, 0, 0);
                else
                    scaled = false;

                //transform.localScale = new Vector3(InitScalefactor, transform.localScale.y, transform.localScale.z);
            }
        }

        if(score <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        transform.position += new Vector3(input.x * Time.deltaTime * move_speed, input.y * Time.deltaTime * move_speed, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Score();
            Destroy(other.gameObject);
        }

    }

    public void Score()
    {
        score += scoreAmount;
        scoreTxt.text = "Score: " + score;
    }

    public void LoseScore(float amount)
    {
        score -= amount;
        scoreTxt.text = "Score: " + score;
    }
}
