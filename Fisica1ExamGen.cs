//SVILUPPATO DA SIMONE DOSI (aka dousi96)
//SULLE LISTE DEL PROF. L. RINALDI
/*
Groups of questions before shuffling:
[INFO]:  Group 1:
[INFO]:  v_df_01 v_df_02 s_ec_01 s_ec_03 v_or_04
[INFO]:  s_ec_02 v_or_01 v_df_05 d_2p_05 d_1p_01
[INFO]:  k_di_12 k_in_04 v_rp_01 d_2p_01 v_df_03
[INFO]:  k_in_02 v_rp_16 k_in_05 d_mr_04 d_cn_01
[INFO]:  k_in_03 v_rp_10

[INFO]:  Group 2:
[INFO]:  v_df_04 d_mr_01 v_op_06 v_di_01 k_cr_04
[INFO]:  d_2p_04 v_rp_13 v_di_02 s_rd_08 d_1p_02
[INFO]:  d_cn_12 k_in_01 d_1p_03 k_rp_02 v_di_03
[INFO]:  d_cn_11 d_cn_14 d_cn_03 d_cn_09 v_rp_19
[INFO]:  k_di_14 k_cr_03 d_cn_13 d_cn_02

[INFO]:  Group 3:
[INFO]:  d_cn_10 k_di_16 k_di_02 v_rp_02 d_cn_08
[INFO]:  s_ec_04 k_rp_03 k_rp_01 d_df_02 v_rp_03
[INFO]:  d_cn_07 s_rd_07 s_at_07 d_2p_02 k_di_17
[INFO]:  d_df_04 d_di_17 k_di_09 d_cn_17

[INFO]:  Group 4:
[INFO]:  d_di_15 k_di_07 d_di_19 d_di_21 d_mr_03
[INFO]:  d_di_13 d_di_16 d_df_03 d_di_14 d_di_22
[INFO]:  d_di_23 d_di_24 d_di_06 d_di_26 d_di_25
[INFO]:  k_di_08

Groups of exercises before shuffling:
[INFO]:  Group 1:
[INFO]:  v_op_06 v_op_05 k_pm_20 v_op_17 v_dv_05 v_dv_04 
[INFO]:  k_pm_25 d_pm_29 v_dv_06 k_pm_05 d_si_08 d_pm_28 
[INFO]:  v_dv_01 v_op_01 k_pm_09 k_pm_06 k_pm_04 d_si_09 6 
[INFO]:  d_pm_23 k_pm_24 d_si_04 v_op_04 v_op_07 k_pm_2 
[INFO]:  v_dv_03 d_pm_37 v_dv_09 v_op_18 d_si_05 v_dv_02 
[INFO]:  d_pm_24 v_dv_08 v_dv_07 d_pm_44 d_si_03 v_op_10 
[INFO]:  d_pm_01 s_ec_02 k_pm_21 v_op_08 d_pm_30

[INFO]:  Group 2:
[INFO]:  k_pm_01 d_pm_06 d_si_12 d_si_07 v_op_15 d_cr_20
[INFO]:  s_ec_01 v_op_03 d_pm_43 d_pm_31 v_op_02 d_le_01 
[INFO]:  d_cr_07 d_pm_04 d_pm_16 s_ec_03 d_mi_05 d_mi_06 
[INFO]:  d_pm_08 d_pm_11 d_cr_15 d_pm_12 d_le_03 v_op_14 
[INFO]:  d_cr_16 k_mr_05 k_mr_06 k_pm_18 d_cr_14 d_mi_03  
[INFO]:  d_pm_17 d_pm_09 d_mi_04 d_mi_08 d_mi_07 d_pm_25 
[INFO]:  d_cr_10 d_cr_11 d_si_06 d_pm_18 d_le_02 d_si_10 
[INFO]:  d_pm_15 

[INFO]:  Group 3:
[INFO]:  v_op_11 v_op_09 k_pm_22 v_op_13 d_pm_45 d_si_11 
[INFO]:  d_pm_21 k_pm_08 d_cr_04 k_pm_17 d_si_01 d_cr_12  
[INFO]:  d_cr_04 k_pm_17 d_pm_22
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace TrainFisica1
{
    class Program
    {
        static Dictionary<byte, int> quesitiEstrazioni = new Dictionary<byte, int>();
        static Dictionary<byte, int> eserciziEstrazioni = new Dictionary<byte, int>();

        static byte EstraiDaLista(byte[] lista)
        {
            if (lista == null || lista.Length < 1)
            {
                Console.Error.WriteLine("Errore estrazione da lista! (lista vuota o nulla)");
                return 0;
            }
            Random random = new Random();

            return lista[random.Next(0, lista.Length)];
        }

        static string PrintCompito(byte[] compito, int nQuesiti, int nEsercizi)
        {
            if (compito.Length != nQuesiti + nEsercizi)
            {
                Console.Error.WriteLine("Errore print del compito! (compito.Length != nQues + nEs)");
                return string.Empty;
            }

            string result = string.Empty;
            result = string.Concat(result, "Quesiti:\n");
            for (int i = 0; i < nQuesiti; ++i)
            {
                int estrazioni = 0;
                quesitiEstrazioni.TryGetValue(compito[i], out estrazioni);
                result = string.Concat(result, string.Format("\tq{0}:\t{1}\t(estrazioni:\t{2})\n", i + 1, compito[i], estrazioni));
            }
            result = string.Concat(result, "Esercizi:\n");
            for (int i = 0; i < nEsercizi; ++i)
            {
                int estrazioni = 0;
                eserciziEstrazioni.TryGetValue(compito[nQuesiti + i], out estrazioni);
                result = string.Concat(result, string.Format("\te{0}:\t{1}\t(estrazioni:\t{2})\n", i + 1, compito[nQuesiti + i], estrazioni));
            }
            return result;
        }

        static string PrintStoricoEstrazioni()
        {
            string result = string.Empty;
            result = string.Concat(result, "---------- STORICO ESTRAZIONI ----------\n");
            result = string.Concat(result, "Quesiti:");
            foreach (var keyvalue in quesitiEstrazioni)
            {
                result = string.Concat(result,string.Format("\n\tq{0}\t{1}", keyvalue.Key, keyvalue.Value));
            }
            result = string.Concat(result, "\nEsercizi:");
            foreach (var keyvalue in eserciziEstrazioni)
            {
                result = string.Concat(result, string.Format("\n\te{0}\t{1}", keyvalue.Key, keyvalue.Value));
            }
            result = string.Concat(result, "\n----------------------------------------\n");
            return result;
        }

        static void Main(string[] args)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\storico_estrazioni_f1.txt";
            if (File.Exists(path))
            {
                string fileTxt = File.ReadAllText(path).Trim();
                string[] sezioni = fileTxt.Split("-");
                for (int i = 0; i < 2; ++i)
                {
                    string[] pairs = sezioni[i].Split(",");
                    foreach (string pair in pairs)
                    {
                        string[] keyvalue = pair.Split("|");
                        if (i == 0)
                        {
                            //deserializzazione quesiti - estrazioni
                            quesitiEstrazioni.Add(byte.Parse(keyvalue[0]), int.Parse(keyvalue[1]));
                        }
                        else
                        {
                            //deserializzazione esercizi - estrazioni
                            eserciziEstrazioni.Add(byte.Parse(keyvalue[0]), int.Parse(keyvalue[1]));
                        }
                    }
                }
            }
            Console.WriteLine(PrintStoricoEstrazioni());

            byte[][] quesiti = new byte[][] 
            {
                //gruppo 1
                new byte[] { 1, 2, 3, 5, 7, 10, 12, 14, 15, 23, 24, 25, 26, 33, 37, 38, 39, 47, 50, 53, 56, 57 },
                //gruppo 2
                new byte[] { 4, 6, 11, 13, 16, 17, 18, 20, 22, 27, 28, 34, 42, 48, 49, 52, 54, 58, 59, 62, 64, 65, 66, 67 },
                //gruppo 3
                new byte[] { 8, 9, 19, 21, 29, 32, 35, 36, 40, 41, 43, 44, 46, 51, 60, 61, 63, 68, 73 },
                //gruppo 4
                new byte[] { 30, 31, 45, 55, 69, 70, 71, 72, 74, 75, 76, 77, 78, 79, 80 }
            };

            byte[][] esercizi = new byte[][]
            {
                //gruppo 1
                new byte[] { 1, 4, 5, 6, 7, 8, 10, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29, 30, 32, 35, 36, 38, 39, 44, 46, 59, 60, 62, 63, 64, 66, 68, 71, 72, 73, 76, 77 },
                //gruppo 2
                new byte[] { 2, 3, 14, 15, 27, 34, 41, 42, 43, 45, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 61, 65, 67, 74, 75, 78, 80, 81, 82, 83, 84, 85, 86, 88, 89, 90, 92, 93, 94, 95, 96, 97, 98 },
                //gruppo 3
                new byte[] { 9, 11, 13, 31, 33, 37, 57, 58, 69, 70, 79, 87, 91 }
            };

            #region Check errori liste
            int index = 0;
            foreach (byte[] lista in quesiti)
            {
                System.Collections.Generic.HashSet<byte> set = new System.Collections.Generic.HashSet<byte>(lista);
                for (int j =0; j< quesiti.Length; ++j)
                {
                    if (j != index)
                    {
                        foreach (byte b in quesiti[j])
                        {
                            if (set.Contains(b))
                            {
                                Console.Error.WriteLine(string.Format("Lista quesiti sporca! ({0}-{1}-cod: {2})", index + 1, j + 1, b));
                            }
                        }
                    }
                }
                ++index;
            }
            index = 0;
            foreach (byte[] lista in esercizi)
            {
                System.Collections.Generic.HashSet<byte> set = new System.Collections.Generic.HashSet<byte>(lista);
                for (int j = 0; j < esercizi.Length; ++j)
                {
                    if (j != index)
                    {
                        foreach (byte b in esercizi[j])
                        {
                            if (set.Contains(b))
                            {
                                Console.Error.WriteLine(string.Format("Lista esercizi sporca! ({0}-{1}-cod: {2})", index + 1, j + 1, b));
                            }
                        }
                    }
                }
                ++index;
            }
            #endregion

            index = 1;
            Console.WriteLine("* Benvenuto nel generatore di esercitazioni di Fisica gen. 1 *");
            Console.WriteLine("\tSviluppato da Simone Dosi (aka dousi96)");
            Console.WriteLine("----------------------------------------------------------------");
            //stampo info generali
            Console.WriteLine("\tUltimo aggiornamento: 05-11-2019, Liste del: 24-10-2019");
            Console.WriteLine("----------------------------------------------------------------");
            //stampo info quesiti
            Console.WriteLine(String.Format("\tNumero gruppi quesiti:\t\t{0}", quesiti.Length));
            int totQuesiti = 0;
            foreach (byte[] lista in quesiti)
            {
                Console.WriteLine(String.Format("\tNumero quesiti gruppo {0}:\t{1}", index, lista.Length));
                ++index;
                totQuesiti += lista.Length;
            }
            Console.WriteLine("\t----------------------------------");
            Console.WriteLine(String.Format("\tNumero quesiti totale:\t\t{0}", totQuesiti));
            Console.WriteLine();
            //stampo info esercizi
            index = 1;
            int totEsercizi = 0;
            Console.WriteLine(String.Format("\tNumero gruppi esercizi:\t\t{0}", esercizi.Length));
            foreach (byte[] lista in esercizi)
            {
                Console.WriteLine(String.Format("\tNumero esercizi gruppo {0}:\t{1}", index, lista.Length));
                ++index;
                totEsercizi += lista.Length;
            }
            Console.WriteLine("\t----------------------------------");
            Console.WriteLine(String.Format("\tNumero esercizi totale:\t\t{0}", totEsercizi));
            Console.WriteLine("----------------------------------------------------------------");

            bool exit = false;
            while (!exit)
            {
                byte[] compito = new byte[quesiti.Length + esercizi.Length];
                index = 0;
                //estraggo quesiti
                {                   
                    foreach (byte[] lista in quesiti)
                    {
                        int mediaEstrazioneQuesiti = 0;
                        foreach (byte q in lista)
                        {
                            int numEstrazioni = 0;
                            quesitiEstrazioni.TryGetValue(q, out numEstrazioni);
                            mediaEstrazioneQuesiti += numEstrazioni;
                        }
                        mediaEstrazioneQuesiti /= lista.Length;

                        int estrazioniQuesito = 0;
                        byte quesito = 0;
                        do
                        {
                            quesito = EstraiDaLista(lista);
                            quesitiEstrazioni.TryGetValue(quesito, out estrazioniQuesito);
                        }
                        while (estrazioniQuesito > mediaEstrazioneQuesiti);

                        if (quesitiEstrazioni.ContainsKey(quesito))
                        {
                            quesitiEstrazioni[quesito] = quesitiEstrazioni[quesito] + 1;
                        }
                        else
                        {
                            quesitiEstrazioni.Add(quesito, 1);
                        }

                        compito[index] = quesito;
                        ++index;
                    }
                }
                //estraggo esercizi
                {
                    foreach (byte[] lista in esercizi)
                    {
                        int mediaEstrazioneEsercizi = 0;
                        foreach (byte q in lista)
                        {
                            int numEstrazioni = 0;
                            eserciziEstrazioni.TryGetValue(q, out numEstrazioni);
                            mediaEstrazioneEsercizi += numEstrazioni;
                        }
                        mediaEstrazioneEsercizi /= lista.Length;

                        int estrazioniEsercizio = 0;
                        byte esercizio = 0;
                        do
                        {
                            esercizio = EstraiDaLista(lista);
                            eserciziEstrazioni.TryGetValue(esercizio, out estrazioniEsercizio);
                        }
                        while (estrazioniEsercizio > mediaEstrazioneEsercizi);

                        if (eserciziEstrazioni.ContainsKey(esercizio))
                        {
                            eserciziEstrazioni[esercizio] = eserciziEstrazioni[esercizio] + 1;
                        }
                        else
                        {
                            eserciziEstrazioni.Add(esercizio, 1);
                        }

                        compito[index] = esercizio;
                        ++index;
                    }
                }

                Console.WriteLine(PrintCompito(compito, quesiti.Length, esercizi.Length));
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Inserisci 'esc' per uscire o un altro tasto per generare un nuovo test");
                exit = Console.ReadLine().ToLower().Equals("esc");
            }
        }
    }
}
