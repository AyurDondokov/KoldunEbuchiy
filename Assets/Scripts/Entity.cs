using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{
    public GameObject obj;
    public int maxCount;
    public int chance;
}

public class Entity : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;
    public bool isDead;
    [SerializeField] protected bool healthIsVisible;
    protected float barHeight = 11f;
    protected Color barColor = Color.green;
    [SerializeField] protected int damage;

    public Item[] itemList;

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
        drop();
    }

    protected void drop(){
        foreach(Item item in itemList){
            int Count = Random.Range(1, item.maxCount);
            if(Random.Range(1, item.chance) == 1){
                for (int i=0; i<Count; i++){
                    float pos_x = transform.position.x + Random.Range(1f, 2f);
                    float pos_y = transform.position.y + Random.Range(1f, 2f);
                    Vector2 pos = new Vector2(pos_x, pos_y);
                    Instantiate(item.obj, pos, Quaternion.identity);
                }
            }
        }
    }
}