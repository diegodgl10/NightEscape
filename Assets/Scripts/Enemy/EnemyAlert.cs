using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    public AudioClip audioClipEnemy;
    public AudioSource audioSourceEnemy;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceEnemy = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.audioSourceEnemy.PlayOneShot(this.audioClipEnemy);
        }
    }
}
