// Made by Livelandr
// Sounds by David Production (From Jojo's Bizzare Adventure)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Main : MonoBehaviour
{
    private AudioSource Sound;

    public GameObject TEUI;
    public GameObject TSUI;

    public AudioClip TimeEraseTheme;
    public AudioClip TimeSkipSound;
    public AudioClip TimeEraseSound;

    bool isErasing;

    public Material Erasured;
    public Material Normal;

    // Update is called once per frame
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }


	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Q) && !isErasing) // On pressing Q when time doesn't erasing it skips
        {
            StartCoroutine(TimeSkip()); // Calling coroutine TimeSkip
        }
        if (Input.GetKeyDown(KeyCode.E) && !isErasing) // On pressing E when time doesn't erasing it starts erasing (what?)
        {
            StartCoroutine(TimeErase());  // Calling coroutine TimeErase
        }
    }

	IEnumerator TimeSkip() // Coroutine TimeSkip
    {
        TSUI.SetActive(true); // Red Screen On
        Time.timeScale = 100f; //Time Accelerate!
        yield return new WaitForSeconds(0.6f); // Waiting one moment;
        Time.timeScale = 1f; // Time continues its course
        Sound.PlayOneShot(TimeSkipSound); // Time skip sound
        yield return new WaitForSeconds(0.3f); // Waiting...
        TSUI.SetActive(false); // Red Screen Off
    }

    IEnumerator TimeErase() // Coroutine
    {


        isErasing = true;

        var objects = FindObjectsOfType<Erasable>(); // Finding all Erasable objects
        for (var i = 0; i < objects.Length; i++) 
        {
            objects[i].GetComponent<Erasable>().TEAnim(); // Calls function TEAnim for all
        }
        TEUI.GetComponent<Animator>().SetTrigger("Erase"); // Effect
        Sound.PlayOneShot(TimeEraseSound); //Time Erase Sound
        yield return new WaitForSeconds(1); // Waiting 1 sec
        Sound.PlayOneShot(TimeEraseTheme); //Diavolo's Monolog

        RenderSettings.skybox = Erasured; // Red Sky

        Time.timeScale = 0.5f; // Time Slowdown

        yield return new WaitForSeconds(4.55f); // Waiting 9 seconds

        Time.timeScale = 1f; // Time continues its course    

        Sound.PlayOneShot(TimeEraseSound); // Time Erase sound again
        TEUI.GetComponent<Animator>().SetTrigger("Erase"); // Effect again
        yield return new WaitForSeconds(1); // Waiting.......................

        RenderSettings.skybox = Normal; // Return of beautful sky!

        var objectss = FindObjectsOfType<Erasable>(); // finding all erasable objects...
        for (var i = 0; i < objects.Length; i++)
        { 
            objectss[i].GetComponent<Erasable>().OrigScale(); // Returning they into normal state
        }


        isErasing = false;

    }
}
