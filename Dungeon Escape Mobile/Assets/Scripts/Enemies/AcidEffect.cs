using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    float timer = 0f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(timer < 5f)
        {
            timer += Time.deltaTime;           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent<IDamageable>(out IDamageable hit);

        if (hit != null)
        {
            hit.HandleDamage(1);
            Destroy(gameObject);
        }
    }
}
