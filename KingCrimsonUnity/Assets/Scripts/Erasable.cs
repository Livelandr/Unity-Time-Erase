// Made by Livelandr
// Sounds by David Production (From Jojo's Bizzare Adventure)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasable : MonoBehaviour
{

    public float Xspeed, Yspeed, Zspeed;

    private float StX, StY, StZ;

    void Start()
    {
        StX = gameObject.transform.localScale.x; StY = gameObject.transform.localScale.y; StZ = gameObject.transform.localScale.z; // Saving normal sizes'

    }

    public void TEAnim()
    {
        StartCoroutine(Animation()); // Calling Animation (From Main.cs)
    }

    public void OrigScale()
    {
        transform.localScale = new Vector3(StX, StY, StZ);      
    }


    IEnumerator Animation() //Animation!
    {
        yield return new WaitForSeconds(1f); // Waiting 1 sec...
        CameraShake.Shake(1, 1); // ShAkE!1!
        while (gameObject.transform.localScale.x > 0 && gameObject.transform.localScale.y > 0 && gameObject.transform.localScale.y > 0) 
        {
            yield return new WaitForSeconds(0.02f); // Small interval
            gameObject.transform.localScale -= new Vector3(Xspeed, Yspeed, Zspeed); // Reducing object size
        }

        gameObject.transform.localScale = new Vector3(0, 0, 0); // Object disappear!



    }
}
