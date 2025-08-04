using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}