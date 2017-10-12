﻿using System;
using System.IO;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using Memory.Properties;


namespace WindowsFormsApp1
{
    [Serializable]
    public class Save
    {
        //-------------------------------------------------------------------------------//
        //Caller write
        public static void SaveData(string player1, string player2, int score1, int score2, string playerbeurt)
        {
            //hier benoem ik path tot de locatie van de .exe
            var path = AppDomain.CurrentDomain.BaseDirectory;

            //omzetten naar bytes
            byte[] serialized = Serialize(player1, player2, score1, score2, playerbeurt);

            //deze bytes writen
            WriteToFile(@"" + path + "Savegames\\game.sav", serialized);

        }

        //Caller read
        public static string LoadData()
        {
            //hier benoem ik path tot de locatie van de .exe
            var path = AppDomain.CurrentDomain.BaseDirectory;

            //het ophalen van de bytes uit de .sav
            byte[] bytes = ReadFromFile(@""+ path + "Savegames\\game.sav");

            //Terugzetten van bytes naar data
            string opslag = Deserialize(bytes);

            //variabelen teruggeven aan button die een label aanpast
            return (opslag);
        }

        //------------------------------------------------------------------------------//
        //Methods
        public static byte[] Serialize(string player1, string player2, int score1, int score2, string playerbeurt)
        {
            //Nieuwe memory stream aanmaken die wordt gebruikt door de formatter
            //De 'using' zorgt er voor dat de memory stream altijd correct wordt afgesloten.
            using (MemoryStream stream = new MemoryStream())
            {
                //Binary formatter die de data serialized, en dit in de stream zet
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, player1);
                formatter.Serialize(stream, player2);
                formatter.Serialize(stream, score1);
                formatter.Serialize(stream, score2);
                formatter.Serialize(stream, playerbeurt);

                //Return
                return stream.ToArray();
            }
        }

        private static string Deserialize(byte[] data)
        {

            //Nieuwe memory stream aanmaken die wordt gebruikt door de formatter
            //De 'using' zorgt er voor dat de memory stream altijd correct wordt afgesloten.
            //De data uit de .sav wordt in de stream gezet
            using (MemoryStream stream = new MemoryStream(data))
            {
                //Binary formatter die de data deserialized, en dit in de stream zet
                BinaryFormatter formatter = new BinaryFormatter();

                //Return de game data.
                var d1 = formatter.Deserialize(stream);
                var d2 = formatter.Deserialize(stream);
                var d3 = formatter.Deserialize(stream);
                var d4 = formatter.Deserialize(stream);
                var d5 = formatter.Deserialize(stream);

                string buf1, buf2, buf3, buf4, buf5, opslag;
                buf1 = Convert.ToString(d1);
                buf2 = Convert.ToString(d2);
                buf3 = Convert.ToString(d3);
                buf4 = Convert.ToString(d4);
                buf5 = Convert.ToString(d5);
                opslag = (buf1 + "\n" + buf2 + "\n" + buf3 + "\n" + buf4 + "\n" + buf5);
                return opslag;
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

       