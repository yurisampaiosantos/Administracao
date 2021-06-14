using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace WebServiceGPEND
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
        //referente ao contrato
        [WebMethod]
        public void AnexarPendencia(decimal anexoId)
        {
            AnexoPendencia anexoPendencia = new AnexoPendencia();
            anexoPendencia.SelecionarAnexoContrato(anexoId);
            string diretorio = "";
            if (anexoPendencia.Id != 0)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo("E:\\Arquivos\\GPEND\\" + DateTime.Now.Date.ToString("yyyy") + "\\" + DateTime.Now.Date.ToString("yyyy-MM") + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\" + anexoPendencia.PendenciaId);
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }
                    FileInfo infoArquivo = new FileInfo(infoDir + "\\" + anexoPendencia.NomeArquivo);
                    try
                    {
                        diretorio = infoDir + "\\" + DateTime.Now.Date.ToString("ddMMyyyy") + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + System.IO.Path.GetExtension(anexoPendencia.NomeArquivo);
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexoPendencia.Anexo, 0, anexoPendencia.Anexo.Length);
                        }
                        anexoPendencia.AtualizarAnexoContato(anexoId, diretorio);
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
        public void ExcluirAnexoPendencia(decimal anexoId)
        {
            AnexoPendencia anexoPendencia = new AnexoPendencia();
            anexoPendencia.SelecionarAnexoContrato(anexoId);
            try
            {
                if (anexoPendencia.Diretorio != null && anexoPendencia.Diretorio != "")
                {
                    FileInfo infoArquivo = new FileInfo(anexoPendencia.Diretorio);
                    infoArquivo.Delete();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}