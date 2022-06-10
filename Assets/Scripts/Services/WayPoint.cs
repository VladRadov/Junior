using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] List<Enemy> _enemies;

    public bool IsAllDeadEnemie()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].GetComponent<Enemy>().IsAlive == Enemy.StateAlive.Dead)
                _enemies.Remove(_enemies[i]);
        }

        var result = _enemies.Count == 0 ? true : false;
        return result;
    }
}
