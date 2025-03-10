using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots = 0.2f; // Adjust fire rate

    private bool _fireContinuously = false;
    private float _lastFireTime;

    void Update()
    {
        if (_fireContinuously)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.linearVelocity = _bulletSpeed * transform.up; // Fixed velocity assignment
    }

    private void OnAttack(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if (Time.time - _lastFireTime >= _timeBetweenShots) // Enforce fire rate on first shot
            {
                FireBullet();
                _lastFireTime = Time.time;
            }
            _fireContinuously = true;
        }
        else
        {
            _fireContinuously = false;
        }
    }
}
