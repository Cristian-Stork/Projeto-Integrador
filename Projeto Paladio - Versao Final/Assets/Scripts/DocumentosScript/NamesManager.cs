using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class NamesManager : MonoBehaviour
{

    //public List<string> nomeM = new List<string>();
    //public List<string> nomeF = new List<string>();
    //public List<string> sobrenomeL = new List<string>();


    public NamesDatas names = new NamesDatas();

    public void LoadNames(TextAsset jsonFile)
    {
        Debug.LogError("jsonFile = " +  jsonFile);

        if (jsonFile == null)
        {
            Debug.LogError("JSON file is null. Check if the file is assigned in the Inspector.");
            return;
        }

        Debug.Log($"JSON Content: {jsonFile.text}"); // Mostra o conteúdo do JSON


        // Usa JsonUtility para converter o JSON em um objeto CartasData
        NamesData data = JsonUtility.FromJson<NamesData>(jsonFile.text);

        if (data == null)
        {
            Debug.LogError("No cards loaded from the JSON file. Please check the file format.");
            return;
        }

        //names = data.sobrenomes;

        //names.AddRange(data.names);  // Adiciona as cartas carregadas à lista
        //Shuffle();  // Embaralha as cartas após carregar
        Debug.Log($"Loaded {data} cards.");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class NamesDatas
{
    public List<string> femininos;
    public List<string> masculinos;
    public List<string> sobrenomes;
}
