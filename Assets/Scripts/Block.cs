using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //[SerializeField] Sprite broken1;
    //[SerializeField] Sprite broken2;
    //int hitNumber = 0;
    [SerializeField] AudioClip breakAudio;
    [SerializeField] GameObject myPrefab;
    [SerializeField] Sprite[] sprites;
    [SerializeField] int maxHit;

    // cached refrences
    Level level;
    GameSession gameStatus;

    // State variables
    int timeHit = 0;

    private void Start()
    {
        if(CompareTag("Breakable"))
        {
            level = FindObjectOfType<Level>();
            gameStatus = FindObjectOfType<GameSession>();
            level.RegisterBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Breakable"))
        {
            timeHit++;
            if(timeHit >= maxHit)
            {
                level.RemoveBlock();
                gameStatus.AddScore();
                AudioSource.PlayClipAtPoint(breakAudio, Camera.main.transform.position);
                Destroy(gameObject);
                GameObject newParticleVFX = Instantiate(myPrefab, transform.position, Quaternion.identity);
                Destroy(newParticleVFX, 1);
            } else
            {
                GetComponent<SpriteRenderer>().sprite = sprites[timeHit - 1];
            }
        }
        /*hitNumber += 1;
        //Debug.Log(GetComponent<SpriteRenderer>().color = Color.gray);
        //gameObject.SetActive(false);
        if (hitNumber > 2)
        {
            Destroy(gameObject);
        } else
        {
            if(hitNumber == 1)
            {
                GetComponent<SpriteRenderer>().sprite = broken1;
            } else if (hitNumber == 2)
            {
                GetComponent<SpriteRenderer>().sprite = broken2;
            }
        }*/
    }
}
