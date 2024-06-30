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

        var file = File.CreateText(path);

        file.WriteLine("Lingua:");
        file.WriteLine((int)data.lingua);
        //file.WriteLine("Volume:");
        //file.WriteLine(data.volume.ToString());
        file.WriteLine("Fases:");
        file.WriteLine(data.progrecao[0]);
        file.WriteLine(data.progrecao[1]);

        file.Close();
    }

    public static void Load(SaveData data)
    {
        if (File.Exists(path))
        {
            var file = new StreamReader(path);
            string linha, s = "";
            int c = 0;

            while((linha = file.ReadLine()) != null)
            {
                switch(linha)
                {
                    case "Lingua:":
                        s = linha;
                        break;
                   /* case "Volume:":
                        s = linha;
                        break;*/
                    case "Fases:":
                        s = linha;
                        break;
                    default:
                        switch(s)
                        {
                            case "Lingua:":
                                data.lingua = (Seletor_Linguagem.Linguagem)int.Parse(linha);
                                break;
                            /*case "Volume:":
                                data.volume = float.Parse(linha);
                                break;*/
                            case "Fases:":
                                if (c <= 1)
                                {
                                    data.progrecao[c] = bool.Parse(linha);
                                    c++;
                                }
                                break;
                        }
                        break;
                }
            }

            file.Close();

            data.Insert();
        }
    }

}
