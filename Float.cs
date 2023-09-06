using System.Collections;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float moveDistance = 1.0f; // The distance to move up and down.
    public float moveSpeed = 1.0f;    // The speed of the animation.

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(AnimateUpDown());
    }

    private IEnumerator AnimateUpDown()
    {
        while (true)
        {
            Vector3 targetPosition = startPosition + Vector3.up * moveDistance;
            float journeyLength = Vector3.Distance(transform.position, targetPosition);
            float startTime = Time.time;

            while (Time.time - startTime < journeyLength / moveSpeed)
            {
                float distanceCovered = (Time.time - startTime) * moveSpeed;
                float fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }

            yield return new WaitForSeconds(1.0f); // Wait at the top position for 1 second.

            targetPosition = startPosition;
            journeyLength = Vector3.Distance(transform.position, targetPosition);
            startTime = Time.time;

            while (Time.time - startTime < journeyLength / moveSpeed)
            {
                float distanceCovered = (Time.time - startTime) * moveSpeed;
                float fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }

            yield return new WaitForSeconds(1.0f); // Wait at the bottom position for 1 second.
        }
    }
}
