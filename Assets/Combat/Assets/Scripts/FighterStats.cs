using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [SerializeField]
    private GameObject magicFill;

    [Header("Stats")]
    public float health;
    public float healthMin;
    public float healthMax;

    public float magic;
    public float magicMin;
    public float magicMax;

    public float melee;
    public float meleeMin;
    public float meleeMax;

    public float magicRange;

    public float defense;
    public float defenseMin;
    public float defenseMax;

    public float speed;
    public float experience;
    public float experienceMin;
    public float experienceMax;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool dead = false;

    // Resize health and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private GameObject GameControllerObj;

    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;

        // Initialize stats with RNG for enemies only
        if (gameObject.tag == "Enemy")
        {
            InitializeRandomStats();
        }else if(gameObject.tag == "Hero")
        {
            magic = PlayerStats.magicDamage; // Directly using magicDamage, adjust if you have a separate 'magic' stat
            melee = PlayerStats.strength; // Assuming strength can represent melee power, adjust as necessary
            health = 50 + PlayerStats.defense * 0.1f;
            speed = PlayerStats.speed;
            defense = 1;
        }

        startHealth = health;
        startMagic = magic;

        GameControllerObj = GameObject.Find("GameControllerObject");
    }

    void InitializeRandomStats()
    {
        health = UnityEngine.Random.Range(healthMin, healthMax); // Random health between 50 and 100
        magic = UnityEngine.Random.Range(magicMin, magicMax); // Random magic between 20 and 50
        melee = UnityEngine.Random.Range(10, 15); // Random melee attack power between 10 and 20
        magicRange = UnityEngine.Random.Range(5f, 15f); // Random magic range attack power between 5 and 15
        defense = UnityEngine.Random.Range(defenseMin, defenseMax); // Random defense between 5 and 10
        speed = UnityEngine.Random.Range(1f, 10f); // Random speed between 1 and 10
        experience = UnityEngine.Random.Range(experienceMin, experienceMax); // Experience can be set to 0 or another starting value
    }

    public void ReceiveDamage(float damage)
    {
        health = health - damage;
        animator.Play("Damage");

        // Set damage text
        if(damage < 0)
        {
            damage = 0;
        }
        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        } else if (damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
        if(damage >= 0)
        {
            GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
            GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();
        }
        Invoke("ContinueGame", 2);
    }

    public void updateMagicFill(float cost)
    {
        if(cost > 0)
        {
            magic = magic - cost;
            xNewMagicScale = magicScale.x * (magic / startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
        }
    }

    public bool GetDead()
    {
        return dead;
    }

    void ContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
    public void CalculateNextTurn(int currentTurn)
    {
        //nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
        nextActTurn = currentTurn + 2;
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }

}


