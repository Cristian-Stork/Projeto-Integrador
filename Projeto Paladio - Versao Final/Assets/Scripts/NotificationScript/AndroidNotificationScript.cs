using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class AndroidNotificationScript : MonoBehaviour
{
    //Autorização
    public void RequestAutorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Criar canal para notificação
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
        "Atenção!", "Veja!", "Fique de olho!", "Preste atenção!", "Não pisque!","Ligue o radar!", "Acorde!"
    };
    private List<string> texts = new List<string>
    {
        "Temos o primeiro bebê nascido na colônia de Marte!", "Faça backup de suas memórias agora mesmo! Afinal, quem precisa de experiências reais?", "A taxa de mortalidade infantil diminuiu drasticamente, agora que não há mais novos hospitais!", "Viva a meritocracia! Se você está vivo, já ganhou na loteria da vida.",
        "O mercado imobiliário está aquecido! Venda seu abrigo nuclear por um preço incrível!", "Novas vagas abertas! Procura-se catadores de lixo com experiência em combate!", "Inscreva-se em nosso programa de fidelidade e ganhe pontos para trocar por água potável!",
        "Atualize seu sistema imunológico! Novas mutações disponíveis agora mesmo!",""
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

    // Método para enviar duas notificações
    public void SendTwoRandomNotifications(int fireTimeHours)
    {
        if (titles.Count == 0 || texts.Count < 2)
        {
            Debug.LogWarning("Não há títulos ou textos suficientes para enviar notificações.");
            return;
        }

        // Seleciona e remove o primeiro texto
        int titleIndex1 = Random.Range(0, titles.Count);
        string title1 = titles[titleIndex1];

        int textIndex1 = Random.Range(0, texts.Count);
        string text1 = texts[textIndex1];
        SendNotification(title1, text1, fireTimeHours);
        texts.RemoveAt(textIndex1);

        // Atualiza a lista para o segundo título e texto
        int titleIndex2 = Random.Range(0, titles.Count);
        string title2 = titles[titleIndex2];

        int textIndex2 = Random.Range(0, texts.Count);
        string text2 = texts[textIndex2];
        SendNotification(title2, text2, fireTimeHours);
        texts.RemoveAt(textIndex2);
    }
}