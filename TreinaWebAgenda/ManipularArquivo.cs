using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TreinaWebAgenda.Entidades;


namespace TreinaWebAgenda
{
    public class ManipularArquivo
    {
        private static string enderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "contato.txt";

        public static List<Contato> LerArquivo()
        {
            List<Contato> contatos = new List<Contato>();

            if (!File.Exists(@enderecoArquivo))
            {
                throw new Exception("O arquivo não existe");
            }

            using(StreamReader sr = File.OpenText(enderecoArquivo))
            {
                while(sr.Peek() >= 0)
                {
                    string linha = sr.ReadLine();
                    string[] splitLinha = linha.Split(',');

                    if(splitLinha.Count() == 3)
                    {
                        Contato contato = new Contato();
                        contato.Nome = splitLinha[0];
                        contato.Telefone = splitLinha[1];
                        contato.Email = splitLinha[2];
                        contatos.Add(contato);
                    }

                }
            }

            return contatos;
        }

        public static void EscreverArquivo(List<Contato> contatoList)
        {
            using (StreamWriter sw = new StreamWriter(enderecoArquivo, false))
            {
                foreach (var contato in contatoList)
                {
                    string linha = string.Format("{0},{1},{2}", contato.Nome, contato.Telefone, contato.Email);
                    sw.WriteLine(linha);
                }

                sw.Flush(); //limpa a memória

            }



        }

    }
}
