using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private int soundInt;
    private GameObject soundObject;

    public Toggle soundToggle;
    public GameObject disabledSoundIcon;

    void Awake()
    {
        soundObject = GameObject.Find("Sound");
    }

    private void Start()
    {
        soundInt = PlayerPrefs.GetInt("SoundIntBool", 0);

        Debug.Log("Load Scene");

        if (soundInt == 0)
        {
            disabledSoundIcon.SetActive(false);
            soundToggle.isOn = true;
            soundObject.SetActive(true);
        }
        else if (soundInt == 1)
        {
            disabledSoundIcon.SetActive(true);
            soundToggle.isOn = false;
            soundObject.SetActive(false);
        }
    }

    public void TurnOn()
    {
        if (soundToggle.isOn) 
        {
            disabledSoundIcon.SetActive(false);
            soundInt = 0;
            PlayerPrefs.SetInt("SoundIntBool", soundInt);
            soundObject.SetActive(true);
        }
        else
        {
            disabledSoundIcon.SetActive(true);
            soundInt = 1;
            PlayerPrefs.SetInt("SoundIntBool", soundInt);
            soundObject.SetActive(false);
        }
    }
}
