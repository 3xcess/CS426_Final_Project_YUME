using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public Image timerText;
    public Image healthText;
    public GameObject gameOverPanel;
    public TMP_Text keysCollected;
    public GameObject keysPanel;

    private float timer = 60f;
    private float health = 100f;
    private bool isInDream;
    private bool isInChallenge = false;
    private float healthDecreaseTimer = 1f;
    private int challengeCollection = 0;
    private int keys = 0;
    public bool hasGameStarted = false; // ← make it public
    public bool hasIntroPlayed = false;

    private static HashSet<string> disabledIDs = new HashSet<string>();

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start(){
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        isInDream = (scene.name == "Dreams" || scene.name == "DW_LowerLevel") ;
    }

    private void Update(){
        if (!hasGameStarted) return;
        if(!isInChallenge){
            if (isInDream){
                timer -= Time.deltaTime;
                if (timer <= 0){
                    GameOver();
                }
            }
            else{
                healthDecreaseTimer -= Time.deltaTime;
                if (healthDecreaseTimer <= 0f){
                    health -= 1f;
                    healthDecreaseTimer = 1f;
                }

                if (health <= 0){
                    GameOver();
                }
            }
        } else {
            if (health <= 0){
                GameOver();
            }
        }

        UpdateUI();
    }

    private void UpdateUI(){
        timerText.fillAmount = timer / 60f;
        healthText.fillAmount = health / 100f;
        if(keys > 0){
            keysCollected.SetText(keys.ToString());
        } else {
            keysPanel.SetActive(false);
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddToTimer(){
        timer += 12f;
        if(timer > 60f){
            timer = 60f;
        }
    }

    public void AddToHealth(){
        health += 25f;
        if(health > 100f){
            health = 100f;
        }
    }

    public void DamageHealth(float damage){
        health -= damage;
    }

    public float getHealth(){
        return health;
    }

    public void enterChallenge(){
        isInChallenge = true;
    }

    public void exitChallenge(){
        isInChallenge = false;
    }

    public int getCollected(){
        return challengeCollection;
    }

    public void incrementCollected(){
        challengeCollection += 1;
    }

    public void resetCollection(){
        challengeCollection = 0;
    }

    public void getKey(){
        keysPanel.SetActive(true);
        keys += 1;
    }

    public void useKey(){
        keys -= 1;
        if(keys < 0){
            keysPanel.SetActive(false);
            keys = 0;
        }
    }

    public bool checkKeys(){
        if(keys > 0){
            return true;
        } else {
            return false;
        }
    }

    public bool checkDisabled(string id){
        return disabledIDs.Contains(id);
    }

    public bool nowDisabled(string id){
        return disabledIDs.Add(id);
    }

    public void clearDisabled(){
        disabledIDs.Clear();
    }

    public void AddToTimerC2(){
        timer += 20f;
        if(timer > 60f){
            timer = 60f;
        }
    }

    public void AddToTimerC3(){
        timer += 10f;
        if(timer > 60f){
            timer = 60f;
        }
    }

}
