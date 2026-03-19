using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGameObject : MonoBehaviour
{
    public Transform _target;
    public Transform _target2;
    public float _speed;
    bool Moved;
    Vector3 originalposition;

     void Start()
    {
        originalposition = _target.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, _target2.position, _speed * Time.deltaTime);
        if (transform.position == _target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target2.position, _speed * Time.deltaTime);
            _target.position = _target2.position;
            Moved = true;
            
            
            if (transform.position == _target2.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
                _target.position = originalposition;
            }
        }

        
    }

    
}
