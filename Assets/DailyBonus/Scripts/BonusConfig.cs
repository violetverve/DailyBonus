using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BonusConfig
{
    private List<Bonus> _dailyBonuses;

    public List<Bonus> DailyBonuses => _dailyBonuses;

    public BonusConfig(List<Bonus> dailyBonuses)
    {
        _dailyBonuses = dailyBonuses;
    }
}