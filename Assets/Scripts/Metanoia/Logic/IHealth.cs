﻿using System;

namespace Assets.Scripts.Metanoia.Logic
{
    public interface IHealth
    {
        float Current { get; set; }
        float Max { get; set; }
        event Action HealthChanged;
        void TakeDamage(float damage);
    }
}
