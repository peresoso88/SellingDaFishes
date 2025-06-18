using UnityEngine;
using System.Collections;
using TMPro;

public class Cast : MonoBehaviour
{
    public GameObject tacklePrefab;
    public Transform castPoint;
    public float castForce = 10f;
    private GameObject currentTackle;
    private bool tackleIsActive = false;
    public RectTransform minigameUI;
    public AudioSource castAudio;
    public AudioSource castAudio2;
    public AudioSource FishBite;
    public TextMeshProUGUI fishCounterText;
    private int fishCount = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    void Update()
    {
       
            
        


        if (Input.GetMouseButtonDown(0))
        {
            if (!tackleIsActive)
            {
                // Spawn and throw the tackle
                currentTackle = Instantiate(tacklePrefab, castPoint.position, castPoint.rotation);
                Rigidbody rb = currentTackle.GetComponent<Rigidbody>();

                Vector3 castDirection = (castPoint.forward + castPoint.up * 0.2f).normalized;
                rb.AddForce(castDirection * castForce, ForceMode.Impulse);

                //  Attach the Minigame UI so the cloned bobber can trigger it later
                Fishing FishingScript = currentTackle.GetComponent<Fishing>();
                if (FishingScript != null)
                {
                    FishingScript.minigameUI = minigameUI;  // Make sure this field exists on this script!
                    FishingScript.playerCastScript = this;

                }
                

                tackleIsActive = true;
                castAudio.Play();
            }
            else
            {
                if (currentTackle != null)
                {
                    Fishing FishingScript = currentTackle.GetComponent<Fishing>();

                    if (FishingScript != null && FishingScript.isDipping)
                    {
                        // Only THEN show the minigame UI
                        minigameUI.gameObject.SetActive(true);
                        return; // Wait for player to click to complete minigame
                    }

                    // Not dipping  skip showing UI, just despawn
                    Destroy(currentTackle);
                    tackleIsActive = false;
                    castAudio2.Play();
                }

                StartCoroutine(HandleMinigameEnd());


                

                StartCoroutine(HandleMinigameEnd());
                IEnumerator HandleMinigameEnd()
                {
                    // Wait one frame to let Minigame register the click
                    yield return null;

                    minigameUI.gameObject.SetActive(false);

                    if (currentTackle != null)
                    {
                        Destroy(currentTackle);
                        currentTackle = null;

                    }
                    tackleIsActive = false; // <-- Now you can recast
                }
            }
        }


    }

    public void IncrementFishCount()
    {
        fishCount++;
        fishCounterText.text = ":" + fishCount;
    }
}
