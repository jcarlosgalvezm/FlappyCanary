using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFlapToRestart : MonoBehaviour {

    public GameObject flapToRestart;
    public int delay = 1;

	// Use this for initialization
	void OnEnable () {
        Invoke("EnableFlapToRestart", delay);
	}

    void EnableFlapToRestart()
    {
        flapToRestart.SetActive(true);
        SoundSystem.instance.StopSounds();
        SoundSystem.instance.PlayEnding();
    }
	
}
