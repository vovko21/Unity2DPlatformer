using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private string TagToTake;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == TagToTake)
        {
            Destroy(collider.gameObject);
            ScoreController.Score++;
        }
    }
}
