using System;
using System.IO;
using System.Collections.Generic;
using Concatenador.Util;

namespace Concatenador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processo iniciado...");

            #region Empresa Um

            Console.WriteLine("Processando " + Settings.EmpresaUm + ".");

            List<string> arquivosRmEmpresaUm = Utilities.PegaArquivosPorExtensao
                (Settings.CaminhoBase + '\\' + Settings.EmpresaUm, "RM");
            List<string> arquivosCrmEmpresaUm = Utilities.PegaArquivosPorExtensao
                (Settings.CaminhoBase + '\\' + Settings.EmpresaUm, "CRM");
            string dadoFinal = Utilities.ConcatenaInformacao(arquivosRmEmpresaUm);

            string diretorioCriado = Utilities.CriaDiretorio(Settings.CaminhoBase + '\\' + Settings.EmpresaUm);
            if (!String.IsNullOrEmpty(diretorioCriado))
            {
                Utilities.MoveArquivosPorExtensao(Settings.CaminhoBase + '\\' + Settings.EmpresaUm,
                    diretorioCriado, "RM");
            }
            Utilities.CriaDiretorio(Settings.CaminhoBase + '\\' + Settings.EmpresaUm, "enviado");

            Utilities.ImportaDados(dadoFinal, arquivosCrmEmpresaUm);

            Console.WriteLine(Settings.EmpresaUm + " finalizada.");

            #endregion


            // Repete o mesmo processo, porém, para uma segunda empresa
            // que utiliza outro diretório.
            #region Empresa Dois

            Console.WriteLine("Processando " + Settings.EmpresaDois + ".");

            List<string> arquivosRmEmpresaDois = Utilities.PegaArquivosPorExtensao
                (Settings.CaminhoBase + '\\' + Settings.EmpresaDois, "RM");
            List<string> arquivosCrmEmpresaDois = Utilities.PegaArquivosPorExtensao
                (Settings.CaminhoBase + '\\' + Settings.EmpresaDois, "CRM");
            dadoFinal = Utilities.ConcatenaInformacao(arquivosRmEmpresaDois);

            diretorioCriado = Utilities.CriaDiretorio(Settings.CaminhoBase + '\\' + Settings.EmpresaDois);
            if (!String.IsNullOrEmpty(diretorioCriado))
            {
                Utilities.MoveArquivosPorExtensao(Settings.CaminhoBase + '\\' + Settings.EmpresaDois,
                    diretorioCriado, "RM");
            }
            Utilities.CriaDiretorio(Settings.CaminhoBase + '\\' + Settings.EmpresaDois, "enviado");

            Utilities.ImportaDados(dadoFinal, arquivosCrmEmpresaDois);

            Console.WriteLine(Settings.EmpresaDois + " finalizada.");

            #endregion

            Console.WriteLine("Processo finalizado... por favor, aperte qualquer tecla para sair.");
            Console.ReadKey(true);
        }
    }
}
