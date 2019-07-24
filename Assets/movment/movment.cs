using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController characterController;
    private Animator animator;
    private bool attack = false;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        var horizantal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");


        var movment = this.transform.forward * vertical;

        characterController.SimpleMove(movment*3);

        this.transform.Rotate(new Vector3(0,horizantal*4,0));

        animator.SetFloat("speed",vertical);

        if (Input.GetKeyDown(KeyCode.E) && !attack)
        {
            attack = true;
            Invoke("attacked", 1f);
            animator.SetTrigger("attack");
        } 
    }
    private void attacked()
    {
        attack = false;
    }
}
