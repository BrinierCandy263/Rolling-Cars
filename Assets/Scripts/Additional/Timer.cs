using System;
using UnityEngine;

/// <summary>
/// A timer with an event-based callback to improve efficiency.
/// </summary>
public class Timer : MonoBehaviour
{
    private float totalSeconds = 0;
    private float elapsedSeconds = 0;
    private bool running = false;
    private bool started = false;

    // Event to notify when the timer finishes
    public event Action OnTimerFinished;

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished => started && !running;
    public bool Running => running;

    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
                OnTimerFinished?.Invoke(); // Invoke the event when the timer ends
            }
        }
    }

    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }
}