using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Metanoia.Components.Health
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] 
        private Image _imageCurrent = null;

        private IHealth _health;

        public void Construct(IHealth health)
        {
            _health = health;
            _health.HealthChanged += UpdateHpBar;
        }

        public void SetValue(float current, float max) =>
            _imageCurrent.fillAmount = current / max;

        private void OnDestroy()
        {
            if (_health != null)
                _health.HealthChanged -= UpdateHpBar;
        }

        private void UpdateHpBar() =>
            SetValue(_health.Current, _health.Max);
    }
}
