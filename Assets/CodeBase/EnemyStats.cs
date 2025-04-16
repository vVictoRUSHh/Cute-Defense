using UnityEngine;
namespace CodeBase
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "TD/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {
         public float _speed;
         public float _health;
    }
}