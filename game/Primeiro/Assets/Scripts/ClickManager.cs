//Reage ao clique do jogador no botao principal e acrescenta ouro. E o nucleo da interaçao ativa
using UnityEngine;


//Unity so permite associar metodos a UI buttons se o script for mono behaviour
public class ClickManager : MonoBehaviour
{
    //Private protege a variavel do acesso direto por outros scripts, e serializefield permite mostrar e editar no Inspector
    [SerializeField] private double clickValue = 1;


    public void OnClick()
    {
        GameManager.instance.AddGold(clickValue);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
