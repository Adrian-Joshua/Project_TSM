using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private bool isOpen = false;
    private bool canBeInteractedWith = true;
    private Animator doorAnimator;


    private void Start()
    {
        doorAnimator = GetComponent<Animator>();

       
    }

    public override void OnFocus()
    {
       
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            isOpen = !isOpen;


            //Forward direction of Door
            Vector3 doorTransformDirection = transform.TransformDirection(Vector3.forward);
            
            //Direction of player
            Vector3 playerTransformDirection = FirstPersonController.instance.transform.position - transform.position;
           
            //Dot product of their vectors. Negative value = Player Behind door ; Positive value = Player Infront door
            float dot = Vector3.Dot(doorTransformDirection, playerTransformDirection);

            //Vector3 dirToTarget = Vector3.Normalize(transform.position - FirstPersonController.instance.transform.position);
            //float dot = Vector3.Dot((transform.TransformDirection(Vector3.forward)), dirToTarget);
            Debug.Log(dot);

            doorAnimator.SetFloat("dot", dot);
            doorAnimator.SetBool("isOpen", isOpen);
        }
    }

    public override void onLoseFocus()
    {
       
    }
}
