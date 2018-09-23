using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public RpgSkills rpg;

    public int improvSkill;
    public int fluidSkill;
    public int balanceSkill;
    public int movesetSkill;

    private float theDo;
    private float theSneaks;
    public float theThreadz;
    private float theBling;

    private float dirtyScale = 1f;
    private float secondsCount;

    private int beerCount = 0;

    private IEnumerator Bco;
    private IEnumerator Cco;

    public UIManager2 ui;

    // Use this for initialization
    void Start () {
        rpg = GameObject.Find("Skills").GetComponent<RpgSkills>();
        theDo = 1f;
        theThreadz = 1f;
        improvSkill = rpg.improv;
        fluidSkill = rpg.fluidity;
        balanceSkill = rpg.balance;
	}
	
	// Update is called once per frame
	void Update () {
        secondsCount += Time.deltaTime;
        if(secondsCount >= 60)
        {
            theDo -= dirtyScale;
            theThreadz -= dirtyScale;
            secondsCount = 0;
            Debug.Log("gettin dirty " + theThreadz);
        }
        if(theDo <= 1f)
        {
            theDo = 1f;
        }
        if (theThreadz <= 1f)
        {
            theThreadz = 1f;
        }
    }

    public float MoveScore(string move, int counter)
    {
        float moveScore = 0;

        float fluidityScore;
        float balanceScore;

        float fluidRange = Random.Range(0, fluidSkill);
        float balanceRange = Random.Range(0, balanceSkill);

        if (fluidRange <= fluidSkill)
        {
            fluidityScore = 1;
        } else
        {
            fluidityScore = fluidRange / 2;
        }

        if (balanceRange <= balanceSkill)
        {
            balanceScore = 1;
        }
        else
        {
            balanceScore = balanceRange / 2;
        }

        moveScore += fluidityScore;
        moveScore += balanceScore;

        if (move == "basicMove")
        {
            moveScore += rpg.basicMoveValue / counter;
        }
        else if (move == "finishMove")
        {
            moveScore += rpg.finishMoveValue / counter;
        }

        return moveScore;
    }

    public void Laundry()
    {
        theThreadz = 5f;
        Debug.Log(theThreadz);
    }

    public void Shower()
    {
        theDo = 5f;
    }

    public void Drink (string drink)
    {
        ui.barCanvas.enabled = false;
        if(drink == "Cactus")
        {
            fluidSkill = 0;
            improvSkill = 10;
            balanceSkill = 3;
            Cco = CactusTime(30.0f);
            StartCoroutine(Cco);
        }
        if(drink == "Beer")
        {
            beerCount++;
            if(beerCount == 1)
            {
                fluidSkill += 2;
                Bco = BeerTime(10.0f);
                StartCoroutine(Bco);
            }
            if(beerCount == 2)
            {
                balanceSkill -= 2;
                Bco = BeerTime(10.0f);
                StartCoroutine(Bco);
            }
            if (beerCount >= 3)
            {
                balanceSkill -= 3;
                Bco = BeerTime(10.0f);
                StartCoroutine(Bco);
            }
        }
    }

    IEnumerator CactusTime(float time)
    {
        yield return new WaitForSeconds(time);
        fluidSkill = rpg.fluidity;
        improvSkill = rpg.improv;
        balanceSkill = rpg.balance;
    }

    IEnumerator BeerTime(float time)
    {
        yield return new WaitForSeconds(time);
        if(beerCount == 1)
        {
            fluidSkill -= 2;
        } else if (beerCount == 2)
        {
            balanceSkill += 2;
        } else if (beerCount >= 3)
        {
            balanceSkill += 3;
        }
        beerCount--;
    }
}
