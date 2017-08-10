using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Concatenador.Util
{
    public class Utilities
    {

        // Cria uma pasta com nome da data atual em um diretório
        // e retorna o caminho completo
        public static string CriaDiretorio(string diretorioBase)
        {
            if (!String.IsNullOrEmpty(diretorioBase))
            {
                if (Directory.Exists(diretorioBase))
                {
                    string date = DateTime.Now.Date.ToShortDateString().Replace("/", "");
                    if (!Directory.Exists(diretorioBase + '\\' + date))
                       Directory.CreateDirectory(diretorioBase + '\\' + date);

                    return diretorioBase + '\\' + date;
                }
            }

            return null;
        }

        // Cria uma pasta com nome conforme parâmetro recebido em um diretório
        // e retorna o caminho completo
        public static string CriaDiretorio(string diretorioBase, string novaPasta)
        {
            if (!String.IsNullOrEmpty(diretorioBase))
            {
                if (Directory.Exists(diretorioBase))
                {
                    if (!Directory.Exists(diretorioBase + '\\' + novaPasta))
                        Directory.CreateDirectory(diretorioBase + '\\' + novaPasta);

                    return diretorioBase + '\\' + DateTime.Now.Date;
                }
            }

            return null;
        }

        // Retorna uma lista de arquivos em um diretório
        // com uma extensão definida
        public static List<string> PegaArquivosPorExtensao(string diretorio, string extensao)
        {
            string[] arquivos = Directory.GetFiles(diretorio);
            List<string> arquivosFinal = new List<string>();

            foreach (string file in arquivos)
            {
                FileInfo arquivo = new FileInfo(file);

                if (arquivo.Extension.Substring(1, extensao.Length).Equals(extensao))
                {
                    arquivosFinal.Add(arquivo.FullName);
                }
            }

            return arquivosFinal;
        }

        // Move todos arquivos com uma extensão
        // para outro diretório
        public static void MoveArquivosPorExtensao(string diretorio, string destino, string extensao)
        {
            string[] arquivos = Directory.GetFiles(diretorio);

            foreach (string file in arquivos)
            {
                FileInfo arquivo = new FileInfo(file);

                if (arquivo.Extension.Substring(1, extensao.Length).Equals(extensao))
                {
                    File.Move(arquivo.FullName, destino + '\\' + arquivo.Name);
                }
            }
        }

        // Retorna uma string com todos os dados dos arquivos RM
        public static string ConcatenaInformacao(List<string> arquivosRM)
        {
            int numLinhas = 2;

            StringBuilder sb = new StringBuilder();

            foreach (string arquivo in arquivosRM)
            {
                string[] linhas = File.ReadAllLines(arquivo);

                // Descarta o cabeçalho e a última linha
                for (int i = 1; i < linhas.Length - 1; i++)
                {
                    string linhaNumCor = linhas[i].Substring(0, linhas[i].Length - 6);
                    linhaNumCor += numLinhas.ToString().PadLeft(6, '0');
                    numLinhas++;
                    sb.AppendLine(linhaNumCor);
                }
            }

            return sb.ToString();
        }

        // Importa os dados exportados dos arquivos RM
        // para o arquivo CRM final
        public static void ImportaDados(string final, List<string> arquivoCRM)
        {
            string finalText = "";

            foreach (string arquivo in arquivoCRM)
            {
                StringBuilder sb = new StringBuilder();
                string[] linhas = File.ReadAllLines(arquivo);

                int numLinhas = 0;
                // Descarta o cabeçalho e a última linha
                for (int i = 0; i < linhas.Length; i++)
                {
                    if (i == 1 && !String.IsNullOrEmpty(final))
                    {
                        sb.Append(final);
                        numLinhas = Int32.Parse(final.Substring(final.Length - 6));
                    }

                    numLinhas++;
                    string linhaNumCor = linhas[i].Substring(0, linhas[i].Length - 6);
                    linhaNumCor += numLinhas.ToString().PadLeft(6, '0');
                    sb.AppendLine(linhaNumCor);
                }
                finalText = sb.ToString();

                linhas = finalText.Split('\n');
                sb.Clear();
                for (int i  = 0; i < linhas.Length - 2; i++)
                {
                    if (i % 2 != 0)
                        sb.Append(linhas[i].Remove(148, 1).Insert(148, "C"));
                    else
                        sb.Append(linhas[i]);
                }
                finalText = sb.ToString();

                File.WriteAllText(arquivo, finalText);
            }
        }
    }
}
