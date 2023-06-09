using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Animation
    private Animator _animator;

    private bool _hashAnimator;

    private int _xVelHash;

    private int _yVelHash;

    private int _crouchHash;

    private void Awake()
    {

        _hashAnimator = TryGetComponent<Animator>(out _animator);
        _xVelHash = Animator.StringToHash("X_Velocity");
        _yVelHash = Animator.StringToHash("Y_Velocity");
        _crouchHash = Animator.StringToHash("Crouch");

    }

    // Update is called once per frame
    void Update()
    {
        float y = FirstPersonController.instance.currentInput.y;
        float x = FirstPersonController.instance.currentInput.x;
        bool c = FirstPersonController.instance.IsCrouching;

        _animator.SetFloat(_xVelHash, y);
        _animator.SetFloat(_yVelHash, x);
        _animator.SetBool(_crouchHash, c);
    }
}
