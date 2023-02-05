using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    public override void OnFocus()
    {
        Debug.Log("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }

    public override void onLoseFocus()
    {
        Debug.Log("Stopped Looking at " + gameObject.name);
    }
}
