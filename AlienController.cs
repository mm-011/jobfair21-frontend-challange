using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;
using Platformer.Core;
using Platformer.Model;
using static Platformer.Core.Simulation;

public class AlienController : MonoBehaviour
{
    public TMP_Text text;
    public AudioSource explosion;
    public Animator dialogueAnimator;
    public GameObject player;
    public GameObject alien;
    public float distanceForTriggering;


    // Start is called before the first frame update
    void Start()
    {
        alien = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueAnimator.GetBool("StartDialogue")==false && Vector2.Distance(player.transform.position, alien.transform.position) <= distanceForTriggering)
        {
            dialogueAnimator.SetBool("StartDialogue", true);             
        }
    }
    
    public void PlayExplosionSound()
    {
        explosion.enabled = true;
        player.GetComponent<PlayerController>().Bounce(7);
        player.GetComponent<Health>().Decrement();
    }

    public void ShowText()
    {
        text.enabled = true;
    }
}
