using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    //[SerializeField] private GameObject player;
    private GameObject playerObject;
    private Player playerScript;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObject.GetComponent<Player>();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].CompareTag("Player"))
            {
                playerScript.BoostSpeedTemporarily();
                Destroy(gameObject);
                break;
            }

            //Debug.Log(hits[i].name);

            //hits[i] = null;
        }
    }
}
