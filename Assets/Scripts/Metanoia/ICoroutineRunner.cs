using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Metanoia
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
