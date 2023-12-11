using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    public AudioClip audioClipAlert;
    public AudioSource audioSourceAlert;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceAlert = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.audioSourceAlert.PlayOneShot(this.audioClipAlert);
        }
    }
}
