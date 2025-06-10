using UnityEngine;

public class alvomaissegundos : MonoBehaviour

{
    public float tempoParaAdicionar = 5f;  // Quantidade de tempo a ser adicionada ao cronômetro
    public contagemR1 cronometro;  // Referência ao script de cronômetro

    // Ao clicar no objeto
    void OnMouseDown()
    {
        if (cronometro != null)
        {
            // Adiciona o tempo ao cronômetro
            cronometro.AdicionarTempo(tempoParaAdicionar);

            // Você pode também adicionar uma reação visual, como destruindo o alvo ou tocando um som
            Destroy(gameObject);  // Destrói o objeto alvo após o clique
        }
    }

}
