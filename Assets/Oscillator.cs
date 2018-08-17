using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    float movementFactor;

    Vector3 startingPos;

	// Use this for initialization
	void Start ()
    {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (period <= Mathf.Epsilon) // protecting against NaN error
        {
            return;
        }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; // around 6.28 
        float rawSinWave = Mathf.Sin(cycles * tau); // cycles between -1 to 1

        movementFactor = (rawSinWave / 2f) + .5f;
        print(movementFactor);

        Vector3 offsetPos = movementVector * movementFactor;
        transform.position = startingPos + offsetPos;
	}
}
