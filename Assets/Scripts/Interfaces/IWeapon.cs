using UnityEngine;

public interface IWeapon
{
    void CreateBullet(Vector3 startPosition, Vector3 directionPosition);

    void Fire();
}
