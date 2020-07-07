using System;

namespace Aula31Whatzap
{
    public class Mensagem : Contato
    {
        public string Texto { get; set; }
        public string Destinatario { get; set; }

        

        public void Enviar(Contato cont){
            System.Console.WriteLine("Pra quem voce deseja escrever?");
            Destinatario = Console.ReadLine();
            System.Console.WriteLine("Escreva sua mensagem:");
            Texto = Console.ReadLine();
            System.Console.WriteLine($"\nMensagem enviada para: {Destinatario}\nMensagem enviada: {Texto}");
           
         }

        


    }
}