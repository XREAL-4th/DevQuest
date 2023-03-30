﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player> {
    [Header("Preset")]
    public Shooter shooter;
    public MoveControl moveControl;
    public StatusEffectController statusEffectController;
}