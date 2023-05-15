using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int startWeaponID;
    private float barHeight = 15f;
    [SerializeField] private Weapon[] WeaponsList;

    private void Start()
    {
        WeaponsList[startWeaponID].LevelUp();
        foreach (Weapon weapon in WeaponsList)
            weapon.gameObject.SetActive((weapon.GetLevel() > 0));
                
        health = maxHealth;
    }

    void OnGUI()
    {
        // Вычисляем координаты объекта в экранных координатах
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.color = Color.green;
        // Вычисляем позицию полоски здоровья
        float barWidth = ((float)health / maxHealth) * 80f;
        float barX = screenPos.x - (barWidth / 2);
        float barY = Screen.height - screenPos.y - barHeight + 160f;

        // Отображаем полоску здоровья
        GUI.DrawTexture(new Rect(barX, barY, barWidth, barHeight), Texture2D.whiteTexture);
    }

}
