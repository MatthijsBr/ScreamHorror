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
    int currentKnob = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Knobs[currentKnob].Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Check if rotation is correct
            if ((Knobs[currentKnob].rotation.eulerAngles.z > minRotation && Knobs[currentKnob].rotation.eulerAngles.z < maxRotation) ||
                (Knobs[currentKnob].rotation.eulerAngles.z - 180 > minRotation) && (Knobs[currentKnob].rotation.eulerAngles.z - 180 < maxRotation))
            {     
                currentKnob++;

                // Play correct sound
                if (currentKnob >= 3)
                {
                    // Puzzle is solved, unlock door

                    puzzle.PuzzleFinished(true);
                }
            }
            else
            {
                // Play incorrect sound

                // Reset puzzle
                currentKnob = 0;

                foreach (Transform knob in Knobs)
                    knob.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
