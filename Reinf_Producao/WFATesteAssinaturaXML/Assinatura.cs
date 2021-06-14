using envioLoteEventos;
using reinfPreWSDL;
using consultaReinfPreWSDL;
using System;
using System.Collections.Generic;
using System.Deployment.Internal.CodeSigning;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WFATesteAssinaturaXML
{
    class Assinatura
    {
        //public static string nomeCertificado = "ENSEADA INDUSTRIA NAVAL PARTICIPACOES S A:15427668000197";        
        //public static string nomeCertificado = "ENSEADA INDUSTRIA NAVAL S.A.:12243301000125";

        public Assinatura()
        {
            CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");           
        }

        public static X509Certificate2 getCert(string certName )
        {
            X509Certificate2 rcert = new X509Certificate2();

            X509Certificate2Collection lcerts;
            X509Store lStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            // Abre o Store
            lStore.Open(OpenFlags.ReadOnly);

            // Lista os certificados
            lcerts = lStore.Certificates;

            foreach (X509Certificate2 cert in lcerts)
            {
                if (cert.HasPrivateKey && cert.NotAfter > DateTime.Now && cert.NotBefore < DateTime.Now)
                {
                    if (cert.Subject.ToString().Contains(certName))
                    {
                        rcert = cert;
                    }
                }
            }
            lStore.Close();
            return rcert;
        }

        public static void SignXml(XmlDocument xmlDoc, string tagEvento, X509Certificate2 xCert)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");

            CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");

            XmlNodeList nodeParaAssinatura = xmlDoc.GetElementsByTagName(tagEvento);

            //X509Certificate2 xCert = getCert(nomeCertificado);           
            //X509Certificate2 xCert = SelecionarCertificadoAssinaturaArquivo();

            // Create a SignedXml object.           
            SignedXml signedXml = new SignedXml((XmlElement)nodeParaAssinatura[0]);
            
            signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

            RSACryptoServiceProvider privateKey = (RSACryptoServiceProvider)xCert.PrivateKey;

            if (!privateKey.CspKeyContainerInfo.HardwareDevice)
            {
                CspKeyContainerInfo enhCsp = new RSACryptoServiceProvider().CspKeyContainerInfo;
                CspParameters cspparams = new CspParameters(enhCsp.ProviderType, enhCsp.ProviderName, privateKey.CspKeyContainerInfo.KeyContainerName);
                if (privateKey.CspKeyContainerInfo.MachineKeyStore)
                {
                    cspparams.Flags |= CspProviderFlags.UseMachineKeyStore;
                }
                privateKey = new RSACryptoServiceProvider(cspparams);
            }
            // Adicionando a chave privada para assinar o documento
            signedXml.SigningKey = privateKey; //xCert.PrivateKey;


            // Create a reference to be signed.    
            Reference reference = new Reference("#" + nodeParaAssinatura[0].Attributes["id"].Value);
            reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
            // Add an enveloped transformation to the reference.
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            XmlDsigExcC14NTransform env = new XmlDsigExcC14NTransform();
            env.Algorithm = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
            reference.AddTransform(env);
            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // 
            // Add the certificate as key info, because of this the certificate 
            // with the public key will be added in the signature part.
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(xCert, X509IncludeOption.EndCertOnly));
            signedXml.KeyInfo = keyInfo;

            // Assinamos.
            signedXml.ComputeSignature();


            // Extraimos a representação da assinatura em XML
            XmlElement xmlDigitalSignature = signedXml.GetXml();


            /**************** Teste de inclusao de Assintura 1 *************************

            XmlElement xmlSignature = xmlDoc.CreateElement("Signature", "http://www.w3.org/2000/09/xmldsig#");
            XmlElement xmlSignedInfo = signedXml.SignedInfo.GetXml();
            XmlElement xmlKeyInfo = signedXml.KeyInfo.GetXml();

            XmlElement xmlSignatureValue = xmlDoc.CreateElement("SignatureValue", xmlSignature.NamespaceURI);
            string signBase64 = Convert.ToBase64String(signedXml.Signature.SignatureValue);
            XmlText text = xmlDoc.CreateTextNode(signBase64);
            xmlSignatureValue.AppendChild(text);

            xmlSignature.AppendChild(xmlDoc.ImportNode(xmlSignedInfo, true));
            xmlSignature.AppendChild(xmlSignatureValue);
            xmlSignature.AppendChild(xmlDoc.ImportNode(xmlKeyInfo, true));
            xmlDoc.DocumentElement.AppendChild(xmlSignature);
            // **************** Fim Teste de inclusao de Assintura 1 *************************/



            // **************** Teste de inclusao de Assintura 2 *************************/

            // Juntamos a assinatura XML ao documento.
              xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

            // **************** Fim Teste de inclusao de Assintura 2 *************************/


        }

        // Verify the signature of an XML file against an asymetric 
        // algorithm and return the result.
        public static Boolean VerifyXmlFile(String FileName)
        {

            RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

            // Load the certificate from the store.
            //X509Certificate2 xCert = Assinatura.getCert("ANA VIRGINIA BORGES DA CRUZ:44109652553");

            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Load the passed XML file into the document. 
            xmlDocument.Load(FileName);

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDocument);


            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

            // Load the signature node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result.|
            //return signedXml.CheckSignature(xCert, true);
            return signedXml.CheckSignature(Key);
        }

        public static void assinarEnviarXML(int idReg, XmlDocument xmlDoc, string tagEvento)
        {
            X509Certificate2 xCert = Assinatura.SelecionarCertificadoAssinaturaArquivo();

            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            // Check variables.
            if (xCert == null)
                throw new ArgumentException("Selecione um certificado !");

            // Assinar o doc xml
            Assinatura.SignXml(xmlDoc, tagEvento, xCert);

            //Pegar a URI para inclusao no Lote
            XmlNodeList nodeEvtID = xmlDoc.GetElementsByTagName(tagEvento); // "evtInfoContri"
            
            // Adicionar ao Lote
            Reinf r = new Reinf();
            r.loteEventos = new ReinfLoteEventos();
            r.loteEventos.evento = new TArquivoeReinf[1];
            r.loteEventos.evento[0] = new TArquivoeReinf();
            r.loteEventos.evento[0].id = nodeEvtID[0].Attributes["id"].Value;
            r.loteEventos.evento[0].Any = xmlDoc.DocumentElement;          

            /*** Serializa o Objeto ***/
            XmlSerializer x = new XmlSerializer(r.GetType());
            MemoryStream memStm = new MemoryStream();
            x.Serialize(memStm, r);

            memStm.Position = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            var xtr = XmlReader.Create(memStm, settings);

            // Create a new XML document com o Lote .
            XmlDocument xmlDocLote = new XmlDocument();
            xmlDocLote.Load(xtr);

            //Envio para WebService e Recepcao de Lote de Resposta de Envio
            RecepcaoLoteReinf recepLote = new RecepcaoLoteReinf();
            recepLote.ClientCertificates.Add(xCert);
            XmlNode nodeRecepLote = recepLote.ReceberLoteEventos(xmlDocLote.DocumentElement);
            XmlReader reader = XmlReader.Create(new StringReader(nodeRecepLote.OuterXml));
            reader.MoveToContent();                        

            /*** Serializa o Objeto Retorno na Memoria ***/
            //MemoryStream mem = new MemoryStream(Encoding.ASCII.GetBytes(nodeRecepLote.OuterXml));
            //retornoLoteEventos_v1_03_00.Reinf ret = new retornoLoteEventos_v1_03_00.Reinf();
            //XmlSerializer desserializador = new XmlSerializer(ret.GetType());
           // ret = (retornoLoteEventos_v1_03_00.Reinf)desserializador.Deserialize(mem);
            try
            {
                retornoLoteEventos.Reinf retEvt;
                retEvt = (retornoLoteEventos.Reinf)(new XmlSerializer(typeof(retornoLoteEventos.Reinf)).Deserialize(reader));

                XmlReader readerItem = XmlReader.Create(new StringReader(retEvt.retornoLoteEventos.retornoEventos.evento[0].Any.OuterXml));
                readerItem.MoveToContent();
                retornoTotalizadorEvento.Reinf retEvtItem;
                retEvtItem = (retornoTotalizadorEvento.Reinf)(new XmlSerializer(typeof(retornoTotalizadorEvento.Reinf)).Deserialize(readerItem));


                for (int i = 0; i <= retEvt.retornoLoteEventos.retornoEventos.evento.Length - 1; i++)
                {

                    //    if (retEvt.retornoEvento.status.cdRetorno != "0")
                    if (retEvtItem.evtTotal.ideRecRetorno.ideStatus.cdRetorno.ToString() == "2")
                    {
                        ReinfDBClassLibrary.ReinfOraDB odb = new ReinfDBClassLibrary.ReinfOraDB();
                        odb.incluirMensageria(retEvtItem.evtTotal.infoRecEv.tpEv, retEvtItem.evtTotal.infoRecEv.idEv, retEvtItem.evtTotal.infoRecEv.nrProtEntr, "E", retEvt.retornoLoteEventos.retornoEventos.evento[i].Any.InnerXml);
                        MessageBox.Show(retEvtItem.evtTotal.ideRecRetorno.ideStatus.descRetorno);
                    }
                    else
                    {
                        if (retEvtItem.evtTotal.ideRecRetorno.ideStatus.cdRetorno.ToString() != "0")
                        {
                            for (int j = 0; j <= retEvtItem.evtTotal.ideRecRetorno.ideStatus.regOcorrs.Length - 1; j++)
                            {
                                MessageBox.Show(retEvtItem.evtTotal.ideRecRetorno.ideStatus.regOcorrs[j].dscResp);
                            }

                        }
                        else
                        {
                            // Inciur no Monitor de Eventos
                            ReinfDBClassLibrary.ReinfOraDB odb = new ReinfDBClassLibrary.ReinfOraDB();
                            odb.incluirMensageria(retEvtItem.evtTotal.infoRecEv.tpEv, retEvtItem.evtTotal.infoRecEv.idEv, retEvtItem.evtTotal.infoTotal.nrRecArqBase, "E", retEvt.retornoLoteEventos.retornoEventos.evento[i].Any.InnerXml);
                            MessageBox.Show("Evento transmitido. Recibo nº" + retEvtItem.evtTotal.infoTotal.nrRecArqBase);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        public static void assinarEnviarLoteXML(int idReg, System.Collections.Generic.List<XmlDocument> xmlDoc, string tagEvento)
        {
            X509Certificate2 xCert = Assinatura.SelecionarCertificadoAssinaturaArquivo();

            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            // Check variables.
            if (xCert == null)
                throw new ArgumentException("Selecione um certificado !");

            Reinf r = new Reinf();
            r.loteEventos = new ReinfLoteEventos();
            for (int i = 0; i <= xmlDoc.Count - 1; i++)
            {
                r.loteEventos.evento = new TArquivoeReinf[i + 1];                
            }
            // Assinar o doc xml
            for (int i = 0; i <= xmlDoc.Count - 1; i++)
            {
                Assinatura.SignXml(xmlDoc[i], tagEvento, xCert);

                //Pegar a URI para inclusao no Lote
                XmlNodeList nodeEvtID = xmlDoc[i].GetElementsByTagName(tagEvento); // "evtInfoContri"

                // Adicionar ao Lote

                
                r.loteEventos.evento[i] = new TArquivoeReinf();
                r.loteEventos.evento[i].id = nodeEvtID[0].Attributes["id"].Value;
                r.loteEventos.evento[i].Any = xmlDoc[i].DocumentElement;
            }
            /*** Serializa o Objeto ***/
            XmlSerializer x = new XmlSerializer(r.GetType());
            MemoryStream memStm = new MemoryStream();
            x.Serialize(memStm, r);

            memStm.Position = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            var xtr = XmlReader.Create(memStm, settings);

            // Create a new XML document com o Lote .
            XmlDocument xmlDocLote = new XmlDocument();
            xmlDocLote.Load(xtr);

            //Envio para WebService e Recepcao de Lote de Resposta de Envio
            RecepcaoLoteReinf recepLote = new RecepcaoLoteReinf();
            recepLote.ClientCertificates.Add(xCert);
            XmlNode nodeRecepLote = recepLote.ReceberLoteEventos(xmlDocLote.DocumentElement);
            XmlReader reader = XmlReader.Create(new StringReader(nodeRecepLote.OuterXml));
            reader.MoveToContent();

            /*** Serializa o Objeto Retorno na Memoria ***/
            MemoryStream mem = new MemoryStream(Encoding.ASCII.GetBytes(nodeRecepLote.OuterXml));
            retornoLoteEventos.Reinf ret = new retornoLoteEventos.Reinf();
            XmlSerializer desserializador = new XmlSerializer(ret.GetType());
            ret = (retornoLoteEventos.Reinf)desserializador.Deserialize(mem);
            try
            {
                retornoTotalizadorEvento.Reinf retEvt;
                for (int i = 0; i <= ret.retornoLoteEventos.retornoEventos.evento.Length - 1; i++)
                {
                        XmlReader readerItem = XmlReader.Create(new StringReader(ret.retornoLoteEventos.retornoEventos.evento[i].Any.OuterXml));
                        readerItem.MoveToContent();
                        switch (readerItem.Name)
                        {
                            case "Reinf":
                                retEvt = (retornoTotalizadorEvento.Reinf)(new XmlSerializer(typeof(retornoTotalizadorEvento.Reinf)).Deserialize(readerItem));
                                if (retEvt.evtTotal.ideRecRetorno.ideStatus.cdRetorno.ToString() != "0")
                                {
                                    for (int j = 0; j <= retEvt.evtTotal.ideRecRetorno.ideStatus.regOcorrs.Length - 1; j++)
                                    {
                                        //odb.incluirMensageria(retEvt.retornoEvento.dadosRecepcaoEvento.tipoEvento, retEvt.retornoEvento.dadosReciboEntrega.numeroRecibo, "O");
                                        MessageBox.Show(retEvt.evtTotal.ideRecRetorno.ideStatus.regOcorrs[j].dscResp);
                                    }

                                }
                                else
                                {
                                    // Inciur no Monitor de Eventos
                                    ReinfDBClassLibrary.ReinfOraDB odb = new ReinfDBClassLibrary.ReinfOraDB();
                                    odb.incluirMensageria(retEvt.evtTotal.infoRecEv.tpEv, retEvt.evtTotal.infoRecEv.idEv, retEvt.evtTotal.infoTotal.nrRecArqBase, "E", ret.retornoLoteEventos.retornoEventos.evento[i].Any.InnerXml);
                                    MessageBox.Show("Evento transmitido. Recibo nº" + retEvt.evtTotal.infoTotal.nrRecArqBase);                                   
                                }

                                break;
                            default:
                                throw new NotSupportedException("Tag não esperada: " + reader.Name);
                        }                    

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public static void ConsultaInformacoesConsolidadasReinf(int idReg, byte tipoInscricaoContribuinte, string numeroInscricaoContribuinte, string numeroReciboFechamento)
        {
            try
            {
                X509Certificate2 xCert = Assinatura.SelecionarCertificadoAssinaturaArquivo();

                // Check variables.
                if (xCert == null)
                    throw new ArgumentException("Selecione um certificado !");
                //Envio para WebService e Recepcao de Lote de Resposta de Envio

                ConsultasReinf consultaReinf = new ConsultasReinf();

                consultaReinf.ClientCertificates.Add(xCert);

                XmlNode nodeRecepLote = consultaReinf.ConsultaResultadoFechamento2099(tipoInscricaoContribuinte, numeroInscricaoContribuinte, numeroReciboFechamento);//   ConsultaInformacoesConsolidadas(tipoInscricaoContribuinte, numeroInscricaoContribuinte, numeroReciboFechamento);
                XmlReader reader = XmlReader.Create(new StringReader(nodeRecepLote.OuterXml));
                reader.MoveToContent();

                /*** Serializa o Objeto Retorno na Memoria ***/
                try
                {
                    retornoTotalizadorContribuinte.Reinf retConsultaReinfEvt;
                    retConsultaReinfEvt = (retornoTotalizadorContribuinte.Reinf)(new XmlSerializer(typeof(retornoTotalizadorContribuinte.Reinf)).Deserialize(reader));

                    if (retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.cdRetorno.ToString() == "2")
                    {
                        MessageBox.Show(retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.descRetorno);
                    }
                    else
                    {
                        if (retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.cdRetorno.ToString() != "0")
                        {
                            if (retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.regOcorrs.Count() == 1)
                            {
                                MessageBox.Show(retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.regOcorrs[0].dscResp + " - Cod : " + retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.regOcorrs[0].codResp);
                            }
                            else
                            {
                                MessageBox.Show(retConsultaReinfEvt.evtTotalContrib.ideRecRetorno.ideStatus.descRetorno);
                            }
                        }
                        else
                        {
                            ReinfDBClassLibrary.R5011DAL r5011 = new ReinfDBClassLibrary.R5011DAL();
                            r5011.preencherR5011(idReg, retConsultaReinfEvt, nodeRecepLote.OuterXml);
                        }
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public static X509Certificate2 SelecionarCertificadoAssinaturaArquivo()
        {
            X509Certificate2 vRetorna;
            X509Certificate2 oX509Cert = new X509Certificate2();
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
            X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);
            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificado(s) Digital(is) disponível(is)", "Selecione o certificado digital para uso no aplicativo", X509SelectionFlag.SingleSelection);

            if (scollection.Count == 0)
            {
                string msgResultado = "Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.";
                MessageBox.Show(msgResultado, "Advertência", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vRetorna = null;
            }
            else
            {
                oX509Cert = scollection[0];
                vRetorna = oX509Cert;
            }

            return vRetorna;
        }

    }
}
