using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    [SerializeField] float[] size;

    private int level = 0;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.GetComponent<Crystal>()){
            other.gameObject.GetComponent<MoveObject>().MoveTo(transform.position - other.transform.position);
        }
    }
}
