using UnityEngine;
using TMPro;  // Certifique-se de importar a biblioteca TextMeshPro

public class ContadorDePonto : MonoBehaviour
{
    // Variável estática para outros scripts terem acesso a este script
    public static ContadorDePonto Instance;

    // Referência ao texto que será alterado (Pontuação)
    public TMP_Text Texto_Output;

    // Variável pontuação do jogador
    public int Pontuacao;

    // Chamado 1 vez ao inicializar a cena
    void Start()
    {
        // Checa se já existe um objeto ContadorDePonto 
        // Caso não tenha...
        if (Instance == null)
        {
            // Define este objeto como Instance
            Instance = this;
        }
        // Caso já tenha...
        else
        {
            // Destroi este objeto para evitar duplicatas
            Destroy(gameObject);
        }

        // Define a pontuação inicial para 0
        Pontuacao = 0;

        // Atualiza o texto para a pontuação atual
        Texto_Output.text = Pontuacao.ToString();
    }

    // Função para adicionar ou remover pontos 
    // (pede o valor para adicionar ou subtrair da pontuação atual)
    public void AdicionarPontos(int quantidadeDePontos)
    {
        // Adiciona ou subtrai a quantidadeDePontos da Pontuação atual
        Pontuacao += quantidadeDePontos;

        // Atualiza o texto para a pontuação atual
        Texto_Output.text = Pontuacao.ToString();
    }

    // Função para resetar a pontuação
    public void ResetarPontuacao()
    {
        Pontuacao = 0;  // Reseta a pontuação para 0
        Texto_Output.text = Pontuacao.ToString();  // Atualiza o texto para refletir a pontuação resetada
    }

    // Update é chamado uma vez por quadro
    void Update()
    {
        // Checa se a tecla R foi pressionada para resetar a pontuação
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetarPontuacao();  // Chama a função para resetar a pontuação
        }
    }
}
