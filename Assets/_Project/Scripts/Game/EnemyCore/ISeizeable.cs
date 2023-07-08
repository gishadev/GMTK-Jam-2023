﻿using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    public interface ISeizeable
    {
        Transform transform { get; }
        bool IsSeized { get; }
        void OnSeizeIn();
        void OnSeizeOut();
    }
}