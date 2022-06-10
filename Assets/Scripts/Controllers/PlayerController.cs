using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;

    private Player _player;

    private NavMeshAgent _agent;

    private Animator _animator;

    private void Start()
    {
        _player = transform.GetComponent<Player>();
        _agent = transform.GetComponent<NavMeshAgent>();
        _animator = transform.GetComponent<Animator>();
        var weapon = _weapon.GetComponent<IWeapon>();

        _player.Initialized(_agent, _animator, weapon);
    }
    private void FixedUpdate()
    {
        if (_agent.remainingDistance == 0)
            _player.AnimatorSetBool("IsWalking", false);
        else
            _player.AnimatorSetBool("IsWalking", true);
    }
}
