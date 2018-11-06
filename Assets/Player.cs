using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public string currentColor;
    public float jumpForce = 10f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;
    public static int score = 0;
    public Text scoreText;
    public GameObject obstacle;
    public GameObject colorChanger;

    // Use this for initialization
    void Start () {
        setRandomColor();
	}

        // Update is called once per frame
    void Update () {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            circle.velocity = Vector2.up * jumpForce;
        }
        scoreText.text = score.ToString();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Scored")
        {
            score++;
            Destroy(collision.gameObject);
            Instantiate(obstacle, new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
            return;
        }

        if(collision.tag == "ColorChanger")
        {
            setRandomColor();
            Destroy(collision.gameObject);
            Instantiate(colorChanger, new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
            return;
        }
        if(collision.tag != currentColor)
        {
            Debug.Log("You died!");
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Debug.Log(collision.tag);
    }

    private void setRandomColor()
    {
        int rand = UnityEngine.Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                currentColor = "Blue";
                sr.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;
            default:
                currentColor = "Blue";
                sr.color = blue;
                break;
        }
    }
}