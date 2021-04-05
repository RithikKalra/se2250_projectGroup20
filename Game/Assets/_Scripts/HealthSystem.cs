using System;
//update
public class HealthSystem
{

    private int health;
    private int healthMax;
    public event EventHandler OnHealthChanged;

    public HealthSystem(int health)
    {
        this.health = health;
        healthMax = health;
    }
 
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int health)
    {
        this.health = health;

        if (OnHealthChanged != null)
            OnHealthChanged(this, EventArgs.Empty);
    }
    public int GetHealthMax()
    {
        return healthMax;
    }
    public void SetHealthMax(int healthMax)
    {
        this.healthMax = healthMax;
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        if (OnHealthChanged != null)
            OnHealthChanged(this, EventArgs.Empty);
    }
}
