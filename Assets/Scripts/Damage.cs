using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Damage");
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
            GameManager.instance.ShowText("-1", 30, Color.red, transform.position, Vector3.up * 20, 1.5f);
        }
    }
}
