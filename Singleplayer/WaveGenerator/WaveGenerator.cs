using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class WaveAction
{
    public string name;
    public float delay;
    public Transform prefab;
    public int spawnCount;
    public string message;

    WaveGenerator WG;
    
}
[System.Serializable]
public class Wave
{
    public string name;
    public List<WaveAction> actions;
}
public class WaveGenerator : MonoBehaviour
{
    public float difficultyFactor = 0.9f;
    public List<Wave> waves;
    private Wave m_currentWave;
    public Wave CurrentWave {  get { return m_currentWave; } }
    public float m_DelayFactor = 1.0f;
    public Transform[] SpawnPoint;
    float wavecount;
    public TextMeshProUGUI WaveCounterText;
    public TextMeshProUGUI TimeText;
    bool IsFinished;


    IEnumerator SpawnLoop()
    {
        m_DelayFactor = 1.0f;
        
        while (true)
        {
            foreach(Wave W in waves)
            {
                
                m_currentWave = W;
                foreach(WaveAction A in W.actions)
                {
                    wavecount++;
                    float timer = A.delay;

                    while (timer > 0f)
                    {
                        TimeText.text = "Time Until Next Wave: " + timer.ToString("0") + " Seconds";
                        yield return null;
                        timer -= Time.deltaTime;
                    }







                    WaveCounterText.text = "Wave: " + wavecount.ToString();
                    if (A.message != " ")
                    {
         
                    }
                   
                    if (A.prefab != null && A.spawnCount > 0)
                    {
                        for(int i = 0; i < A.spawnCount; i++)
                        {
                            A.prefab = Instantiate(A.prefab, SpawnPoint[Random.Range(0, SpawnPoint.Length)].transform.position,Quaternion.identity);

                            
                        }
                    }
                }
            }
            yield return null;
        }
        m_DelayFactor *= difficultyFactor;
        yield return null;
    }
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {
        
    }

    
   
    
}

