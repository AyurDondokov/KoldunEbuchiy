using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Move params
    private MoveObject _moveObj;
    private Vector2 _direction;

    [Header("KeyCodes")]
    public KeyCode[] WSDAKeys;
    public KeyCode ActionKey;

    [Header("Action params")]
    [SerializeField] private float actionDistance;

    private void Start()
    {
        _moveObj = GetComponent<MoveObject>();
    }

    private void Update()
    {
        if (Input.GetKey(WSDAKeys[0]) && !Input.GetKey(WSDAKeys[1]))
        {
            _direction.y = 1;
        }
        else if (Input.GetKey(WSDAKeys[1]) && !Input.GetKey(WSDAKeys[0]))
        {
            _direction.y = -1;
        }
        else
        {
            _direction.y = 0;
        }    

        if (Input.GetKey(WSDAKeys[2]) && !Input.GetKey(WSDAKeys[3]))
        {
            _direction.x = 1;
        }
        else if (Input.GetKey(WSDAKeys[3]) && !Input.GetKey(WSDAKeys[2]))
        {
            _direction.x = -1;
        }
        else
        {
            _direction.x = 0;
        }

        _moveObj.MoveTo(_direction);

        ActionObjsCheck();
        
    }

    private void ActionObjsCheck() 
    {
        if (Input.GetKeyDown(ActionKey))
        {
            foreach (Collider2D obj in Physics2D.OverlapCircleAll(transform.position, actionDistance))
            {
                if (obj.GetComponent<ActionObj>())
                    obj.GetComponent<ActionObj>().InvokeAction();
            }
        }
    }
}
