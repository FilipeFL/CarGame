using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public bool pause = true, ataque = false, vitoria = false;
    
    public GameObject Player, Rua1, Rua2, GameOverUI, GameAccomplishedUI ,Torreta_PolicialPrefab, TorretaDupla_PolicialPrefab, NitroPrefab, Mega_FonePrefab, Ferramenta_ConsertoPrefab, Caixa_SomPrefab, Carro_Policia_GrandePrefab, Carro_Policia_SimplesPrefab, NPCPrefab, Monumento_Arco_Iris, Estatua_Olho, Predio_QG, Boss;

    public Text HighscoreUI, VidaUI, AtoUI, AtaqueEspecialUI, Conquista_1, Conquista_2;

    public int Highscore = 0, Vida = 3, Ato = 1;

    private float[] TemposInimigoMovel = { 1f, 2f, 3.6f };
    private float[] TemposInimigoFixo = { 3.2f, 3.5f, 3.6f, 4.2f };
    private float[] TemposColetavel = { 5f};

    private float[] LocalNasceInimigoGrande = { -8.56f, -6.64f, -0.93f, 4.33f, 8.42f };
    private float[] LocalNasceInimigoSimples = { -6.39f, -4.59f, -2.78f, 1.01f, 2.49f, 6.39f };
    private float[] LocalNasceInimigoFixo = { -6.64f, -0.93f, 4.33f, 8.42f, -4.59f, -2.78f, 1.01f, 2.49f, 6.39f };
    private float[] LocalNasceColetavel = { -9f, -9.5f, -8f, -8.5f, -7f, -7.5f, -6f, -6.5f, -5f, -5.5f, -4f, -4.5f, -3f, -3.5f, -2f, -2.5f, -1f, -1.5f, 0f, 9f, 9.5f, 8f, 8.5f, 7f, 7.5f, 6f, 6.5f, 5f, 5.5f, 4f, 4.5f, 3f, 3.5f, 2f, 2.5f, 1f, 1.5f };

    private ControladorUI Controlador_UI;

    // As trilhas que são constantes no jogo são adicionadas no script do controlador para que se tenham uma constancia ao decorrer do jogo.

    public AudioSource TrilhaJogo_Ato1, TrilhaJogo_Ato2, TrilhaJogo_Ato3, TrilhaDerrota, TrilhaVitoria, Traffic;

    public int contador_nitro = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnInimigoFixo());
        StartCoroutine(SpawnInimigoMovel());
        StartCoroutine(SpawnColetavel());
 
        Controlador_UI = GameObject.Find("ControladorUI").GetComponent<ControladorUI>();
    }

    // Update is called once per frame
    void Update()
    {

        AtualizarHighscore();
        AtualizarVida();
        AtualizarAto();
        AtualizarAtaqueEspecial();
        AtualizarConquista1();
        AtualizarConquista2();

        if (Vida == 0)
        {
            GameOver();
        }

        if(pause == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void AtualizarHighscore()
    {
        HighscoreUI.text = "Highscore" + "\n" + Highscore;
    }

    void AtualizarVida()
    {
        VidaUI.text = "Life " + Vida;
    }

    void AtualizarAto()
    {
        AtoUI.text = "Act " + Ato;
    }

    void AtualizarAtaqueEspecial()
    {
        if (ataque == true)
        {
            AtaqueEspecialUI.text = "Ataque" + "\n" + "Habilitado";
        }
        else
        {
            AtaqueEspecialUI.text = "";
        }
    }

    void AtualizarConquista1()
    {
        if (vitoria == true)
        {
            Conquista_1.text = "Tudo" + "\n" + "Asfaltado";
        }
        else
        {
            Conquista_1.text = "";
        }
    }

    void AtualizarConquista2()
    {
        if (contador_nitro == 10)
        {
            Conquista_2.text = "Turbinado!";
        }
        else
        {
            Conquista_2.text = "";
        }
    }

    //Se a função de Game Over for chamada, então os áudios de gameplay serão parados e o áudio de derrota iniciará.
    public void GameOver()
    {
        Highscore = 0;
        Vida = 3;
        GameOverUI.GetComponent<Image>().enabled = true;
        Player.transform.GetChild(0).gameObject.SetActive(false);
        Player.GetComponent<Player>().ativo = false;
        TrilhaDerrota.Play();
        TrilhaJogo_Ato1.Stop();
        TrilhaJogo_Ato2.Stop();
        TrilhaJogo_Ato3.Stop();
        Traffic.Stop();

        StartCoroutine(Reiniciar());
    }

    //Se o jogador vencer o jogo, as trilhas de gameplay ativas terão que parar e será dado início a trilha de vitória
    public void GameAccomplished()
    {
        Highscore = 0;
        Vida = 3;
        GameAccomplishedUI.GetComponent<Image>().enabled = true;
        Player.transform.GetChild(0).gameObject.SetActive(false);
        Player.GetComponent<Player>().ativo = false;
        TrilhaJogo_Ato3.Stop();
        Traffic.Stop();
        TrilhaVitoria.Play();
        vitoria = true;

        StartCoroutine(Reiniciar());
    }

    //Se o jogo for reiniciado, todos os áudio serão restaurados a sua mesma natureza ao início do jogo 
    public IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(3);

        ShowCredits();

        pause = true;
        GameOverUI.GetComponent<Image>().enabled = false;
        GameAccomplishedUI.GetComponent<Image>().enabled = false;
        Player.transform.GetChild(0).gameObject.SetActive(true);
        Player.GetComponent<Player>().ativo = true;
        Player.GetComponent<Player>().ato_1 = true;
        Player.GetComponent<Player>().ato_3 = false;
        Player.GetComponent<Player>().ato_3 = false;
        Player.transform.position = new Vector3(0, 0, 0);
        Player.transform.GetChild(0).transform.position = new Vector3(0, 0.6f, -2.4f);
        Boss.transform.position = new Vector3(0, 0, 1508.1f);
        Boss.transform.GetChild(0).gameObject.SetActive(true);
        Boss.transform.position = new Vector3(0, 0, 1508.1f);
        Rua1.transform.position = new Vector3(0, 0, 5);
        Rua2.transform.position = new Vector3(0, 0, 25);
        Player.transform.GetChild(2).GetComponent<Detectar_Rua>().primeiro = true;
        Highscore = 0;
        Vida = 3;
        Ato = 1;
        Controlador_UI.jogo_ativo = false;
        Monumento_Arco_Iris.transform.gameObject.SetActive(true);
        Estatua_Olho.transform.gameObject.SetActive(true);
        Predio_QG.transform.gameObject.SetActive(true);
        Boss.transform.GetComponent<Boss>().AudioEngineBoss.Stop();
        Boss.transform.GetComponent<Boss>().AudioSiren.Stop();

        LimparInimigos();
        LimparColetaveis();
        LimparBoss();
    }

    //A trilha de créditos e ativada se os créditos forem acionados.
    public void ShowCredits()
    {
        Controlador_UI.TelaCreditos.SetActive(true);
        pause = true;
        TrilhaDerrota.Stop();
        TrilhaVitoria.Stop();
        Controlador_UI.TrilhaCreditos.Play();
    }

    public void LimparInimigos()
    {
        GameObject[] inimigosFixos, inimigosMoveis;

        inimigosFixos = GameObject.FindGameObjectsWithTag("InimigoFixo");
        inimigosMoveis = GameObject.FindGameObjectsWithTag("InimigoMovel");

        foreach(GameObject InimigoFixo in inimigosFixos)
        {
            Destroy(InimigoFixo.gameObject);
        }

        foreach(GameObject InimigoMovel in inimigosMoveis)
        {
            Destroy(InimigoMovel.gameObject);
        }
    }

    public void LimparColetaveis()
    {
        GameObject[] coletaveis;

        coletaveis = GameObject.FindGameObjectsWithTag("Coletavel");

        foreach(GameObject Coletavel in coletaveis)
        {
            Destroy(Coletavel.gameObject);
        }
    }

    public void LimparBoss()
    {
        GameObject[] boss;

        boss = GameObject.FindGameObjectsWithTag("Boss");

        foreach(GameObject Boss in boss)
        {
            Destroy(Boss.gameObject);
        }
    }

    public IEnumerator SpawnInimigoFixo()
    {
        yield return new WaitForSeconds(TemposInimigoFixo[Random.Range(0, TemposInimigoFixo.Length)]);

        Instantiate(Torreta_PolicialPrefab, new Vector3(LocalNasceInimigoFixo[Random.Range(0, LocalNasceInimigoFixo.Length)], 0.6f, Player.transform.position.z + 18.5f), Torreta_PolicialPrefab.transform.rotation);
        Instantiate(TorretaDupla_PolicialPrefab, new Vector3(LocalNasceInimigoFixo[Random.Range(0, LocalNasceInimigoFixo.Length)], 0.6f, Player.transform.position.z + 18.5f), Torreta_PolicialPrefab.transform.rotation);

        StartCoroutine(SpawnInimigoFixo());
    }

    public IEnumerator SpawnInimigoMovel()
    {
        yield return new WaitForSeconds(TemposInimigoMovel[Random.Range(0, TemposInimigoMovel.Length)]);

        Instantiate(Carro_Policia_GrandePrefab, new Vector3(LocalNasceInimigoGrande[Random.Range(0, LocalNasceInimigoGrande.Length)], 0.85f, Player.transform.position.z + 18.5f), Carro_Policia_GrandePrefab.transform.rotation);
        Instantiate(Carro_Policia_SimplesPrefab, new Vector3(LocalNasceInimigoSimples[Random.Range(0, LocalNasceInimigoSimples.Length)], 0.58f, Player.transform.position.z + 18.5f), Carro_Policia_SimplesPrefab.transform.rotation);

        StartCoroutine(SpawnInimigoMovel());
    }

    public IEnumerator SpawnColetavel()
    {
        yield return new WaitForSeconds(TemposColetavel[Random.Range(0, TemposColetavel.Length)]);

        Instantiate(NitroPrefab, new Vector3(LocalNasceColetavel[Random.Range(0, LocalNasceColetavel.Length)], 0.68f, Player.transform.position.z + 18.5f), NitroPrefab.transform.rotation);
        Instantiate(Mega_FonePrefab, new Vector3(LocalNasceColetavel[Random.Range(0, LocalNasceColetavel.Length)], 0.7f, Player.transform.position.z + 18.5f), Mega_FonePrefab.transform.rotation);
        Instantiate(Ferramenta_ConsertoPrefab, new Vector3(LocalNasceColetavel[Random.Range(0, LocalNasceColetavel.Length)], 0.7f, Player.transform.position.z + 18.5f), Ferramenta_ConsertoPrefab.transform.rotation);
        Instantiate(Caixa_SomPrefab, new Vector3(LocalNasceColetavel[Random.Range(0, LocalNasceColetavel.Length)], 0.58f, Player.transform.position.z + 18.5f), Caixa_SomPrefab.transform.rotation);

        StartCoroutine(SpawnColetavel());
    }

    //Funções feitas para rapidez em iniciar ou pausar uma trilha de gameplay.

    public void TocarTrilhaAto1()
    {
        TrilhaJogo_Ato1.Play();
    }

    public void PausarTrilhaAto1()
    {
        TrilhaJogo_Ato1.Stop();
    }

    public void TocarTrilhaAto2()
    {
        TrilhaJogo_Ato2.Play();
    }

    public void PausarTrilhaAto2()
    {
        TrilhaJogo_Ato2.Stop();
    }

    public void TocarTrilhaAto3()
    {
        TrilhaJogo_Ato3.Play();
    }

    public void PausarTrilhaAto3()
    {
        TrilhaJogo_Ato3.Stop();
    }

    public void TocarTraffic()
    {
        Traffic.Play();
    }

    public void PausarTraffic()
    {
        Traffic.Stop();
    }
}
