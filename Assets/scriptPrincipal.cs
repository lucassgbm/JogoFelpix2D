using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptPrincipal : MonoBehaviour {

    public GameObject objetosCanos;
    public Text textoPontuacao;
    public Text textoMensagem;

    int pontuacao;
    public bool terminouJogo;

	// Use this for initialization
	void Start () {
        textoPontuacao.gameObject.SetActive(false);
        textoMensagem.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1") && terminouJogo)
        {

            Application.LoadLevel("cenaJogoFelpix");
        }
	}

    public void ComecouJogo()
    {
        InvokeRepeating("CriaCanos", 0f, 1.5f);
        textoPontuacao.gameObject.SetActive(true);
        textoMensagem.gameObject.SetActive(false);
    }

    public void CriaCanos()
    {
        float randomPos = (3.0f * Random.value) - 1.5f;
        GameObject cano = Instantiate(objetosCanos);
        cano.transform.localScale = new Vector3(1.65f, 1.65f, 1.65f);
        cano.transform.position = new Vector3(10, randomPos, 0);
    }

    public void marcaPonto()
    {
        pontuacao++;
        textoPontuacao.text = pontuacao.ToString();
    }

    public void FimDeJogo()
    {
        CancelInvoke("CriaCanos");
        foreach (GameObject objeto in GameObject.FindGameObjectsWithTag("ImagemFundo"))
        {
            objeto.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        foreach (GameObject objeto in GameObject.FindGameObjectsWithTag("AreaVao"))
        {
            objeto.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        Invoke("setLabelsFinais", 2);
    }

    void setLabelsFinais()
    {
        textoMensagem.gameObject.SetActive(true);
        textoMensagem.text = "Toque para reiniciar..";
        textoMensagem.color = new Color(0.15f, 0.35f, 0.55f, 1);
        terminouJogo = true;
    }
}
