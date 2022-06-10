using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody[] ragdolls;

    [SerializeField] private IWeapon _weapon;

    private NavMeshAgent _agent;

    private Animator _animator;

    public void Initialized(NavMeshAgent agent, Animator animator, IWeapon weapon)
    {
        _agent = agent;
        _animator = animator;
        _weapon = weapon;

        for (int i = 0; i < ragdolls.Length; i++)
            ragdolls[i].isKinematic = true;
    }

    public void Move(Vector3 target)
    {
        _agent.SetDestination(target);
    }

    public void Fire(Vector3 directionPosition)
    {
        _weapon.CreateBullet(transform.position, directionPosition);
    }

    public void AnimatorSetBool(string nameParametr, bool value)
    {
        _animator.SetBool(nameParametr, value);
    }
}
