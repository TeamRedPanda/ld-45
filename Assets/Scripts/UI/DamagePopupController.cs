﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
class DamagePopupController : SingletonBehaviour<DamagePopupController>
{
    public FloatingText DamagePopupPrefab;
    public FloatingIcon DeathEmotePrefab;

    public void ShowDamage(Vector3 position, float value, Color color)
    {
        Vector2 posInScreen = Camera.main.WorldToScreenPoint(position);

        var floatingText = Instantiate(DamagePopupPrefab, this.transform);
        floatingText.Text = value.ToString();
        floatingText.Color = color;

        floatingText.GetComponent<RectTransform>().position = posInScreen;
    }

    internal void ShowDeath(Vector3 position)
    {
        Vector2 posInScreen = Camera.main.WorldToScreenPoint(position);

        var floatingIcon = Instantiate(DeathEmotePrefab, this.transform);
        floatingIcon.GetComponent<RectTransform>().position = posInScreen;
    }
}
