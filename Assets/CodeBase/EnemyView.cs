using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace CodeBase
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hpCount;
        [SerializeField] private Slider _hpBar;
        [SerializeField] private Material _enemyMaterial;
        private EnemyModel _enemyModel;
        public void Init(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _enemyMaterial.color = Color.gray;
            _hpCount.text = _enemyModel.GetHealth().ToString();
        }
        public void CallDamageEffect()
        {
            StartCoroutine(DamageEffectTimer(0.1f));
        }
        private IEnumerator DamageEffectTimer(float s)
        {
            _enemyMaterial.color = Color.red;
            yield return new WaitForSeconds(s);
            _enemyMaterial.color = Color.gray;
        }
        public void ShowPlayerHealth()
        {
            _hpCount.text = _enemyModel.GetHealth().ToString();
            _hpBar.value = _enemyModel.GetHealth() / 100;
        }
    }
}