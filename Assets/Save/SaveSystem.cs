using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/save.txt";

    public static void Save(SaveData data)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }

    }


    /*public static void Load(SaveData data)
    {
        if (File.Exists(path))
        {
            var file = new StreamReader(path);
            string linha;
            int c = 0;

            while((linha = file.ReadLine()) != null)
            {
                if(linha == "Lingua:")
                {
                    c = 1;
                }
                else if (c > 0)
                {
                    data.lingua = (Seletor_Linguagem.Linguagem)int.Parse(linha);
                    c--;
                }
            }

            file.Close();
        }
    }*/
}
