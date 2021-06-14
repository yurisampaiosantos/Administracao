using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace WebServiceDocs
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void Anexar(decimal anexoId)
        {
            AnexoDocs anexo = new AnexoDocs();
            anexo.SelecionarAnexo(anexoId);
            string diretorio = "";
            if (anexo.Id != 0)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo("E:\\Arquivos\\Docs\\" + anexo.DocumentoId);
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }
                    FileInfo infoArquivo = new FileInfo(infoDir + "\\" + anexo.NomeArquivo);
                    try
                    {
                        diretorio = infoDir + "\\" + DateTime.Now.Date.ToString("ddMMyyyy") + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + System.IO.Path.GetExtension(anexo.NomeArquivo);
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexo.Anexo, 0, anexo.Anexo.Length);
                        }
                        anexo.AtualizarAnexo(anexoId, diretorio);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        [WebMethod]
        public void ExcluirAnexo(decimal anexoId)
        {
            AnexoDocs anexo = new AnexoDocs();
            anexo.SelecionarAnexo(anexoId);
            try
            {
                if (anexo.Diretorio != null && anexo.Diretorio != "")
                {
                    FileInfo infoArquivo = new FileInfo(anexo.Diretorio);
                    infoArquivo.Delete();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}