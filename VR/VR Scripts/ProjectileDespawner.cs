using UnityEngine;

public class ProjectileDespawner : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2.5f);
    }
}
