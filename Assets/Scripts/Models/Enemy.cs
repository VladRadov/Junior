using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody[] ragdolls;

    private DataEnemy _dataEnemy;

    private Animator _animator;

    private StateAlive _isAlive;

    private Slider _slider;

    public StateAlive IsAlive { get { return _isAlive; } }

    public enum StateAlive
    {
        Alive,
        Dead
    }

    private void Start()
    {
        _animator = transform.GetComponent<Animator>();
        _dataEnemy = transform.GetComponent<DataEnemy>();
        _slider = transform.Find("Canvas/Panel/Slider").GetComponent<Slider>();
        _slider.maxValue = _dataEnemy.Health;

        _isAlive = StateAlive.Alive;
        SetRagdolls(true);
    }

    public void HealthDecrease()
    {
        --_dataEnemy.Health;
        _slider.value = _slider.maxValue - _dataEnemy.Health;

        if (_dataEnemy.Health == 0)
        {
            Dead();
            _slider.gameObject.SetActive(false);
        }
    }

    private void Dead()
    {
        SetRagdolls(false);
        _isAlive = StateAlive.Dead;
    }

    private void SetRagdolls(bool setValue)
    {
        _animator.enabled = setValue;
        for (int i = 0; i < ragdolls.Length; i++)
            ragdolls[i].isKinematic = setValue;
    }
}
