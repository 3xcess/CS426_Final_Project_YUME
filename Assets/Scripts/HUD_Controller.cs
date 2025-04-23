using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    public GameObject hudCanvasRoot;

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
        if (scene.name == "EndScene")
        {  
            DisableHUD();
        }
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

    private void GameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddToTimer(){
        timer += 10f;
    }

    public void AddToHealth(){
        health += 10f;
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
    public void DisableHUD()
    {
    if (hudCanvasRoot != null)
    {
        hudCanvasRoot.SetActive(false);
        Debug.Log("✅ HUD canvas root disabled in EndScene.");
    }
    else
    {
        // Fallback: disable individual parts
        if (timerText != null) timerText.gameObject.SetActive(false);
        if (healthText != null) healthText.gameObject.SetActive(false);
        if (keysPanel != null) keysPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }
    }
}
