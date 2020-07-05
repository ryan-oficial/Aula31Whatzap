using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula31Whatzap
{
    public class Agenda : IAgenda
    {
    
        public List<Contato> Contatos { get; set; }
        public Contato Telefone { get; set; }

        List<Contato> contato = new List<Contato>();
        private const string PATH = "Database/produto.csv";

        public Agenda(){
            if (!File.Exists(PATH)){
                Directory.CreateDirectory("Database");
                File.Create(PATH).Close();
            }
        }

        public void Cadastrar(Contato Contatos)
        {
            string[] linha = new string[] {PrepararLinha(Contatos)};
            File.AppendAllLines(PATH, linha);
        }

        public void Excluir(string _termo)
        {
            List<string> linhas = new List<string>();
            
            using(StreamReader arquivo = new StreamReader(PATH)){
                string linha;
                while((linha = arquivo.ReadLine())!=null){
                    linhas.Add(linha);
                }
            }
            linhas.Remove(_termo);
        }

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
        public string Separar(string dado){
            return dado.Split("=")[1];
        }

        private string PrepararLinha(Contato cont){
            return $"Nome={cont.Nome}-Telefone={cont.Telefone}";
        }
    }
}