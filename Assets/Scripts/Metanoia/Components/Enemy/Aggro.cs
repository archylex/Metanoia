using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Components.Enemy
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private float _cooldown = default;
        [SerializeField] private Follow _follow = null;

        private bool _hasAggroTarget;

        private TriggerObserver _triggerObserver;
        private Coroutine _aggroCoroutine;

        private void Awake() =>
            _triggerObserver = GetComponentInChildren<TriggerObserver>();

        private void Start()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;

            SwitchFollowOff();
        }

        private void TriggerEnter(Collider obj)
        {
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;
                StopAgroCoroutine();
                SwitchFollowOn();
            }
        }

        private void TriggerExit(Collider obj)
        {
            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;
                _aggroCoroutine = StartCoroutine(SwitchFollowAfterCooldown());
            }
        }

        private IEnumerator SwitchFollowAfterCooldown()
        {
            yield return new WaitForSeconds(_cooldown);

            SwitchFollowOff();
        }

        private void StopAgroCoroutine()
        {
            if (_aggroCoroutine != null)
            {
                StopCoroutine(_aggroCoroutine);
                _aggroCoroutine = null;
            }
        }

        private void SwitchFollowOn() =>
            _follow.enabled = true;

        private void SwitchFollowOff() =>
            _follow.enabled = false;
    }
}
