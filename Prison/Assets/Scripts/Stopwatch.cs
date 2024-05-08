using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Font customFont; // Reference to the custom font

    private System.Diagnostics.Stopwatch stopwatch;
    private bool raceEnded = false;

    private void Start()
    {
        stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
    }

    private void Update()
    {
        if (raceEnded)
        {
            // You can add any additional logic for post-race actions here
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !raceEnded)
        {
            // Player triggered the end of the race
            stopwatch.Stop(); // Stop the stopwatch
            DisplayRaceTime(stopwatch.Elapsed); // Display the race time to the player
            raceEnded = true; // Set a flag to ensure this only happens once
        }
    }

    private void DisplayRaceTime(System.TimeSpan elapsedTime)
    {
        // Create a UI Canvas if not already present
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }

        // Create a Text object
        Text raceTimeText = new GameObject("RaceTimeText").AddComponent<Text>();
        raceTimeText.font = customFont; // Set the custom font
        raceTimeText.fontSize = 24; // Set the font size
        raceTimeText.alignment = TextAnchor.MiddleCenter;
        raceTimeText.color = Color.black;
        raceTimeText.text = "Race Time: " + elapsedTime.ToString("mm':'ss'.'ff");

        // Make the Text object a child of the Canvas
        raceTimeText.transform.SetParent(canvas.transform, false);
    // Add a coroutine to make the text disappear after 3 seconds
        StartCoroutine(DisappearAfterDelay(raceTimeText.gameObject, 3f));
    }

    private IEnumerator DisappearAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy the GameObject after the delay
        Destroy(obj);
    }
}