using System;

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
