using System;

public class HealthBarSystem {

    public event EventHandler OnHealthChanged;
    private int health;
    private int maxHealth;

    public HealthBarSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float)health / maxHealth;
    }

    public void Damage(int damageDone)
    {
        health -= damageDone;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
    public void Regan(int healed)
    {
        health += healed;
        if (health > maxHealth) health = maxHealth;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

}
