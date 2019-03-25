using System;
using System.IO;


namespace AppForms.Model
{
    class Log
    {
        #region Criar Arquivo
        public void CriarArquivo()
        {
            StreamWriter file = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
            file.Close();
        }
        #endregion

        #region Verifica se Arquivo Existe
        public bool ArquivoExiste()
        {
            bool result = false;

            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "log.txt")))
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region Registra Log
        public void RegistrarLog(string Acao)
        {
            if (ArquivoExiste())
            {
                StreamWriter file = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), true);
                file.NewLine = Environment.NewLine;
                file.WriteLine(Acao + " " + DateTime.Now);
                file.Close();
            }
            else
            {
                CriarArquivo();
                StreamWriter file = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), true);
                file.NewLine = Environment.NewLine;
                file.WriteLine(Acao + " " + DateTime.Now);
                file.Close();
            }
        }
        #endregion
    }
}
