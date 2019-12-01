using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // configurations
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 0;
    [SerializeField] float yPush = 10;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float randomness = 0.2f;

    // states
    Vector2 paddleAndBallDistance;
    bool ballIsLocked = true;

    //cached component refrences
    AudioSource audioSource;
    Rigidbody2D rigidbody2D;

    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        paddleAndBallDistance = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(ballIsLocked)
        {
            LockBallToPaddle();
            ThrowOnMouseClick();
        }
        
        
    }

    private void ThrowOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballIsLocked = false;
            rigidbody2D.velocity += new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + paddleAndBallDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!ballIsLocked)
        {
            //GetComponent<AudioSource>().clip = audioClips[0];
            //Random.Range(0, audioClips.Length)
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)]);
            rigidbody2D.velocity += new Vector2(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness));
        }
    }
}
