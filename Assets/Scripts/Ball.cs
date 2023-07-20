using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.Instance.PlaySoundEffect(0);
        if (collision.gameObject.CompareTag("BlueBrick"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.IncreaseScore(25);
            GameManager.Instance.PlayParticleSystem(collision.transform.position);
        }
        else if (collision.gameObject.CompareTag("GreenBrick"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.IncreaseScore(50);
            GameManager.Instance.PlayParticleSystem(collision.transform.position);
        }
        else if (collision.gameObject.CompareTag("PurpleBrick"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.IncreaseScore(75);
            GameManager.Instance.PlayParticleSystem(collision.transform.position);
        }
        else if (collision.gameObject.CompareTag("Death"))
        {
            GameManager.Instance.DecreaseLive();
        }
    }
}
