using System;
using System.Collections.Generic;
using System.Text;

namespace WebServicePBI.Modelo
{
    public class PBI_SqlServer
    {
        private string _nome_Completo;
        private string _domain;
        private string _login;
        private string _ou;
        private string _cpf;
        private string _cc;
        private string _matricula;
        private string _eMail;
        private string _empresa;
        private string _departamento;
        private string _descricao;
        private string _escritorio;
        private string _gerente;

        public string Nome_Completo
        {
            get { return _nome_Completo; }
            set { _nome_Completo = value; }
        }
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Ou
        {
            get { return _ou; }
            set { _ou = value; }
        }
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        public string Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        public string EMail
        {
            get { return _eMail; }
            set { _eMail = value; }
        }
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        public string Departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public string Escritorio
        {
            get { return _escritorio; }
            set { _escritorio = value; }
        }
        public string Gerente
        {
            get { return _gerente; }
            set { _gerente = value; }
        }
    }
}
