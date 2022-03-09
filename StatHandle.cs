using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandle : MonoBehaviour
{
    private int playerLevel = 1;
    public int PlayerLevel { get { return playerLevel; } }

    private float playerExp = 0.0001F;
    private float playerGainExp = 0.0001F;

    private bool isPlayerGainExp = false;
    private bool isPlayerDamaged = false;
    private bool isPlayerHealing = false;

    private bool isPlayerAlert = false;
    private bool isPlayerReady = false;
    private bool isPlayerAtacking = false;
    private bool isPlayerDefending = false;
    private bool isPlayerEnvading = false;
    private bool isPlayerParried = false;
    private bool isPlayerDodgeing = false;
    private bool isPlayerRetreating = false;

    private float playerGainDamagedExp = 0.0001F;

    private int p_atk = 1;
    private int p_str = 1;
    private int p_def = 1;
    private int p_rng = 1;
    private int p_mgk = 1;

    private float[] xpCheckPoints = new float[99];
    
    public float[] calculatedCheckPoints()
    {
        int level_cap = 0;

        int xp_recruit = 3;
        int xp_apprentice = 99;
        int xp_journeyman = 2400;
        int xp_master = 52000;
        int xp_grandmaster = 920000;

        int d = 1000000;

        float micro_expression = 0.001F;
        float bitchain = 0.00000001F;
       
        while (level_cap < xpCheckPoints.Length)
        {
            bitchain += 0.00000001F;
            xpCheckPoints[level_cap] = bitchain;
            if (level_cap >= 0 && level_cap <= 9) { bitchain += (((xp_recruit) * (float)level_cap) / d) + micro_expression;  }
            if (level_cap >= 10 && level_cap <= 36) { bitchain += (((xp_apprentice) * (float)level_cap) / d) + micro_expression; }
            if (level_cap >= 37 && level_cap <= 69) { bitchain += (((xp_journeyman) * (float)level_cap) / d) + micro_expression; }
            if (level_cap >= 70 && level_cap <= 92) { bitchain += (((xp_master) * (float)level_cap) / d) + micro_expression; }
            if (level_cap >= 93 && level_cap <= 99) { bitchain += (((xp_grandmaster) * (float)level_cap) / d) + micro_expression; }

            level_cap++;
        }
        return xpCheckPoints;
    }

    public const string newbie = "NEWBIE";
    public const string recruit = "RECRUIT";
    public const string apprentice = "APPRENTICE";
    public const string journeyman = "JOURNEYMAN";
    public const string master = "MASTER";
    public const string grandmaster = "GRANDMASTER";

    public string rank(int level)
    {
        string current_rank = newbie;
        if (level >= 0 && level <= 9) { current_rank = recruit; }
        if (level >= 10 && level <= 36) { current_rank = apprentice; }
        if (level >= 37 && level <= 69) { current_rank = journeyman; }
        if (level >= 70 && level <= 92) { current_rank = master; }
        if (level >= 93 && level <= 99) { current_rank = grandmaster; }
        return current_rank;
    }
    public const string normal = "NORMAL";
    public const string alert = "ALERT";
    public const string ready = "READY";
    public const string attack = "ATTACKING";
    public const string defend = "DEFENDING";
    public const string envade = "ENVADING";
    public const string parry = "PARRY";
    public const string dodge = "DODGE";
    public const string flee = "RETREAT";
    public string status(int effect)
    {
        string current_status = normal;
        switch (effect)
        {
            case 0: current_status = normal; return current_status; break;
            case 1: current_status = alert; return current_status; break;
            case 2: current_status = ready; return current_status; break;
            case 3: current_status = attack; return current_status; break;
            case 4: current_status = defend; return current_status; break;
            case 5: current_status = envade; return current_status; break;
            case 6: current_status = parry; return current_status; break;
            case 7: current_status = dodge; return current_status; break;
            case 8: current_status = flee; return current_status; break;

            default: return current_status; 


        }
    }

    
    public float PlayerExp { get { return playerExp; } }
    public float PlayerGainExp { get { return playerGainExp; } }
    public bool IsPlayerGainExp { get { return isPlayerGainExp; } }
    public bool IsPlayerDamaged { get { return isPlayerDamaged; } }
    public float PlayerGainDamagedExp { get { return playerGainDamagedExp; } }


    public float getExp()
    {
        return playerExp;
    }

    public float gainExp(float amount)
    {
        playerGainExp = amount;
        return playerGainExp;
    }

    void Start()
    {
        calculatedCheckPoints();
    }

    // Update is called once per frame
    void Update()
    {
        rank(PlayerLevel);
    }
}
