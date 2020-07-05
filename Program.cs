using System;
using System.Collections.Generic;

namespace Aula31Whatzap
{
    class Program
    {
        static void Main(string[] args)
        {
          
           Mensagem mens = new Mensagem();
           Agenda agenda = new Agenda();
           Contato c1 = new Contato();
           c1.Nome = "Julia";
           c1.Nome = "Roberto";
           c1.Nome = "joao";
           c1.Nome = "Maria";
           c1.Nome = "Marcos";
           c1.Telefone = "00041598";

        //    agenda.Cadastrar(c1);



           System.Console.WriteLine("Sua lista de contatos:");

           List<Contato> lista = agenda.Listar();

           foreach(Contato item in lista){
               System.Console.WriteLine($"Telefone: {item.Telefone} Nome: {item.Nome}");
           }
          
           mens.Enviar(c1);

           
        }
    }
}
