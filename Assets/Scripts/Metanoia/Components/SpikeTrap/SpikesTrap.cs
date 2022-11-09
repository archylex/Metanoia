using Assets.Scripts.Metanoia;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrap : MonoBehaviour
{
    [Range(0.1f, 20.0f)]
    public float SpeedUp = 1.0f;

    [Range(0.1f, 20.0f)]
    public float SpeedDown = 1.0f;

    [Range(0.1f, 10.0f)]
    public float Delay = 1.0f;

    [Range(0.1f, 10.0f)]
    public float Cooldown = 2.0f;

    [Range(0.1f, 10.0f)]
    public float SpikeHeight = 1.0f;

    private Vector3 _originPosition;
        
    void Start()
    {
        _originPosition = transform.position;

        SetPositionY(0);

        StartCoroutine(SpikeWork());
    }
       
    private IEnumerator SpikeWork()
    {
        while (true)
        {
            yield return new WaitForSeconds(Cooldown);
            yield return Show();
            yield return new WaitForSeconds(Delay);
            yield return Hide();
        }
    }

    private IEnumerator Show()
    {
        for (float height = 0.0f; height < SpikeHeight; height += SpeedUp * Time.deltaTime)
        {
            SetPositionY(height);
            yield return null;
        }
    }

    private void SetPositionY(float height)
    {
        Vector3 position = transform.position;
        position.y = _originPosition.y + height - SpikeHeight;
        transform.position = position;
    }
    
    private IEnumerator Hide()
    {
        for (float height = SpikeHeight; height > Constants.Epsilon; height -= SpeedDown * Time.deltaTime)
        {
            SetPositionY(height);
            yield return null;
        }        
    }
        
}
