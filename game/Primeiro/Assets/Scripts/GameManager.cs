//Game Manager Script : Centraliza o estado do jogo (gold / recursos, gold por segundo), da as calls
//para ganhar ouro, iniciar auto-click, e comunicar com outros sistemas

using UnityEngine; //engine-base gameobject, monobehaviour, etc
using TMPro; //aceder as componentes de texto TextMeshProUGUI
using System.Collections; // necessário para usar IEnumerator nas co-routines



//MonoBehaviour - isto significa que o script pode ser ligado a um GameObject da cena e responde aos eventos do ciclo de vida (Awake, Start, etc.).
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //torna o gamemanager acessivel globalmente
    [Header("UI")] //organizaçao visual no inspetor
    public TextMeshProUGUI goldTxt, gpsTxt;
    public ClickManager clickManager; // referencias ligadas no inspetor
    public UpdateManager updateManager; // apontando para os GameObjets que tem os scripts
    [HideInInspector] public double gold; // quantidade de ouro atual
    [HideInInspector] public double goldPerSec; // valor gerado automaticamente por segundo

    //inicialização do Singleton (Está acessivel globalmente)
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        // destroi o gameObject se ja houver outro para evitar duplicação entre cenas, mantem este objeto ativo entre cenas
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Saver.Load();
        UpdateUI();
        StartCoroutine(AutoGoldLoop());
    }

    public void AddGold(double amount) 
    {  
        gold += amount;
        UpdateUI();
    }

    public void UpdateGoldPerSec()
    {
        goldPerSec = updateManager.TotalGPS();
        UpdateUI();
    }

    //Co-routine ouro automatico
    IEnumerator AutoGoldLoop()
    {
        while (true)
        {
            if (goldPerSec > 0)
                AddGold(goldPerSec);
            yield return new WaitForSeconds(1f);
        }
    }

    //Reflete os valores na Interface e formata os numeros 0-inteiro 0.0-decimal (atualiza o texto)
    void UpdateUI()
    {
        goldTxt.text = "Gold: " + gold.ToString("0");
        gpsTxt.text = "Gold Por Segundo: " + goldPerSec.ToString("0.0") + " /s";
    }

    private void OnApplicationQuit()
    {
        Saver.Save();
    }
}
