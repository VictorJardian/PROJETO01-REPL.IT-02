using System;
using System.IO;
using System.Text;

class Login{
 
  protected string usuario="valdos";
  protected int senha=1234;

  public bool Verificarlogin(string usu, int sen){
  if(usuario == usu && senha == sen)
  {
    Console.WriteLine("Úsuario e senha, corretos!\n");
    return true;
  }
  else
  {
    Console.WriteLine("Úsuario e senha, incorretos!\n");
    return false;
  }
}
}

class Interface{

public void exibirOpcoes(){

Console.WriteLine("1- Gerar ficha medica da Empresa.");
Console.WriteLine("2- Gerar ficha medica da Clinica.");
Console.WriteLine("3- Visualizar lista de funcionarios.");
Console.WriteLine("4- Trocar local e horario de funcionamento da clinica.");
Console.WriteLine("5- Visualizar lista de Exames disponiveis.");
Console.WriteLine("6- Visualizar lista de Funções disponiveis.");
Console.WriteLine("7- Sair.");
Console.WriteLine ("\n");
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

public static void verlistaInfFuncionarios(){
    string entradaArq;
    FileStream arquivofuncionarios = new FileStream("listaInfFuncionarios.txt", FileMode.Open, FileAccess.Read);
    StreamReader lendoFuncionarios = new StreamReader(arquivofuncionarios, Encoding.UTF8);
    Console.WriteLine("|Nome          |Nascimento  |RG            |CPF            |Setor         |Função        |Ultimo ASO");
    while(!lendoFuncionarios.EndOfStream)
    {
     entradaArq = lendoFuncionarios.ReadLine();
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
  
    string motivoString="";
    char motivo;
    string usu;
    int sen;
    int opcao;
    string[] vet = new string[10];
    string escolha="nao";

    Console.WriteLine ("Bem Vindo ao Programa de CPMSO, Digite seu login e senha.\n");
    Login log = new Login();
    usu = Console.ReadLine();
    sen = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine ("\n");
    bool verificacao = log.Verificarlogin(usu, sen);

    FileStream arquivofuncionarios = new FileStream("listaInfFuncionarios.txt", FileMode.Open, FileAccess.Read);
    StreamReader lendoFuncionarios = new StreamReader(arquivofuncionarios, Encoding.UTF8);

    if(verificacao == true){

      while(escolha!="sim"){

        GeradorFicha gf = new GeradorFicha();

        Console.WriteLine ("Digite o numero da opção que deseja\n");

        Interface inter = new Interface();
        inter.exibirOpcoes();
        opcao = Convert.ToInt32(Console.ReadLine());

        if(opcao==1) //Gerar ficha medica da Empresa.
        {
        
          
          Console.Clear();
  
          int escfun;
          
          string exameFazer;

          Console.WriteLine ("Escolha o número do funcionario para Obter os dados.\n");
          Interface.verlistaInfFuncionarios();
          Console.WriteLine ("\n");
          escfun = Convert.ToInt32(Console.ReadLine());
          Console.Clear();
          for(int i=0; i<10; i++){
          vet[i] = lendoFuncionarios.ReadLine();
          }
          Console.WriteLine ("Digite a letra que representa o motivo da Consulta:\n");
          Console.WriteLine ("A - Admissional, D - Demissional, P - Periódico, R - Retorno ao Trabalho, M - Mudança de Função.\n");
          motivo = Convert.ToChar(Console.ReadLine());
          Console.Clear();
          switch(motivo){
            case 'A':
              motivoString = "Admissional";
              break;
            case 'a':
              motivoString = "Admissional";
              break;
            case 'D':
              motivoString = "Demissional";
              break;
            case 'd':
              motivoString = "Demissional";
              break;
            case 'P':
              motivoString = "Periódico";
              break;
            case 'p':
              motivoString = "Periódico";
              break;
            case 'R':
              motivoString = "Retorno ao Trabalho";
              break;
            case 'r':
              motivoString = "Retorno ao Trabalho";
              break;
            case 'M':
              motivoString = "Mudança de Função";
              break;
            case 'm':
              motivoString = "Mudança de Função";
              break;
          }
          Console.WriteLine ("Digite o exame que deseja mandar o funcionario fazer:\n");
          Interface.verlistaExames();
          Console.WriteLine ("\n");
          exameFazer = Console.ReadLine();
          Console.WriteLine ("\n");
          Console.Clear();
          Console.WriteLine ("Gerando... PDF\n");
          Console.WriteLine("=====================================================================================================");
          Console.WriteLine("|Nome          |Nascimento  |RG            |CPF            |Setor         |Função        |Ultimo ASO");
          Console.WriteLine ("{0}",vet[escfun-1]);
          Console.WriteLine ("");
          Console.WriteLine ("*MOTIVO*");
          Console.WriteLine ("");
          Console.WriteLine ("{0}",motivoString);
          Console.WriteLine ("");
          Console.WriteLine ("*EXAME*");
          Console.WriteLine ("");
          Console.WriteLine ("{0}",exameFazer);
          Console.WriteLine ("");
          Console.WriteLine("=====================================================================================================");
          Console.WriteLine ("\n");
        }

        if(opcao==2) //Gerar ficha medica da Clinica.
        {

          Console.Clear();
          
          int escfun;
          
          string exameFazer;

          Console.WriteLine ("Escolha o número do funcionario para Obter os dados.\n");
          Interface.verlistaInfFuncionarios();
          Console.WriteLine ("\n");
          escfun = Convert.ToInt32(Console.ReadLine());
          Console.Clear();
          for(int i=0; i<10; i++){
          vet[i] = lendoFuncionarios.ReadLine();
          }
          Console.WriteLine ("Digite a letra que representa o motivo da Consulta:\n");
          Console.WriteLine ("A - Admissional, D - Demissional, P - Periódico, R - Retorno ao Trabalho, M - Mudança de Função.\n");
          motivo = Convert.ToChar(Console.ReadLine());
          Console.Clear();
          switch(motivo){
            case 'A':
              motivoString = "Admissional";
              break;
            case 'a':
              motivoString = "Admissional";
              break;
            case 'D':
              motivoString = "Demissional";
              break;
            case 'd':
              motivoString = "Demissional";
              break;
            case 'P':
              motivoString = "Periódico";
              break;
            case 'p':
              motivoString = "Periódico";
              break;
            case 'R':
              motivoString = "Retorno ao Trabalho";
              break;
            case 'r':
              motivoString = "Retorno ao Trabalho";
              break;
            case 'M':
              motivoString = "Mudança de Função";
              break;
            case 'm':
              motivoString = "Mudança de Função";
              break;
          }
          Console.WriteLine ("Digite o exame que deseja mandar o funcionario fazer:\n");
          Interface.verlistaExames();
          Console.WriteLine ("\n");
          exameFazer = Console.ReadLine();
          Console.WriteLine ("\n");
          Console.Clear();
          Console.WriteLine ("Gerando... PDF\n");
          Console.WriteLine("=====================================================================================================");
          Console.WriteLine("|Nome          |Nascimento  |RG            |CPF            |Setor         |Função        |Ultimo ASO");
          Console.WriteLine ("{0}",vet[escfun-1]);
          Console.WriteLine ("");
          Console.WriteLine ("*MOTIVO*");
          Console.WriteLine ("");
          Console.WriteLine ("{0}",motivoString);
          Console.WriteLine ("");
          Console.WriteLine ("*EXAME*");
          Console.WriteLine ("");
          Console.WriteLine ("{0}",exameFazer);
          Console.WriteLine ("");
          Console.WriteLine ("*EMPRESA: {0}*",gf.GetnomeEmpresa());
          Console.WriteLine ("");
          Console.WriteLine ("O local e horario de funcionamento da clinica são:");
          Console.WriteLine (gf.GetlocalConsulta());
          Console.WriteLine ("");
          Console.WriteLine("=====================================================================================================");
          Console.WriteLine ("\n");
        }

        if(opcao==3) //Visualizar lista de funcionarios.
        {
          Console.Clear();
          Interface.verlistaInfFuncionarios();
        }

        if(opcao==4) //Trocar local e horario de funcionamento da clinica..
        { 
          Console.Clear();
          Console.WriteLine ("O novo local e horario de funcionamento da clinica é:");
          gf.SetlocalConsulta(Console.ReadLine());
          Console.WriteLine ("\n");
          Console.WriteLine ("Você trocou o local e horario para:\n");
          Console.WriteLine (gf.GetlocalConsulta());
          Console.WriteLine ("\n");
        }

        if(opcao==5) //Visualizar lista de Exames.
        { 
          Console.Clear();
          Interface.verlistaExames();
          Console.WriteLine ("\n");
        }

        if(opcao==6) //Visualizar lista de Funções.
        { 
          Console.Clear();
          Interface.verlistaFuncoes();
          Console.WriteLine ("\n");
        }


        if(opcao==7) //SAIR.
        { 
          Console.Clear();
          Console.WriteLine("Tem certeza que:");
        }
        Console.WriteLine("Deseja sair?");
        escolha = Console.ReadLine();
        Console.Clear();
      }
    }
  }
}