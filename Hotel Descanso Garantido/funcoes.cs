using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//TESTAR MAIS VEZES A OPÇÃO BAIXA EM ESTADIA POIS UMA VEZ REPETIU A MOSTRA DE VALORES.
//ACEITAR ESTADIAS COM QUARTOS ACIMA DA QTD DE HOS DESEJADA
//VERIFICAR INSERÇÃO DE DADOS ERRADOS
namespace Hotel_Descanso_Garantido
{
    class funcoes
    {
        //Função cadastrar cliente
        public static void client()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CADASTRAR CLIENTE:\n");
            Console.ResetColor();
            string nome, endereço, telefone, qtd;
            StreamWriter escreve;
            if (File.Exists("Cliente.txt"))
            {
                escreve = File.AppendText("Cliente.txt");
            }
            else
            {
                escreve = File.CreateText("Cliente.txt");
            }
            escreve.Close();
            StreamReader ler = new StreamReader("Cliente.txt");
            //algoritmo de código automático
            int contador = 1;
            do
            {
                qtd = ler.ReadLine();
                if (qtd != null)
                {
                    contador++;
                }
            } while (qtd != null);
            ler.Close();
            escreve = File.AppendText("Cliente.txt");
            if (contador > 1)
            {
                contador = contador / 5;
                contador++;
            }
            Console.WriteLine("Insira o nome do cliente:");
            nome = Console.ReadLine().ToUpper();
            escreve.WriteLine(nome);
            escreve.WriteLine(contador);
            Console.WriteLine("Insira o endereço do cliente:\nFormato (rua,número,cidade,estado)");
            endereço = Console.ReadLine().ToUpper();
            escreve.WriteLine(endereço);
            Console.WriteLine("Insira o telefone do cliente:");
            telefone = Console.ReadLine().ToUpper();
            escreve.WriteLine(telefone);
            escreve.WriteLine("¢");
            escreve.Close();
            Console.WriteLine("\nCadastro realizado com sucesso!\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
        //Função cadastrar funcionário
        public static void funcionari()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CADASTRAR FUNCIONÁRIO:\n");
            Console.ResetColor();
            string qtd, nome, telefone, cargo, salario;
            StreamWriter escreve;
            if (File.Exists("Funcionario.txt"))
            {
                escreve = File.AppendText("Funcionario.txt");
            }
            else
            {
                escreve = File.CreateText("Funcionario.txt");
            }
            escreve.Close();
            StreamReader ler = new StreamReader("Funcionario.txt");
            int contador = 1;
            do
            {
                qtd = ler.ReadLine();
                if (qtd != null)
                {
                    contador++;
                }
            } while (qtd != null);
            ler.Close();
            escreve = File.AppendText("Funcionario.txt");
            if (contador > 1)
            {
                contador = contador / 5;
                contador++;
            }
            Console.WriteLine("Insira o nome do funcionário:");
            nome = Console.ReadLine().ToUpper();
            escreve.WriteLine(nome);
            escreve.WriteLine(contador);
            Console.WriteLine("Insira o telefone do funcionário:");
            telefone = Console.ReadLine().ToUpper();
            escreve.WriteLine(telefone);
            Console.WriteLine("Insira o cargo do funcionário:");
            cargo = Console.ReadLine().ToUpper();
            escreve.WriteLine(cargo);
            Console.WriteLine("Informe o salário do funcionário:");
            salario = Console.ReadLine().ToUpper();
            escreve.WriteLine(salario);
            escreve.WriteLine("¢");
            escreve.Close();
            Console.WriteLine("\nCadastro realizado com sucesso!\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
        //Função cadastrar quarto
        public static void quart()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CADASTRAR QUARTO:\n");
            Console.ResetColor();
            string numero, qnthospedes, valord, status;
            int op;
            StreamWriter escreve;
            if (File.Exists("Quarto.txt"))
            {
                escreve = File.AppendText("Quarto.txt");
            }
            else
            {
                escreve = File.CreateText("Quarto.txt");
            }
            escreve.Close();// ACRESCENTADO
            Console.WriteLine("Informe o número do quarto:");
            numero = Console.ReadLine().ToUpper();

            string[] arrLine = File.ReadAllLines("Quarto.txt");
            int condicao = 0;
            for (int i = 0; i < arrLine.Length; i++)
            {
                if (arrLine[i] == "¬" && arrLine[i - 3] == numero)
                {
                    condicao++;
                    Console.WriteLine("\nJá existe um quarto cadastrado com o número informado.");
                }
            }
            if (condicao==0)
            {
                Console.WriteLine("informe a quantidade de hóspedes:");
                qnthospedes = Console.ReadLine().ToUpper();
                Console.WriteLine("Informe o valor da diária:");
                valord = Console.ReadLine().ToUpper();
                do
                {
                    Console.WriteLine("Selecione o status do quarto:\n1 - Desocupado\n2 - Ocupado");
                    op = int.Parse(Console.ReadLine().ToUpper());
                    if (op == 1)
                        status = "DESOCUPADO";
                    else
                        status = "OCUPADO";
                } while (op != 1 && op != 2);
                escreve = File.AppendText("Quarto.txt");
                escreve.WriteLine(status);
                escreve.WriteLine(numero);
                escreve.WriteLine(qnthospedes);
                escreve.WriteLine(valord);
                escreve.WriteLine("¬");
                escreve.Close();
                Console.WriteLine("Cadastro realizado com sucesso!");

            }
            Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
        //Função excluir quarto
        public static void excluiquart()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("EXCLUIR QUARTO");
            Console.ResetColor();
            if (File.Exists("Quarto.txt"))
            {
                string numero;
                int cont = 0;
                Console.WriteLine("Informe o número do quarto:");
                numero = Console.ReadLine();
                string[] arrLine = File.ReadAllLines("Quarto.txt");
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (arrLine[i] == "DESOCUPADO" && arrLine[i + 1] == numero)
                    {
                        cont++;
                        arrLine[i] = "£§";
                        arrLine[i + 1] = "£§";
                        arrLine[i + 2] = "£§";
                        arrLine[i + 3] = "£§";
                        arrLine[i + 4] = "£§";
                        File.WriteAllLines("Quarto.txt", arrLine);
                        string line = null;
                        string line_to_delete = "£§";
                        using (StreamReader reader = new StreamReader("Quarto.txt"))
                        {
                            using (StreamWriter writer = new StreamWriter("Temporarioquarto.txt"))
                            {
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (String.Compare(line, line_to_delete) == 0)
                                        continue;

                                    writer.WriteLine(line);
                                }
                            }
                        }
                        File.Delete("Quarto.txt");
                        File.Move("Temporarioquarto.txt", "Quarto.txt");
                        Console.WriteLine("Quarto excluído com sucesso.");
                    }

                    if (arrLine[i] == "OCUPADO" && arrLine[i + 1] == numero)
                    {
                        cont++;
                        Console.WriteLine("Para excluir um quarto é necessário que ele esteja desocupado.");
                    }
                }
                if (cont==0)
                {
                    Console.WriteLine("Nenhum quarto com esse número foi cadastrado.");
                }
            }

            else
            {
                Console.WriteLine("\nNenhum quarto cadastrado.");
            }
            Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
        //Função cadastrar estadia
        public static void estadia()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CADASTRAR ESTADIAS:\n");
            Console.ResetColor();
            if (File.Exists("Quarto.txt") && File.Exists("Cliente.txt"))
            {
                StreamWriter escreve;
                if (File.Exists("Estadia.txt"))
                {
                    escreve = File.AppendText("Estadia.txt");
                }
                else
                {
                    escreve = File.CreateText("Estadia.txt");
                }
                string datainicial, datafinal, linhacliente,nome, hos;
                int diastotais;
                Console.WriteLine("Informe o nome do cliente:");
                nome = Console.ReadLine().ToUpper();
                StreamReader verificanome = new StreamReader("Cliente.txt");
                for (int i = 1; i!=0 ; i++)
                {
                    linhacliente = verificanome.ReadLine();
                    if (linhacliente==nome)
                    {
                        verificanome.Close();
                        Console.WriteLine("Informe a quantidade de hóspedes:");
                        hos = Console.ReadLine();
                        int hosint;
                        hosint = int.Parse(hos);
                        string[] arrLine = File.ReadAllLines("Quarto.txt");
                        for (int x = 0; x < arrLine.Length; x++)
                        {
                            int convertido=0;
                            
                            if (arrLine[x]== "DESOCUPADO")
                            {
                                convertido = int.Parse(arrLine[x + 2]);
                            }
                            if (arrLine[x] == "DESOCUPADO" && convertido >= hosint)
                            {
                                int numquarto;
                                arrLine[x] = "OCUPADO";
                                numquarto = int.Parse(arrLine[x + 1]);
                                Console.WriteLine("Informe a data de entrada: (Formato DD/MM/AAAA)");
                                datainicial = Console.ReadLine().ToUpper();
                                Console.WriteLine("Informe a data de saída: (Formato DD/MM/AAAA)");
                                datafinal = Console.ReadLine().ToUpper();
                                TimeSpan date = Convert.ToDateTime(datafinal) - Convert.ToDateTime(datainicial);
                                diastotais = date.Days;
                                funcoes.pfidelidade(nome, diastotais);
                                escreve.WriteLine(nome);
                                escreve.WriteLine(hos);
                                escreve.WriteLine(datainicial);
                                escreve.WriteLine(datafinal);
                                escreve.WriteLine(diastotais);
                                escreve.WriteLine(arrLine[x + 3]);
                                escreve.WriteLine(arrLine[x + 1]);
                                escreve.WriteLine("¬");
                                x = arrLine.Length;
                                escreve.Close();
                                Console.WriteLine("\nEstadia cadastrada com suscesso!");
                                Console.WriteLine("Número do quarto do cliente: " +numquarto);
                                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                                escreve.Close();
                            }
                            else if (x==arrLine.Length-1)
                            {
                                escreve.Close();
                                Console.WriteLine("Não existe quartos disponíveis!");
                                Console.WriteLine("Aperte alguma tecla para ir para o menu principal.");
                                
                            }
                            
                        }
                        File.WriteAllLines("Quarto.txt", arrLine);
                        i = -1;
                    }
                    if (linhacliente==null)
                    {
                        verificanome.Close();
                        escreve.Close();
                        Console.WriteLine("Cliente não cadastrado!");
                        Console.WriteLine("Aperte alguma tecla para ir para o menu principal.");
                        
                        i = -1;
                    }
                }
            }
            else
            {
                Console.WriteLine("Para cadastrar uma estádia é nescessário fazer antes o cadastro do cliente e do quarto.");
                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                
            }
            Console.ReadKey();
        }
        //Função que pesquisa cliente
        public static void pesquisacliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PESQUISAR CLIENTE:\n");
            Console.ResetColor();
            string linha,cliente;
            if (File.Exists("Cliente.txt"))
            {
                Console.WriteLine("Digíte o nome do cliente:");
                cliente = Console.ReadLine().ToUpper();
                StreamReader ler = new StreamReader("Cliente.txt");
                int verificador = 0;
                Console.Clear();
                do
                {
                    linha = ler.ReadLine();
                    if (linha == cliente)
                    {
                        verificador++;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("INFORMAÇÕES DO CLIENTE:\n");
                        Console.ResetColor();
                        Console.WriteLine("Nome: " + linha);
                        linha = ler.ReadLine();
                        Console.WriteLine("Código: " + linha);
                        linha = ler.ReadLine();
                        Console.WriteLine("Endereço: " + linha);
                        linha = ler.ReadLine();
                        Console.WriteLine("Telefone: " + linha);
                        
                    }
                    else if (linha == null&&verificador==0)
                    {
                        Console.WriteLine("Cliente não encontrado!");                       
                    }
                } while (linha!=null);
                
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
            }
            Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
        //Função que pesquisa funcionário
        public static void pesquisafuncionario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PESQUISAR FUNCIONÁRIO:\n");
            Console.ResetColor();
            string linha, funcionario;
            if (File.Exists("Funcionario.txt"))
            {
                Console.WriteLine("Digíte o nome do funcionário:");
                funcionario = Console.ReadLine().ToUpper();
                StreamReader ler = new StreamReader("Funcionario.txt");
                for (int i = 1; i != 0; i++)
                {
                    linha = ler.ReadLine();
                    if (linha == funcionario)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("INFORMAÇÕES DO FUNCIONÁRIO:");
                        Console.ResetColor();
                        Console.WriteLine("\nNome: " + linha);
                        linha = ler.ReadLine();
                        Console.WriteLine("Código: " + linha);
                        linha = ler.ReadLine();
                        Console.WriteLine("Telefone: " + linha);
                        linha = ler.ReadLine();
                        Console.WriteLine("Cargo: " + linha);
                        linha = ler.ReadLine();
                        double valor,valorpago;
                        valorpago = double.Parse(linha);
                        valor = valorpago;
                        string valordecimal = valor.ToString("N2");
                        Console.WriteLine("Salário: R$ " + valordecimal);
                        i = -1;
                        ler.Close();
                        Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                        Console.ReadKey();
                    }
                    else if (linha == null)
                    {
                        Console.WriteLine("Funcionário não encontrado!");
                        Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                        Console.ReadKey();
                        i = -1;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário cadastrado!");
                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                Console.ReadKey();
            }
            
        }
        //Função mostrar estadias de determinado cliente
        public static void pesquisarestadias()
        {
            string cliente,linha;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PESQUISA DE ESTADIAS:\n");
            Console.ResetColor();
            if (File.Exists("Estadia.txt"))
            {
                StreamReader ler = new StreamReader("Estadia.txt");
                Console.WriteLine("Digíte o nome do cliente:");
                cliente = Console.ReadLine().ToUpper();
                for (int i = 1, j = 0; i != 0; i++)
                {
                    linha = ler.ReadLine();
                    if (linha == cliente)
                    {
                        j++;
                        Console.WriteLine("\nEstadia encontrada.");
                        Console.WriteLine("Nome: " + linha);
                        Console.WriteLine("Quantidade de hóspedes: " + ler.ReadLine());
                        Console.WriteLine("Data de entrada: " + ler.ReadLine());
                        Console.WriteLine("Data de saída " + ler.ReadLine());
                        Console.WriteLine("Número de diarias: " + ler.ReadLine());
                        double valor;
                        valor = double.Parse(ler.ReadLine());
                        string valordecimal = valor.ToString("N2");
                        Console.WriteLine("Valor da diária: R$ " + valordecimal);
                        Console.WriteLine("Número do quarto: " + ler.ReadLine());
                    }
                    if (linha == null)
                    {
                        i = -1;
                    }
                    if (linha == null && j == 0)
                    {
                        Console.WriteLine("\nNão foram encontradas estadias em nome do cliente digitado.");
                        i = -1;
                    }
                }
                ler.Close();
                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nenhuma estadia cadastrada!");
                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                Console.ReadKey();
            }
        }
        //Função visualizar quartos
        public static void visualizarquartos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("VISUALIZAR QUARTOS:\n");
            Console.ResetColor();
            if (File.Exists("Quarto.txt"))
            {
                StreamReader quarto = new StreamReader("Quarto.txt");
                string linha, qtd;
                int cont = 0,contdisp=0,contocup=0;
                do
                {
                    qtd = quarto.ReadLine();
                    if (qtd == "¬")
                    {
                        cont++;
                    }
                    if (qtd == "OCUPADO")
                    {
                        contocup++;
                    }
                    if (qtd == "DESOCUPADO")
                    {
                        contdisp++;
                    }
                } while (qtd != null);
                quarto.Close();
                Console.WriteLine("Quantidade de quartos cadastrados:" + cont);
                Console.WriteLine("Quantidade de quartos desocupados:" + contdisp);
                Console.WriteLine("Quantidade de quartos ocupados:" + contocup);
                StreamReader quarto2 = new StreamReader("Quarto.txt");
                do
                {
                    linha = quarto2.ReadLine();
                    if (linha == "DESOCUPADO" || linha == "OCUPADO")
                    {
                        double valor;
                        Console.Write("\n");
                        if (linha == "OCUPADO")
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("STATUS: "+ linha);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("STATUS: " + linha);
                            Console.ResetColor();
                        }
                        Console.WriteLine("Número: " + quarto2.ReadLine());
                        Console.WriteLine("Quantidade de hóspedes: " + quarto2.ReadLine());
                        valor= double.Parse(quarto2.ReadLine());
                        string valordecimal = valor.ToString("N2");
                        Console.WriteLine("Valor da diária: R$ " + valordecimal);
                    }
                } while (linha != null);
                quarto2.Close();
            }
            else
            {
                Console.WriteLine("Nenhum quarto cadastrado.");
            }
            Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
        //Função baixa em estadia 
        public static void baixaestadia()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BAIXA EM ESTADIA:\n");
            Console.ResetColor();
            if (File.Exists("Estadia.txt"))
            {
                string nome, quarto, numquarto;
                double valorpago, dias, diaria;
                Console.WriteLine("Insira o nome do cliente:");
                nome = Console.ReadLine().ToUpper();
                Console.WriteLine("Insira o número do quarto:");
                quarto = Console.ReadLine().ToUpper();
                string[] arrLine = File.ReadAllLines("Estadia.txt");
                int cont = 0;
                for (int x = 0; x < arrLine.Length; x++)
                {
                    
                    if (arrLine[x] == (nome) && arrLine[x + 6] == (quarto))
                    {
                        cont++;
                        diaria = double.Parse(arrLine[x + 5]);
                        dias = double.Parse(arrLine[x + 4]);
                        valorpago = diaria * dias;
                        numquarto = arrLine[x + 6];
                        arrLine[x] = "£§";
                        arrLine[x + 1] = "£§";
                        arrLine[x + 2] = "£§";
                        arrLine[x + 3] = "£§";
                        arrLine[x + 4] = "£§";
                        arrLine[x + 5] = "£§";
                        arrLine[x + 6] = "£§";
                        arrLine[x + 7] = "£§";
                        funcoes.mudastatus(numquarto);
                        File.WriteAllLines("Estadia.txt", arrLine);
                        double valor;
                        valor = valorpago;
                        string valordecimal = valor.ToString("N2");
                        Console.WriteLine("Valor total a ser pago: R$: " + valordecimal);
                        Console.ReadKey();

                        string line = null;
                        string line_to_delete = "£§";

                        using (StreamReader reader = new StreamReader("Estadia.txt"))
                        {
                            using (StreamWriter writer = new StreamWriter("Temporario.txt"))
                            {
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (String.Compare(line, line_to_delete) == 0)
                                        continue;

                                    writer.WriteLine(line);
                                }
                            }
                        }
                        File.Delete("Estadia.txt");
                        File.Move("Temporario.txt", "Estadia.txt");
                        Console.WriteLine("\nBaixa realizada com sucesso!");           
                    }
                }
                if (cont == 0)
                {
                    Console.WriteLine("\nDados informados não estão corretos.");
                }
                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Nenhuma estadia cadastrada!");
                Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
                Console.ReadKey();
            }

        }
        //Função mudar status do quarto
        public static void mudastatus(string x)
        {   // x n° do quarto
            string[] arrLine = File.ReadAllLines("Quarto.txt");

            for (int i = 0; i < arrLine.Length; i++)
            {
                if (arrLine[i] == x && arrLine[i - 1] == "OCUPADO")
                {
                    arrLine[i - 1] = "DESOCUPADO";
                    
                }                
            }
            File.WriteAllLines("Quarto.txt", arrLine);
        }
        //Função pontos de fidelidade CRIAR
        public static void pfidelidade(string x,int y)
        {
            //testar possibilidade de cadastrar por codigo
            int dias, pnts, somadias = 0, somapontos = 0,verificador=0;
            string linha;
            FileStream arq = new FileStream("Pfidelidade.txt", FileMode.OpenOrCreate);
            StreamReader ler = new StreamReader(arq);
            do
            {
                linha = ler.ReadLine();
                if (linha==x)
                {           
                    pnts = int.Parse(ler.ReadLine());
                    dias = int.Parse(ler.ReadLine());
                    ler.Close();
                    string[] arrLine = File.ReadAllLines("Pfidelidade.txt");

                    for (int i = 0; i < arrLine.Length; i++)
                    {
                        if (arrLine[i] == x)
                        {
                            verificador++;
                            int diassalvo, pontosalvo;
                            pontosalvo= int.Parse(arrLine[i + 1]);
                            diassalvo = int.Parse(arrLine[i + 2]);
                            somadias = diassalvo + y;
                            somapontos = pontosalvo + (y * 10);
                            arrLine[i + 1] = Convert.ToString(somapontos);
                            arrLine[i + 2] = Convert.ToString(somadias);
                            File.WriteAllLines("Pfidelidade.txt", arrLine);
                            linha = null;
                        }
                    }
                }
            } while (linha!=null);
            ler.Close();
            if (verificador == 0)
            {
                StreamWriter escreve;
                escreve = File.AppendText("Pfidelidade.txt");
                escreve.WriteLine(x);
                escreve.WriteLine(y * 10);
                escreve.WriteLine(y);
                escreve.Close();
            }
        }
        //Função mostrar pontos de fidelidade
        public static void mostrarpontos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PROGRAMA DE FIDELIDADE:\n");
            Console.ResetColor();
            if (File.Exists("Pfidelidade.txt"))
            {
                string nome,linha;
                Console.WriteLine("Informe o nome do cliente:");
                nome = Console.ReadLine().ToUpper();
                StreamReader ler = new StreamReader("Pfidelidade.txt");
                do
                {
                    int cont = 0;
                    linha = ler.ReadLine();
                    if (linha==nome)
                    {
                        cont++;
                        Console.Write("\n");
                        Console.WriteLine("Nome: " + linha);
                        Console.WriteLine("Pontos no programa de fidelidade: " + ler.ReadLine());
                        Console.WriteLine("Número de diárias: " + ler.ReadLine());
                        ler.Close();
                        linha = null;
                    }
                    if (cont == 0&&linha==null)
                    {
                        Console.WriteLine("\nCliente não cadastrado no programa de fidelidade.");
                    }
                } while (linha!=null);
            }
            
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado no programade fidelidade.");
            }
            Console.WriteLine("\nAperte alguma tecla para ir para o menu principal.");
            Console.ReadKey();
        }
    }
}