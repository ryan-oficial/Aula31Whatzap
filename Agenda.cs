using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula31Whatzap
{
    public class Agenda : IAgenda
    {
        /// <summary>
        ///  Atributos de apoio
        /// </summary>
        /// <value></value>
        public List<Contato> Contatos { get; set; }
        public Contato Telefone { get; set; }
        List<Contato> contato = new List<Contato>();
        private const string PATH = "Database/produto.csv";
        
        /// <summary>
        /// Cria um diretorio
        /// </summary>
        public Agenda(){
            if (!File.Exists(PATH)){
                Directory.CreateDirectory("Database");
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Cadastra um novo contato
        /// </summary>
        /// <param name="Contatos">Os Contatos</param>
        public void Cadastrar(Contato Contatos)
        {
            string[] linha = new string[] {PrepararLinha(Contatos)};
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Apaga um dos contatos
        /// </summary>
        /// <param name="_termo">O contato que vai ser apagado</param>
        public void Excluir(string _termo)
        {
            List<string> linhas = new List<string>();
            
            using(StreamReader arquivo = new StreamReader(PATH)){
                string linha;
                while((linha = arquivo.ReadLine())!=null){
                    linhas.Add(linha);
                }
            }
            linhas.RemoveAll(z => z.Contains(_termo));
        }


        /// <summary>
        /// Lista em ordem alfabetica os nomes dos contatos
        /// </summary>
        /// <returns>Retorna em ordem</returns>
        public List<Contato> Listar()
        {
            List<Contato> lista = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                string[] dado = linha.Split("-");

                Contato c   = new Contato();
                c.Nome      = Separar(dado[0]);
                c.Telefone  = Separar(dado[1]);

                lista.Add(c);
            }
            lista = lista.OrderBy(z => z.Nome).ToList();

            return lista;
           
        }
        /// <summary>
        /// Separa os dados
        /// </summary>
        /// <param name="dado"></param>
        /// <returns>Retorna com o split</returns>
        public string Separar(string dado){
            return dado.Split("=")[1];
        }

        /// <summary>
        /// Molde da linha para o csv
        /// </summary>
        /// <param name="cont">O contato que vai pro csv</param>
        /// <returns>O molde preenchido com o nome o numero do contato</returns>
        private string PrepararLinha(Contato cont){
            return $"Nome={cont.Nome}-Telefone={cont.Telefone}";
        }
    }
}