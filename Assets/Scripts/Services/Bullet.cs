using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(SetActiveFalse());
    }

    private IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(2);
        transform.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.layer == 3)
                collision.transform.GetComponent<Enemy>().HealthDecrease();

            transform.gameObject.SetActive(false);
        }
    }
}
