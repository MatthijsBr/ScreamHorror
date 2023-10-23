using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    InventoryManager inventory;
    [SerializeField] MainManager main;
    [SerializeField] Image black;
    [SerializeField] float fadeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            StartCoroutine(OnDeath(GameObject.FindGameObjectWithTag("Antagonist").transform));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Antagonist")
        {
            StartCoroutine(OnDeath(other.transform));
            
        }
    }

    IEnumerator FadeToBlack(float seconds)
    {
        for(float a = 0; a < 1f; a+=0.01f)
        {
            Debug.Log(a);
            black.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(seconds / 100f);
        }
    }

    IEnumerator OnDeath(Transform antagonist)
    {
        // Disable movement
        GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<CameraController>().enabled = false;        
        
        // Put the enemy on another floor than the player if possible. Maybe set speed to 0?
        antagonist.position = main.RandomPositionInMaze();
        float originalSpeed = antagonist.GetComponent<Antagonist>().Speed;
        antagonist.GetComponent<Antagonist>().Speed = 0;

        // Fade to black
        for (float a = 0; a < 1f; a += 0.01f)
        {
            Debug.Log(a);
            black.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(fadeTime / 100f);
        }

        // Die
        Debug.Log("Dead");

        // Reset items
        inventory.HideItemsInMaze();

        // Reset maze
        main.GenerateAndBake();

        // Maybe make sure player doesn't get stuck on walls
        transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, transform.position.y, Mathf.Floor(transform.position.z) + 0.5f);

        // Play voice lines

        // Fade to game
        for (float a = 1; a > 0f; a -= 0.01f)
        {
            Debug.Log(a);
            black.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(fadeTime / 100f);
        }

        // Activate game
        antagonist.GetComponent<Antagonist>().Speed = originalSpeed;

        GetComponent<PlayerMovement>().enabled = true;
        GetComponentInChildren<CameraController>().enabled = true;
    }
}
