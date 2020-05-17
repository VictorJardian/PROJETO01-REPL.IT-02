using System;
using System.IO;
using System.Text;

class Interface{

public void exibirOpcoes(){

Console.WriteLine("1- Gerar ficha medica da Empresa.");
Console.WriteLine("2- Gerar ficha medica da Clinica.");
Console.WriteLine("3- Visualizar lista de funcionarios.");
Console.WriteLine("4- Trocar local e horario de funcionamento da clinica.");
Console.WriteLine("5- Visualizar lista de Exames disponiveis.");
Console.WriteLine("6- Visualizar lista de Funções disponiveis.");
Console.WriteLine("7- Sair.");
}

public static void verlistaExames(){
    string entradaArq;
    FileStream arquivoExames = new FileStream("listaExames.txt", FileMode.Open, FileAccess.Read);
    StreamReader lendoExames = new StreamReader(arquivoExames, Encoding.UTF8);
    while(!lendoExames.EndOfStream)
    {
     entradaArq = lendoExames.ReadLine();
     Console.WriteLine (entradaArq);
    }
}

public static void verlistaFuncoes(){
    string entradaArq;
    FileStream arquivoFuncoes = new FileStream("listaFuncoes.txt", FileMode.Open, FileAccess.Read);
    StreamReader lendoFuncoes = new StreamReader(arquivoFuncoes, Encoding.UTF8);
    while(!lendoFuncoes.EndOfStream)
    {
     entradaArq = lendoFuncoes.ReadLine();
     Console.WriteLine (entradaArq);
    }
}


}

class GeradorFicha{

protected string localConsulta;
protected string nomeEmpresa;

public void SetlocalConsulta(string reclocalConsulta){
    localConsulta = reclocalConsulta;
  }
  public string GetlocalConsulta(){
    return localConsulta;
  }

  public string GetnomeEmpresa(){
    return nomeEmpresa;
  }

public GeradorFicha(){
localConsulta = "Av. Valdopolis, 2000, Telefone: (27) 2000 - 2000, Aberto de Seg. a Sexta das 08:00 as 16:00.";
nomeEmpresa = "ValdosMetalurgia";
}

}

class MainClass {
  public static void Main (string[] args) {
    
    int opcao;
    string entradaArq;
    string entrada;

    GeradorFicha gf = new GeradorFicha();

    Console.WriteLine ("Bem Vindo ao Programa de CPMSO\n");
    Console.WriteLine ("Digite o numero da opção que deseja\n");

    Interface inter = new Interface();
    inter.exibirOpcoes();
    opcao = Convert.ToInt32(Console.ReadLine());

    if(opcao==1) //Gerar ficha medica da Empresa.
    {
      Console.Clear();
      Console.WriteLine ("Digite o nome do funcionario para Obter os dados.\n");
      Console.WriteLine ("Digite o motivo da Consulta.\n");

    }

    if(opcao==2) //Gerar ficha medica da Clinica.
    {
      Console.Clear();
      Console.WriteLine ("Digite o nome do funcionario para Obter os dados.\n");
      Console.WriteLine ("Digite o motivo da Consulta.\n");
      Console.WriteLine ("Empresa: {0}",gf.GetnomeEmpresa());
      Console.WriteLine ("/n");
      Console.WriteLine ("O local e horario de funcionamento da clinica são: \n");
      Console.WriteLine (gf.GetlocalConsulta());
      Console.WriteLine ("/n");
      
    }

    if(opcao==3) //Visualizar lista de funcionarios.
    {
      Console.Clear();

      FileStream arquivofuncionarios = new FileStream("listaInfFuncionarios.txt", FileMode.Open, FileAccess.Read);
      StreamReader lendo = new StreamReader(arquivofuncionarios, Encoding.UTF8);
      Console.WriteLine("|Nome       |Nascimento  |RG            |CPF            |Setor         |Função        |Ultimo ASO");
      while(!lendo.EndOfStream)
    {
     entradaArq = lendo.ReadLine();
     Console.WriteLine (entradaArq);
    }

    }

     if(opcao==4) //Trocar local e horario de funcionamento da clinica..
    { 
      Console.Clear();
      Console.WriteLine ("O novo local e horario de funcionamento da clinica é:");
      gf.SetlocalConsulta(Console.ReadLine());
      Console.WriteLine ("/n");
      Console.WriteLine ("Você trocou o local e horario para:\n");
      Console.WriteLine (gf.GetlocalConsulta());
    }

    if(opcao==5) //
    { 
      Console.Clear();
      Interface.verlistaExames();
    }

    if(opcao==6) //
    { 
      Console.Clear();
      Interface.verlistaFuncoes();
    }


    if(opcao==7) //SAIR.
    { 
      Console.Clear();
    }
  }
}