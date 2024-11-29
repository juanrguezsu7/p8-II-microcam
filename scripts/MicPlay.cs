using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicPlay : MonoBehaviour
{
    AudioSource leftSpeaker, rightSpeaker;
    // Start is called before the first frame update
    void Start()
    {
        leftSpeaker = GameObject.Find("LeftSpeaker").GetComponent<AudioSource>();
        rightSpeaker = GameObject.Find("RightSpeaker").GetComponent<AudioSource>();

        AudioClip clip = Microphone.Start(null, false, 3, 44100);
        leftSpeaker.clip = clip;
        rightSpeaker.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            leftSpeaker.Play();
            rightSpeaker.Play();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Microphone.End(null);
        }
    }
}
