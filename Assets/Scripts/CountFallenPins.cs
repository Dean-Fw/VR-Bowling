using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountFallenPins : MonoBehaviour
{
    public GameObject[] pins;
    public int pinCount;
    public float delayDuration = 4f;
    public GameObject Display;

    private TextMeshPro score;

    private void Start()
    {
        score = Display.GetComponent<TextMeshPro>();

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(CountAfterDelay());
        }
    }

    private IEnumerator CountAfterDelay()
    {
        yield return new WaitForSeconds(delayDuration);

        pinCount = 0;
        foreach (GameObject pin in pins)
        {
            float pinRotationX = NormalizeRotation(pin.transform.eulerAngles.x);
            float pinRotationZ = NormalizeRotation(pin.transform.eulerAngles.z);
            bool isFallen = (Mathf.Abs(pinRotationX - 90f) < 30f || Mathf.Abs(pinRotationX + 90f) < 30f) ||
                            (Mathf.Abs(pinRotationZ - 90f) < 30f || Mathf.Abs(pinRotationZ + 90f) < 30f);
            if (isFallen)
            {
                pinCount++;
            }
        }
        
        score.text = pinCount.ToString();
        Debug.Log("Fallen Pin Count: " + pinCount);
    }

    private float NormalizeRotation(float rotation)
    {
        if (rotation > 180f)
        {
            rotation -= 360f;
        }
        return rotation;
    }
}
