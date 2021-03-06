﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Memory
{
    /// <summary>
    /// het opslaan van welk thema er is geselecteerd, zodat deze bij elke game ingeladen kan worden
    /// het slaat 1 string op, zonder encryptie
    /// </summary>
    class SettingsPage_Save
    {
        public static void SaveData(string thema)
        {
            //hier benoem ik path tot de locatie van de .exe
            var path = AppDomain.CurrentDomain.BaseDirectory;

            //omzetten naar bytes
            byte[] serialized = Serialize(thema);

            //deze bytes writen
            WriteToFile(@"" + path + "settings.ini", serialized);

        }

        public static string LoadData()
        {
            //hier benoem ik path tot de locatie van de .exe
            var path = AppDomain.CurrentDomain.BaseDirectory;

            //het ophalen van de bytes uit de .sav
            byte[] bytes = ReadFromFile(@"" + path + "settings.ini");

            //Terugzetten van bytes naar data
            string opslag = Deserialize(bytes);

            //variabelen teruggeven aan button die een label aanpast
            if (opslag == "Er is nog geen\nsave file\naanwezig")
            {
                opslag = "media";
            }
            return (opslag);
        }






        public static byte[] Serialize(string thema)
        {
            //Nieuwe memory stream aanmaken die wordt gebruikt door de formatter
            //De 'using' zorgt er voor dat de memory stream altijd correct wordt afgesloten.
            using (MemoryStream stream = new MemoryStream())
            {
                //Binary formatter die de data serialized, en dit in de stream zet
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, thema);

                //Return
                return stream.ToArray();
            }
        }

        private static string Deserialize(byte[] data)
        {
            string buf1, opslag = "";

            //Nieuwe memory stream aanmaken die wordt gebruikt door de formatter
            //De 'using' zorgt er voor dat de memory stream altijd correct wordt afgesloten.
            //De data uit de .sav wordt in de stream gezet
            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    //Binary formatter die de data deserialized, en dit in de stream zet
                    BinaryFormatter formatter = new BinaryFormatter();

                    //Return de game data.
                    var d1 = formatter.Deserialize(stream);

                    buf1 = Convert.ToString(d1);

                    opslag = buf1;

                    return opslag;
                }
            }
            catch (ArgumentNullException)
            {
                string message = "Er is nog geen\nsave file\naanwezig";
                return message;
            }
        }

        private static void WriteToFile(string file, byte[] data)
        {
            //Try catch block om eventuele errors af te vangen.
            try
            {
                //Schrijf all bytes naar het opgegeven path.
                File.WriteAllBytes(file, data);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not write file due: " + e.Message);
            }
        }

        private static byte[] ReadFromFile(string file)
        {
            //Try catch block om eventuele errors af te vangen.
            try
            {
                //Alle bytes uitlezen uit een bestand en deze returnen.
                byte[] bytes = File.ReadAllBytes(file);
                return bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not read file due: " + e.Message);
            }

            return null;
        }
    }
}
