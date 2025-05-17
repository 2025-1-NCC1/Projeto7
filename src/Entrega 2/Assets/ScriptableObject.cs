using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuickEvent", menuName = "Quick Event")]
public class QuickEvent : ScriptableObject
{
    public int respostaCorretaIndex;
    public string question;
    public string[] options = new string[3];
    public UnityEngine.Events.UnityEvent[] onOptionSelected = new UnityEngine.Events.UnityEvent[3];
}
public static class DadosDoJogo
{
    public static List<string> nomesRanking = new List<string>();
    public static List<float> energiaRanking = new List<float>();
}

