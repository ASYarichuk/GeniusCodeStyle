using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CreaterBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var vector3direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.transform.up = vector3direction;
            newBullet.GetComponent<Rigidbody>().velocity = vector3direction * _speed;

            yield return new WaitForSeconds(_delay);
        }
    }
}