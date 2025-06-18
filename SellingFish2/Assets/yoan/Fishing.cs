using UnityEngine;
using System.Collections;
public class Fishing : MonoBehaviour
{
    public float minWaitTime = 3f;
    public float maxWaitTime = 7f;
    public float dipDuration = 1f;

    private bool isWaiting = false;
    public bool isDipping = false;

    public RectTransform minigameUI;
    public AudioSource FishBite;
    public Cast playerCastScript;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BobberWaitRoutine());

    }

        IEnumerator BobberWaitRoutine()

        { 

        isWaiting = true;
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        // Dip the bobber
        isDipping = true;
        Debug.Log("Bobber dipped!");

        if (playerCastScript != null && playerCastScript.FishBite != null)
        {
            playerCastScript.FishBite.Play();
        }
        else
        {
            Debug.LogError("Missing reference: playerCastScript or FishBite is null");
        }


        // Animate or move bobber down here

        yield return new WaitForSeconds(dipDuration);

        isDipping = false;
        Debug.Log("Bobber back up!");
        // Animate bobber back up
        }
    

    // Update is called once per frame
    void Update()
    {
        if (isDipping && Input.GetMouseButtonDown(0))
        {
            

           
            
            Debug.Log("Player clicked in time!");
           
        }

       

    }

}
