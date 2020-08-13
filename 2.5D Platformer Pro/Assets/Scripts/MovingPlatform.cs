using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private float _speed = 5.0f;
    private bool _atPointB = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //current transform value (transform.position) = vector3.movetowards(current position, target, )
        //move to point b
        //if at point b
        //move to point a
        //if at point a
        //move to point b

        if(_atPointB == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);

            if(transform.position == _targetB.position)
            {
                _atPointB = true;
            }
        } else if(_atPointB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);

            if(transform.position == _targetA.position)
            {
                _atPointB = false;
            }
        }

        


    }
}
