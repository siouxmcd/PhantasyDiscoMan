using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBattle : MonoBehaviour {

    public Transform Player;
    public Transform Opponent;
    public Transform oppTarget;
    public Light[] danceLights;
    public Animator animator;
    public Animator dkAnim;
    public AudioSource tracker;
    public PlayerMovement pm;
    public GameManager gm;

    public float battleScore;

    AudioSource audio;


    public AudioClip[] sections;

    private bool isTurn;

    private int lightsCounter;
    private int prevCount;

    private int pointLcount;
    private int pointRcount;
    private int shakeLcount;
    private int shakeRcount;
    private int victoryCount;
    private int splitsCount;

    private int secCounter = 0;

    private float secondsCount;

    // Use this for initialization
    void Start () {
        prevCount = danceLights.Length;
        lightsCounter = 0;
        
        audio = GetComponent<AudioSource>();
        audio.Play();
        StartCoroutine(trackSections());
	}
	
	// Update is called once per frame
	void Update () {
        Player.position = Vector3.Lerp(Player.position, new Vector3(-0.4591381f, 2.035491f, -0.7840782f), Time.deltaTime);
        Opponent.position = Vector3.Lerp(Opponent.position, new Vector3(-0.137f, 2.035491f, -0.419f), Time.deltaTime);
        Opponent.rotation = Quaternion.Lerp(Opponent.rotation, oppTarget.rotation, Time.deltaTime);
        secondsCount += Time.deltaTime;
        if (secondsCount >= 2.01)
        {
            for (int i = 0; i <= danceLights.Length - 1; i++)
            {
                if (i == lightsCounter)
                {
                    danceLights[i].enabled = true;
                }
                else
                {
                    danceLights[i].enabled = false;
                }
                
            }

            if (lightsCounter + 1 >= danceLights.Length)
            {
                lightsCounter = 0;
            }
            else
            {
                lightsCounter++;
            }

            secondsCount = 0;

        }

        switch (secCounter)
        {
            case 0:
                animator.SetBool("isDanceStart", true);
                dkAnim.SetBool("isDanceStart", true);
                break;
            case 1:
                dkAnim.SetBool("Turn1", true);
                break;
            case 2:
                dkAnim.SetBool("Turn1", false);
                isTurn = true;
                break;
            case 3:
                dkAnim.SetBool("Turn2", true);
                isTurn = false;
                pointLcount = 0;
                pointRcount = 0;
                shakeLcount = 0;
                shakeRcount = 0;
                break;
            case 4:
                dkAnim.SetBool("Turn2", false);
                isTurn = true;
                break;
            case 5:
                isTurn = false;
                pointLcount = 0;
                pointRcount = 0;
                shakeLcount = 0;
                shakeRcount = 0;
                battleScore += gm.theThreadz;
                break;
            default:
                break;
        }

        if (isTurn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                pointLcount++;
                battleScore += gm.MoveScore("basicMove", pointLcount);
                animator.SetBool("isPointL", true);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                animator.SetBool("isPointL", false);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                pointRcount++;
                battleScore += gm.MoveScore("basicMove", pointRcount);
                animator.SetBool("isPointR", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("isPointR", false);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                shakeLcount++;
                battleScore += gm.MoveScore("basicMove", shakeLcount);
                animator.SetBool("isShakeL", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("isShakeL", false);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                shakeRcount++;
                battleScore += gm.MoveScore("basicMove", shakeRcount);
                animator.SetBool("isShakeR", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("isShakeR", false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                victoryCount++;
                battleScore += gm.MoveScore("finishMove", victoryCount);
                animator.SetBool("isVictory", true);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                animator.SetBool("isVictory", false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                splitsCount++;
                battleScore += gm.MoveScore("finishMove", splitsCount);
                animator.SetBool("isSplits", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isSplits", false);
            }
        }
        

        if (!audio.isPlaying)
        {
            foreach(Light light in danceLights)
            {
                light.enabled = false;
            }
            pm.enabled = true;

            animator.SetBool("isDanceStart", false);
            dkAnim.SetBool("isDanceStart", false);
            Destroy(this);
        }

    }

    IEnumerator trackSections()
    {
        if (secCounter < sections.Length)
        {
            tracker.clip = sections[secCounter];
            tracker.Play();
            yield return new WaitForSeconds(tracker.clip.length);
        }
        
        if(secCounter < sections.Length)
        {
            secCounter++;
            StartCoroutine(trackSections());
        }
    }

}
