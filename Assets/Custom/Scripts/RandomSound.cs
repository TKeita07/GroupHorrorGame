using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSound : MonoBehaviour
{
    
    public int minTime = 10;
    public int maxTime = 25;
    private AudioSource m_audioSource;
    
    private float waitTime = 10.0f;
    private float timeCounter = 10.0f;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        ResetWaitTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter >= waitTime)
        {
            m_audioSource.Play();
            ResetWaitTimer();
        }

        timeCounter += Time.deltaTime;            
    }


    private void ResetWaitTimer()
    {
        waitTime = Random.Range(minTime, maxTime);
        timeCounter = 0f;
    }   
}
