using System;
using System.Collections.Generic;
using PlataformaCurso.Models;

public class CoordenadorService:MateriaService
{
    public CoordenadorService(MateriaService materiaService)
    {
        materiaService.MateriaCriada += MateriaCriadaEventHandler;
    }
    // public event EventHandler<string> MateriaCriada;
    public List<Coordenador> ListaDeCoordenador = new List<Coordenador>();

    //modificado

    public void IniciarCadastro()
    {
        Coordenador novoCoordenador;

        Console.WriteLine("Digite o nome do coordenador");
        var nome = Console.ReadLine();

        if (!string.IsNullOrEmpty(nome))
        {
            novoCoordenador = new Coordenador(nome);

            Console.WriteLine("Digite as áreas de atuação separado por vírgula (SÓ APERTE ENTER QUANDO ACABAR)");
            var conhecimentos = Console.ReadLine();

            novoCoordenador.Conhecimentos = conhecimentos?.Split(",").ToList() ?? new List<string>();
            ListaDeCoordenador.Add(novoCoordenador);

            Console.WriteLine("Coordenador cadastrado com sucesso!");
            Console.WriteLine("");//vazio para espaço
        }


        var materiaService = new MateriaService();
        materiaService.MateriaCriada += MateriaCriadaEventHandler;
        
    }

    public List<Coordenador> ObterTodos()
    {
        return this.ListaDeCoordenador;
    }

    //modificado

    // Manipulador de eventos para evento MateriaCriada
    public void MateriaCriadaEventHandler(object sender, string materiaNome)
    {
        Console.WriteLine($"Nova matéria de {materiaNome} criada em CoordenadorService");
        Console.WriteLine("");//vazio para espaço
    }

    
}