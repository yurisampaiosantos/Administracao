using System;
using System.Collections.Generic;
using System.Text;

namespace WebServicePBI.Modelo
{
    public class PBI_Oracle
    {
        private string _nome_Completo;
        private string _login;
        private string _ou;
        private string _cpf;
        private string _cc;
        private string _matricula;
        private string _e_Mail;
        private string _company;
        private string _departamento;
        private string _negocio;
        private string _diretoria;
        private string _escritorio;
        private string _lider;

        public string Nome_Completo
        {
            get { return _nome_Completo; }
            set { _nome_Completo = value; }
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
        public string E_Mail
        {
            get { return _e_Mail; }
            set { _e_Mail = value; }
        }
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }
        public string Departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }
        public string Negocio
        {
            get { return _negocio; }
            set { _negocio = value; }
        }
        public string Diretoria
        {
            get { return _diretoria; }
            set { _diretoria = value; }
        }
        public string Escritorio
        {
            get { return _escritorio; }
            set { _escritorio = value; }
        }
        public string Lider
        {
            get { return _lider; }
            set { _lider = value; }
        }
    }
}