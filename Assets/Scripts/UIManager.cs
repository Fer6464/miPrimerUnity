using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //No me acuerdo como funcionaba este Script
    private int enemyPoints = 0;
    private int coinPoints = 0;
    public static UIManager instance;  //no se que sea esto

    [Header("Text to Edit")]
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI enemigosText;

    //Metodo que actualiza las monedas recolectadas
    public void UpdateCoinText(int monedas)
    {
        coinPoints += monedas;
        monedasText.text = "Monedas: " + coinPoints;
    }

    //Metodo que actualiza los enemigos asesinados
    public void UpdateEnemyText(int enemigos)
    {
        enemyPoints += enemigos;
        enemigosText.text = "Enemigos: " + enemyPoints;

    }

    //Creador de la instancia global
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
