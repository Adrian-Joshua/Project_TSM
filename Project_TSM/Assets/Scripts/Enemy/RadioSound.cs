using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RadioSound : MonoBehaviour
{

    private AudioSource radioSound;
    [SerializeField] private AudioSource[] radioSoundArray;
    private bool isRadioOn;
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        setRadioSound();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    
    void setRadioSound()
    {
        Debug.Log("Setting Radio Sound");
        radioSound = radioSoundArray[Random.Range(0, radioSoundArray.Length)];
        Debug.Log(radioSound);
        setTimer();
    }

    void setTimer()
    {
        Debug.Log("Picking timer");
        timer = Random.Range(minTime, maxTime);
        Debug.Log("Timer Picked");
        StartCoroutine(PlayRadioSound(timer));
    }

    IEnumerator PlayRadioSound(float timer)
    {
        Debug.Log("In Coroutine");
        radioSound.Play();

        yield return new WaitForSeconds(timer);
        setRadioSound();



    }
}
