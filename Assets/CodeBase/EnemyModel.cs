using System;
using CodeBase;
public class EnemyModel 
{
    private float _speed;
    private float _health;
    public Action _onDamageTaken;
    public EnemyModel(EnemyStats enemyStats)
    {
        _speed = enemyStats._speed;
        _health = enemyStats._health;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        _onDamageTaken?.Invoke();
    }
    public float GetSpeed() => _speed;
    public float GetHealth() => _health;
}