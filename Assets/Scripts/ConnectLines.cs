using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLines : MonoBehaviour
{
    [SerializeField] Transform[] Knobs;
    [SerializeField] float rotateSpeed = 30f;
    [SerializeField] float minRotation = 80f;
    [SerializeField] float maxRotation = 100f;
    [SerializeField] Puzzle puzzle;
    [SerializeField] AudioClip correctSound;
    [SerializeField] AudioClip incorrectSound;    
    AudioSource audioSource;
    int currentKnob = 0;

    [SerializeField] bool[] upIsGood;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Knobs[currentKnob].Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        
        if (Input.GetButtonDown("Interact"))
        {
            // Check if rotation is correct
            if (((Knobs[currentKnob].rotation.eulerAngles.z > minRotation + 360 || Knobs[currentKnob].rotation.eulerAngles.z < maxRotation) && upIsGood[currentKnob]) ||
                (Knobs[currentKnob].rotation.eulerAngles.z - 180 > minRotation) && (Knobs[currentKnob].rotation.eulerAngles.z - 180 < maxRotation && !upIsGood[currentKnob]))
            {
                if (upIsGood[currentKnob])
                    Knobs[currentKnob].rotation = Quaternion.Euler(0, 0, 0);
                else
                    Knobs[currentKnob].rotation = Quaternion.Euler(0, 0, 180);

                currentKnob++;

                
                if (currentKnob >= 3)
                {
                    audioSource.PlayOneShot(correctSound);
                    puzzle.PuzzleFinished(true);
                }
            }
            else
            {
                // Play incorrect sound
                audioSource.PlayOneShot(incorrectSound);

                // Reset puzzle
                currentKnob = 0;

                foreach (Transform knob in Knobs)
                    knob.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
