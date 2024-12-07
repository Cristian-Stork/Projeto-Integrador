using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class AndroidNotificationScript : MonoBehaviour
{
    //Autoriza��o
    public void RequestAutorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Criar canal para notifica��o
    public void RegisterNotificationChannel()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

    }

    private List<string> titles = new List<string>
    {
        "Aten��o!", "Veja!", "Fique de olho!", "Preste aten��o!", "N�o pisque!","Ligue o radar!", "Acorde!"
    };
    private List<string> texts = new List<string>
    {
        "Temos o primeiro beb� nascido na col�nia de Marte!", "Fa�a backup de suas mem�rias agora mesmo! Afinal, quem precisa de experi�ncias reais?", "A taxa de mortalidade infantil diminuiu drasticamente, agora que n�o h� mais novos hospitais!", "Viva a meritocracia! Se voc� est� vivo, j� ganhou na loteria da vida.",
        "O mercado imobili�rio est� aquecido! Venda seu abrigo nuclear por um pre�o incr�vel!", "Novas vagas abertas! Procura-se catadores de lixo com experi�ncia em combate!", "Inscreva-se em nosso programa de fidelidade e ganhe pontos para trocar por �gua pot�vel!",
        "Atualize seu sistema imunol�gico! Novas muta��es dispon�veis agora mesmo!",""
    };
    //private List<string> icons = new List<string> { "porco", "porco1"};



    //template
    public void SendNotification(string title, string text, int fireTimeHours)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Now.AddSeconds(fireTimeHours),
            //SmallIcon = icons[Random.Range(0, icons.Count)]
        };

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    // M�todo para enviar duas notifica��es
    public void SendTwoRandomNotifications(int fireTimeHours)
    {
        if (titles.Count == 0 || texts.Count < 2)
        {
            Debug.LogWarning("N�o h� t�tulos ou textos suficientes para enviar notifica��es.");
            return;
        }

        // Seleciona e remove o primeiro texto
        int titleIndex1 = Random.Range(0, titles.Count);
        string title1 = titles[titleIndex1];

        int textIndex1 = Random.Range(0, texts.Count);
        string text1 = texts[textIndex1];
        SendNotification(title1, text1, fireTimeHours);
        texts.RemoveAt(textIndex1);

        // Atualiza a lista para o segundo t�tulo e texto
        int titleIndex2 = Random.Range(0, titles.Count);
        string title2 = titles[titleIndex2];

        int textIndex2 = Random.Range(0, texts.Count);
        string text2 = texts[textIndex2];
        SendNotification(title2, text2, fireTimeHours);
        texts.RemoveAt(textIndex2);
    }
}