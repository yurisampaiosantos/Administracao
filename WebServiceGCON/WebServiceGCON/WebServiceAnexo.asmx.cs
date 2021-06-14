using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace WebServiceGCON
{
    /// <summary>
    /// Summary description for WebServiceAnexo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAnexo : System.Web.Services.WebService
    {
        //referente ao contrato
        [WebMethod]
        public void AnexarContrato(decimal anexoId)
        {
            AnexoContrato anexoContrato = new AnexoContrato();
            anexoContrato.SelecionarAnexoContrato(anexoId);
            string diretorio = "";
            if (anexoContrato.Id != 0)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo("E:\\Arquivos\\GECON\\" + anexoContrato.Ano + "\\" + anexoContrato.Mes + "\\" + anexoContrato.ContratoId);
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }
                    FileInfo infoArquivo = new FileInfo(infoDir + "\\" + anexoContrato.NomeArquivo);
                    try
                    {
                        diretorio = infoDir + "\\" + DateTime.Now.Date.ToString("ddMMyyyy") + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + System.IO.Path.GetExtension(anexoContrato.NomeArquivo);
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexoContrato.Anexo, 0, anexoContrato.Anexo.Length);
                        }
                        anexoContrato.AtualizarAnexoContato(anexoId, diretorio);
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
        public void ExcluirAnexoContrato(decimal anexoId)
        {
            AnexoContrato anexoContrato = new AnexoContrato();
            anexoContrato.SelecionarAnexoContrato(anexoId);
            try
            {
                if (anexoContrato.Diretorio != null && anexoContrato.Diretorio != "")
                {
                    FileInfo infoArquivo = new FileInfo(anexoContrato.Diretorio);
                    infoArquivo.Delete();
                }
            }
            catch (Exception ex)
            {               
            }
        }
        //referente ao parceiro
        [WebMethod]
        public void AnexarParceiro(decimal anexoId)
        {
            AnexoParceiro anexoParceiro = new AnexoParceiro();
            anexoParceiro.SelecionarAnexoParceiro(anexoId);
            string diretorio = "";
            if (anexoParceiro.Id != 0)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo("E:\\Arquivos\\GECON\\" + anexoParceiro.Ano + "\\" + anexoParceiro.Mes + "\\" + anexoParceiro.ContratoId + "\\Parceiro");
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }
                    FileInfo infoArquivo = new FileInfo(infoDir + "\\" + anexoParceiro.NomeArquivo);
                    try
                    {
                        diretorio = infoDir + "\\" + DateTime.Now.Date.ToString("ddMMyyyy") + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + System.IO.Path.GetExtension(anexoParceiro.NomeArquivo);
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexoParceiro.Anexo, 0, anexoParceiro.Anexo.Length);
                        }
                        anexoParceiro.AtualizarAnexoParceiro(anexoId, diretorio);
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
        public void ExcluirAnexoParceiro(decimal anexoId)
        {
            AnexoParceiro anexoParceiro = new AnexoParceiro();
            anexoParceiro.SelecionarAnexoParceiro(anexoId);
            try
            {
                if (anexoParceiro.Diretorio != null && anexoParceiro.Diretorio != "")
                {
                    FileInfo infoArquivo = new FileInfo(anexoParceiro.Diretorio);
                    infoArquivo.Delete();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
