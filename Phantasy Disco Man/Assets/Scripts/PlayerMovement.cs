using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 1f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 1f;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isBack", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isBack", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isLeft", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isForward", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isForward", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRight", false);
        }

    }

}
