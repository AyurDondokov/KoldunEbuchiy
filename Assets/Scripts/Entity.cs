using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;
    [SerializeField] protected bool healthIsVisible;
    protected float barHeight = 15f;
    protected Color barColor = Color.green;
    protected int damage;

    protected Animator an{ get{ return GetComponent<Animator>(); } }

    void Start(){
        health = maxHealth;
    }

    public void SetValues(int newHealth, int newDamage) 
    {
        maxHealth = newHealth;
        health = maxHealth;

        damage = newDamage;
    }
    void OnGUI()
    {
        if (healthIsVisible) 
        {
            // Вычисляем координаты объекта в экранных координатах
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            GUI.color = barColor;
            // Вычисляем позицию полоски здоровья
            float barWidth = ((float)health / maxHealth) * 80f;
            float barX = screenPos.x - (barWidth / 2);
            float barY = Screen.height - screenPos.y - barHeight + 60f;

            // Отображаем полоску здоровья
            GUI.DrawTexture(new Rect(barX, barY, barWidth, barHeight), Texture2D.whiteTexture);
        }
    }

    public void TakeDamage(int inDamage) 
    {
        health -= inDamage;
        if (health <= 0)
            an.SetTrigger("death");
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
