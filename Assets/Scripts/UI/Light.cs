using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject highLight;
    public GameObject lowLight;
    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.HasItem("Flashlight"))
        {
            this.highLight.SetActive(true);
            this.lowLight.SetActive(false);
        }
    }
}
