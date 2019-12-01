using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleMinPosLim = 1f;
    [SerializeField] float paddleMaxPosLim = 15f;
    [SerializeField] Ball ball;
    bool isTesting = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        if(isTesting)
        {
            Vector2 paddlePos = transform.position;
            paddlePos.x = Mathf.Clamp(ball.transform.position.x, paddleMinPosLim, paddleMaxPosLim);
            transform.position = paddlePos;
        } else
        {
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(mousePosInUnits, paddleMinPosLim, paddleMaxPosLim);
            transform.position = paddlePos;
        }
    }
}
