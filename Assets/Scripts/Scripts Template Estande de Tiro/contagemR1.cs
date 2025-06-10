using UnityEngine;
using TMPro;

public class contagemR1 : MonoBehaviour
{
    private bool isTimerActive = true;  // Controle para saber se o cronômetro está rodando
    public KeyCode restartKey = KeyCode.R;  // Tecla para reiniciar (padrão "R")
    public GameObject objectToDeactivate;  // Objeto a ser desativado quando o tempo acabar
    public int contagem = 60;  // Tempo inicial do cronômetro (em segundos)
    public TextMeshProUGUI textocontagem;  // Referência ao componente TextMeshPro para exibir o tempo
    private float currenTime;  // Tempo restante no cronômetro
    public contagemR1 cronometro;
    // Start é chamado uma vez antes da primeira execução de Update
    void Start()
    {
        currenTime = contagem;  // Inicializa o cronômetro com o valor de contagem
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Checa se a tecla de reinício foi pressionada
        if (Input.GetKeyDown(restartKey))
        {
            RestartProcess();
        }

        // Se o cronômetro está ativo
        if (isTimerActive)
        {
            // Decrementa o cronômetro a cada frame
            if (currenTime > 0)
            {
                currenTime -= Time.deltaTime;
                textocontagem.text = Mathf.CeilToInt(currenTime).ToString();  // Atualiza o texto com o tempo restante
            }
            else
            {
                textocontagem.text = "0";  // Exibe 0 quando o cronômetro chega a zero
                objectToDeactivate.SetActive(false);  // Desativa o objeto
                isTimerActive = false;  // Para o cronômetro
            }
        }
    }

    // Função para adicionar tempo ao cronômetro
    public void AdicionarTempo(float tempo)
    {
        // Adiciona o tempo especificado ao cronômetro
        currenTime += tempo;

        // Garante que o cronômetro não seja negativo (se o tempo adicional for negativo)
        currenTime = Mathf.Max(currenTime, 0);

        // Atualiza o texto para refletir o tempo novo
        textocontagem.text = Mathf.CeilToInt(currenTime).ToString();
    }

    // Função para reiniciar o cronômetro e reativar o objeto
    void RestartProcess()
    {
        currenTime = contagem;  // Reinicia o cronômetro com o valor original
        objectToDeactivate.SetActive(true);  // Reativa o objeto
        isTimerActive = true;  // Reinicia o cronômetro
        textocontagem.text = Mathf.CeilToInt(currenTime).ToString();  // Atualiza o texto para refletir o tempo inicial
    }
}
