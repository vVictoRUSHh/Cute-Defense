using UnityEngine;
namespace CodeBase
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform[] path;
        public EnemyView _enemyView;
        public EnemyStats _enemyStats;
        private EnemyModel _enemyModel;
        private int targetIndex = 0;
        
        private void EnemyMove()
        {
            if (targetIndex >= path.Length) return;

            transform.position = Vector3.MoveTowards(transform.position, path[targetIndex].position, _enemyModel.GetSpeed() * Time.deltaTime);
            if (Vector3.Distance(transform.position, path[targetIndex].position) < 0.1f)
                targetIndex++;
        }
        private void Awake()
        {
            _enemyModel = new EnemyModel(_enemyStats);
            _enemyView.Init(_enemyModel);
            _enemyModel._onDamageTaken += _enemyView.CallDamageEffect;
            _enemyModel._onDamageTaken += _enemyView.ShowPlayerHealth;
        }
        private void OnDestroy()
        {
            _enemyModel._onDamageTaken -= _enemyView.CallDamageEffect;
            _enemyModel._onDamageTaken -= _enemyView.ShowPlayerHealth;
        }
        private void Damage(int damage)
        {
            _enemyModel.TakeDamage(damage);
            Die();
        }
        private void Die()
        {
            if(_enemyModel.GetHealth()<=0)
                Destroy(this.gameObject);
        }
        private void Update()
        {
            EnemyMove();
            if(Input.GetKeyDown(KeyCode.G))Damage(20);
        }
    }
}