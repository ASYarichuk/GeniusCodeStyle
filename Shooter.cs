using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    [SerializeField] private Rigidbody _bulletPrefab;

    [SerializeField] private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        float timeWait = new WaitForSeconds(_delay);

        while (isWork)
        {
            var vector3direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.transform.up = vector3direction;
            newBullet.GetComponent<Rigidbody>().velocity = vector3direction * _speed;

            yield return timeWait;
        }
    }
}