using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int chanceChest;
    protected int health;
    public bool isDead;
    [SerializeField] protected bool healthIsVisible;
    protected float barHeight = 11f;
    protected Color barColor = Color.green;
    protected int damage;

    public GameObject XPcrystal;
    public GameObject chest;

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
            float barWidth = ((float)health / maxHealth) * 75f;
            float barX = screenPos.x - (barWidth / 2);
            float barY = Screen.height - screenPos.y - barHeight + 40f;

            // Отображаем полоску здоровья
            GUI.DrawTexture(new Rect(barX, barY, barWidth, barHeight), Texture2D.whiteTexture);
        }
    }

    public void TakeDamage(int inDamage) 
    {
        health -= inDamage;
        if (health <= 0){
            isDead = true;
            an.SetTrigger("death");
        }
    }

    public void Die(){
        Destroy(gameObject);
        if (XPcrystal)
            dropXP();
        if (chest)
            dropChest();
    }

    private void dropXP() 
    {
        int crystalsCount = Random.Range(1, 6);
        for (int i=0; i<crystalsCount; i++){
            float pos_x = transform.position.x + Random.Range(1f, 2f);
            float pos_y = transform.position.y + Random.Range(1f, 2f);
            Vector2 pos = new Vector2(pos_x, pos_y);
            Instantiate(XPcrystal, pos, Quaternion.Euler(0,0,Random.Range(0,181)));
        }
    }

    private void dropChest()
    {
        if(Random.Range(1, chanceChest) == 1)
        {
            Instantiate(chest, transform.position, Quaternion.Euler(0,0,0));
        }
    }
}