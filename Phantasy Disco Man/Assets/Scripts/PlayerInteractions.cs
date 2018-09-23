using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    public DanceBattle db;
    public PlayerMovement pm;
    public GameManager gm;
    public UIManager2 ui;

    // Use this for initialization
    void Start () {
        pm = GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            if (other.transform.GetChild(0).gameObject.activeSelf)
            {
                other.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                other.transform.GetChild(0).gameObject.SetActive(true);
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "danceFloor")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("dancestart");
                db.enabled = true;
                pm.enabled = false;
            }
        }

        if (other.tag == "bar")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ui.barCanvas.enabled = true;
            }
        }

        if (other.tag == "machine")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gm.Laundry();
            }
        }
    }

}
