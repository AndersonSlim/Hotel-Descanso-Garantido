using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*  Programador: Anderson Miguel
 *  Data: 12/11/2016
 *  Descrição: Trabalho - Hotel Descanso Garantido
 */
namespace Hotel_Descanso_Garantido
{

    class Program
    {
        static void Main(string[] args)
        {
            int op;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("HOTEL DESCANSO GARANTIDO:");
                Console.ResetColor();
                Console.WriteLine("1 - Cadastrar cliente\n2 - Cadastrar funcionário\n3 - Cadastrar estadia\n4 - Realizar Pesquisas\n5 - Gerenciar quartos\n6 - Baixa em estadia\n0 - Sair ");
                op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 0:
                    break;
                case 1:
                    funcoes.client();
                    break;
                case 2:
                    funcoes.funcionari();
                    break;
                case 3:
                        funcoes.estadia();
                    break;
                case 4:
                        int op2=0;//consertar condição de repetição
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("MENU DE PESQUISAS:");
                            Console.ResetColor();
                            Console.WriteLine("1 - Pesquisar cliente\n2 - Pesquisar Funcionário\n3 - Pesquisar estadias\n4 - Programa de fidelidade\n5 - Voltar");
                            op2 = int.Parse(Console.ReadLine());
                            if (op2 != 1 && op2 != 2&& op2 != 3&& op2 != 4)
                                Console.WriteLine("Digíte uma opção válida!");
                        } while (op2 != 1 && op2 != 2&& op2 != 3&& op2 != 4&&op2!=5);
                         if (op2 == 1)
                        {
                            funcoes.pesquisacliente();
                        }          
                         else if(op2==2)
                        {
                            funcoes.pesquisafuncionario();
                        }
                         else if(op2==3)
                        {
                            funcoes.pesquisarestadias();
                        }
                        else if (op2==4)
                        {
                            funcoes.mostrarpontos();
                        } 
                         else if (op2==5)
                        {
                            // aki volta pro menu principal
                        }
                        break;
                    case 5:
                        int op3;
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("GERENCIAR DE QUARTOS:");
                            Console.ResetColor();
                            Console.WriteLine("1 - Cadastrar quarto\n2 - Excluir quarto\n3 - Visualizar quartos\n4 - Voltar");
                            op3 = int.Parse(Console.ReadLine());
                            if (op3 == 1)
                            {
                                funcoes.quart();
                            }
                            else if (op3 == 2)
                            {
                                funcoes.excluiquart();
                            }
                            else if (op3 == 3)
                            {
                                funcoes.visualizarquartos();
                            }
                            else if (op3 == 4)
                            {
                                //volta menu
                            }
                        } while (op3 != 4);
                        break;
                    case (6):
                        funcoes.baixaestadia();
                        break;
                    default:
                    break;
            }
            } while (op!=0);
        }
    }
}
