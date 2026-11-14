/*
 * O programa implementa a seleção aleatória apenas de palavras que ainda não foram ocultadas (evitando sortear palavras repetidas) 
 * e utiliza uma biblioteca/estrutura organizada com classes bem encapsuladas, integrando um menu interativo com obras-padrão,
 * os Dez Mandamentos e as Regras de Fé.
*/

using System;
using System.Collections.Generic;

namespace MemorizadorEscrituras
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Escritura>> bibliotecaObras = new Dictionary<string, List<Escritura>>
            {
                {
                    "Velho Testamento", new List<Escritura>
                    {
                        new Escritura(new Referencia("Gênesis", 1, 26, 27), "E disse Deus: Façamos o homem à nossa imagem, conforme a nossa semelhança; e domine sobre os peixes do mar, e sobre as aves dos céus, e sobre o gado, e sobre toda a terra, e sobre todo réptil que se move sobre a terra. E criou Deus o homem à sua imagem, à imagem de Deus o criou, macho e fêmea os criou."),
                        new Escritura(new Referencia("Isaías", 9, 6), "Porque um menino nos nasceu, um filho se nos deu, e o principado está sobre os seus ombros, e o seu nome se chamará Maravilhoso, Conselheiro, Deus Forte, Pai da Eternidade, Príncipe da Paz."),
                        new Escritura(new Referencia("Provérbios", 3, 5, 6), "Confia no Senhor de todo o teu coração, e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas."),
                    }
                },
                {
                    "Novo Testamento", new List<Escritura>
                    {
                        new Escritura(new Referencia("Lucas", 2, 10, 11), "E o anjo lhes disse: Não temais, porque eis aqui vos trago novas de grande alegria, que será para todo o povo. Pois hoje, na cidade de Davi, vos nasceu o Salvador, que é Cristo, o Senhor."),
                        new Escritura(new Referencia("João", 3, 16, 17), "Porque Deus amou o mundo de tal maneira, que deu o seu Filho Unigênito, para que todo aquele que nele crê não pereça, mas tenha a vida eterna. Porque Deus enviou o seu Filho ao mundo, não para que condenasse o mundo, mas para que o mundo fosse salvo por ele."),
                        new Escritura(new Referencia("1 Coríntios", 6, 19, 20), "Ou não sabeis que o vosso corpo é o templo do Espírito Santo, que habita em vós, o qual tendes da parte de Deus, e que não sois de vós mesmos? Porque fostes comprados por um preço; glorificai, pois, a Deus no vosso corpo, e no vosso espírito, os quais pertencem a Deus."),
                    }
                },
                {
                    "Livro de Mórmon", new List<Escritura>
                    {
                        new Escritura(new Referencia("1 Néfi", 3, 7), "E aconteceu que eu, Néfi, disse a meu pai: Eu irei e cumprirei as ordens do Senhor, porque sei que o Senhor nunca dá ordens aos filhos dos homens sem antes preparar um caminho pelo qual suas ordens possam ser cumpridas."),
                        new Escritura(new Referencia("2 Néfi", 2, 25), "Adão caiu para que os homens existissem; e os homens existem para que tenham alegria."),
                        new Escritura(new Referencia("Mosias", 2, 17), "E eis que vos digo estas coisas para que aprendais sabedoria; para que saibais que, quando estais a serviço de vosso próximo, estais somente a serviço de vosso Deus."),
                    }
                },
                {
                    "Doutrina e Convênios", new List<Escritura>
                    {
                        new Escritura(new Referencia("Doutrina e Convênios", 4, 2), "Portanto, ó vós que embarcais no serviço de Deus, vede que o sirvais de todo o coração, poder, mente e força, para que vos apresenteis sem culpa perante Deus no último dia."),
                        new Escritura(new Referencia("Doutrina e Convênios", 18, 10), "Lembrai-vos de que o valor das almas é grande à vista de Deus;"),
                        new Escritura(new Referencia("Doutrina e Convênios", 89, 18, 20), "E todos os santos que se lembrarem de guardar e fazer estas coisas, obedecendo aos mandamentos, receberão saúde para o umbigo e medula para os ossos; (...) E correrão e não se cansarão; e caminharão e não desfalecerão."),
                    }
                },
                {
                    "Pérola de Grande Valor", new List<Escritura>
                    {
                        new Escritura(new Referencia("Moisés", 1, 39), "Pois eis que esta é minha obra e minha glória: Levar a efeito a imortalidade e vida eterna do homem."),
                        new Escritura(new Referencia("Abraão", 2, 9), "E farei de ti uma grande nação, e abençoar-te-ei sobremaneira, e engrandecerei o teu nome entre todas as nações; e serás uma bênção para tua semente depois de ti, para que em suas mãos levem este ministério e Sacerdócio a todas as nações;"),
                        new Escritura(new Referencia("Abraão", 3, 22, 23), "Ora, o Senhor mostrara a mim, Abraão, as inteligências que foram organizadas antes de o mundo existir; e entre todas essas havia muitas das nobres e grandes; E Deus viu que essas almas eram boas; e ele estava no meio delas e disse: A estes farei meus governantes; pois ele se encontrava entre aqueles que eram espíritos, e viu que eles eram bons; e disse-me: Abraão, tu és um deles; foste escolhido antes de nasceres."),
                    }
                },
                {
                    "Os Dez Mandamentos", new List<Escritura>
                    {
                        new Escritura(new Referencia("Êxodo", 20, 3), "Não terás outros deuses diante de mim."),
                        new Escritura(new Referencia("Êxodo", 20, 4, 6), "Não farás para ti imagem de escultura, nem semelhança alguma do que há em cima nos céus, nem embaixo na terra, nem nas águas debaixo da terra. (...) E faço misericórdia a milhares, aos que me amam, e aos que guardam os meus mandamentos."),
                        new Escritura(new Referencia("Êxodo", 20, 7), "Não tomarás o nome do Senhor teu Deus em vão, porque o Senhor não terá por inocente o que tomar o seu nome em vão."),
                        new Escritura(new Referencia("Êxodo", 20, 8, 11), "Lembra-te do dia do sábado, para o santificar. (...) Porque em seis dias fez o Senhor os céus e a terra, o mar e tudo que neles há, e ao sétimo dia descansou; portanto, abençoou o Senhor o dia do sábado, e o santificou."),
                        new Escritura(new Referencia("Êxodo", 20, 12), "Honra teu pai e tua mãe, para que os teus dias se prolonguem na terra que o Senhor teu Deus te dá."),
                        new Escritura(new Referencia("Êxodo", 20, 13), "Não matarás."),
                        new Escritura(new Referencia("Êxodo", 20, 14), "Não adulterarás."),
                        new Escritura(new Referencia("Êxodo", 20, 15), "Não furtarás."),
                        new Escritura(new Referencia("Êxodo", 20, 16), "Não dirás falso testemunho contra o teu próximo."),
                        new Escritura(new Referencia("Êxodo", 20, 17), "Não cobiçarás a casa do teu próximo, não cobiçarás a mulher do teu próximo, nem o seu servo, nem a sua serva, nem o seu boi, nem o seu jumento, nem coisa alguma do teu próximo."),
                    }
                },
                {
                    "As Regras de Fé", new List<Escritura>
                    {
                        new Escritura(new Referencia("Regras de Fé", 1, 1), "Cremos em Deus, o Pai Eterno, e em seu Filho, Jesus Cristo, e no Espírito Santo."),
                        new Escritura(new Referencia("Regras de Fé", 1, 2), "Cremos que os homens serão punidos por seus próprios pecados e não pela transgressão de Adão."),
                        new Escritura(new Referencia("Regras de Fé", 1, 3), "Cremos que, por meio da Expiação de Cristo, toda a humanidade pode ser salva, pela obediência às leis e ordenanças do Evangelho."),
                        new Escritura(new Referencia("Regras de Fé", 1, 4), "Cremos que os primeiros princípios e ordenanças do Evangelho são: primeiro, Fé no Senhor Jesus Cristo; segundo, Arrependimento; terceiro, Batismo por imersão para a remissão de pecados; quarto, Imposição de mãos para o dom do Espírito Santo."),
                        new Escritura(new Referencia("Regras de Fé", 1, 5), "Cremos que um homem deve ser chamado por Deus, por profecia, e pela imposição de mãos, por quem possua autoridade, para pregar o Evangelho e administrar as suas ordenanças."),
                        new Escritura(new Referencia("Regras de Fé", 1, 6), "Cremos na mesma organização que existia na Igreja Primitiva, isto é, apóstolos, profetas, pastores, mestres, evangelistas, etc."),
                        new Escritura(new Referencia("Regras de Fé", 1, 7), "Cremos no dom de línguas, profecia, revelação, visões, cura, interpretação de línguas, etc."),
                        new Escritura(new Referencia("Regras de Fé", 1, 8), "Cremos ser a Bíblia a palavra de Deus, desde que esteja traduzida corretamente; também cremos ser o Livro de Mórmon a palavra de Deus."),
                        new Escritura(new Referencia("Regras de Fé", 1, 9), "Cremos em tudo o que Deus revelou, em tudo o que Ele revela agora, e cremos que Ele ainda revelará muitas coisas grandiosas e importantes relativas ao Reino de Deus."),
                        new Escritura(new Referencia("Regras de Fé", 1, 10), "Cremos na coligação literal de Israel e na restauração das Dez Tribos; que Sião (a Nova Jerusalém) será construída no continente americano; que Cristo reinará pessoalmente na Terra; e que a Terra será renovada e receberá a sua glória paradisíaca."),
                        new Escritura(new Referencia("Regras de Fé", 1, 11), "Pretendemos o privilégio de adorar a Deus Todo-Poderoso de acordo com os ditames de nossa própria consciência; e concedemos a todos os homens o mesmo privilégio, deixando-os adorar como, onde, ou o que desejarem."),
                        new Escritura(new Referencia("Regras de Fé", 1, 12), "Cremos na submissão a reis, presidentes, governantes, e magistrados; na obediência, honra, e manutenção da lei."),
                        new Escritura(new Referencia("Regras de Fé", 1, 13), "Cremos em ser honestos, verdadeiros, castos, benevolentes, virtuosos, e em fazer o bem a todos os homens; na realidade, podemos dizer que seguimos a admoestação de Paulo: Cremos em todas as coisas, confiamos em todas as coisas, suportamos muitas coisas e esperamos ter a capacidade de tudo suportar. Se houver qualquer coisa virtuosa, amável, de boa fama ou louvável, nós a procuraremos."),
                    }
                }
            };

            List<string> chavesObras = new List<string>(bibliotecaObras.Keys);
            Escritura escrituraSelecionada = null;

            while (escrituraSelecionada == null)
            {
                Console.Clear();
                Console.WriteLine("=== MENU DE OBRAS-PADRÃO E PRINCÍPIOS ===");
                for (int i = 0; i < chavesObras.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {chavesObras[i]}");
                }
                Console.WriteLine("0. Sair");
                Console.Write("\nEscolha o número da categoria desejada: ");
                
                string inputObra = Console.ReadLine();
                if (inputObra == "0") return;

                if (int.TryParse(inputObra, out int escolhaObra) && escolhaObra >= 1 && escolhaObra <= chavesObras.Count)
                {
                    string obraEscolhida = chavesObras[escolhaObra - 1];
                    List<Escritura> listaVersiculos = bibliotecaObras[obraEscolhida];

                    while (escrituraSelecionada == null)
                    {
                        Console.Clear();
                        Console.WriteLine($"=== {obraEscolhida.ToUpper()} ===");
                        for (int j = 0; j < listaVersiculos.Count; j++)
                        {
                            Console.WriteLine($"{j + 1}. {listaVersiculos[j].ObterReferenciaTexto()}");
                        }
                        Console.WriteLine("0. Voltar ao menu anterior");
                        Console.Write("\nEscolha o número do versículo/item desejado: ");

                        string inputVersiculo = Console.ReadLine();
                        if (inputVersiculo == "0") break;

                        if (int.TryParse(inputVersiculo, out int escolhaVersiculo) && escolhaVersiculo >= 1 && escolhaVersiculo <= listaVersiculos.Count)
                        {
                            escrituraSelecionada = listaVersiculos[escolhaVersiculo - 1];
                        }
                    }
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(escrituraSelecionada.ObterTexto());
                Console.WriteLine();

                if (escrituraSelecionada.EstaCompletamenteOculta())
                {
                    Console.WriteLine("Parabéns! Todas as palavras foram ocultadas.");
                    break;
                }

                Console.WriteLine("Pressione Enter para ocultar mais palavras ou digite 'sair' para encerrar:");
                string entrada = Console.ReadLine();

                if (entrada != null && entrada.Trim().ToLower() == "sair")
                {
                    break;
                }

                escrituraSelecionada.OcultarPalavrasAleatorias(3);
            }
        }
    }

    public class Referencia
    {
        private string _livro;
        private int _capitulo;
        private int _versiculo;
        private int _ultimoVersiculo;

        public Referencia(string livro, int capitulo, int versiculo)
        {
            _livro = livro;
            _capitulo = capitulo;
            _versiculo = versiculo;
            _ultimoVersiculo = versiculo;
        }

        public Referencia(string livro, int capitulo, int primeiroVersiculo, int ultimoVersiculo)
        {
            _livro = livro;
            _capitulo = capitulo;
            _versiculo = primeiroVersiculo;
            _ultimoVersiculo = ultimoVersiculo;
        }

        public string ObterTexto()
        {
            if (_versiculo == _ultimoVersiculo)
            {
                return $"{_livro} {_capitulo}:{_versiculo}";
            }
            else
            {
                return $"{_livro} {_capitulo}:{_versiculo}-{_ultimoVersiculo}";
            }
        }
    }

    public class Palavra
    {
        private string _texto;
        private bool _estaOculta;

        public Palavra(string texto)
        {
            _texto = texto;
            _estaOculta = false;
        }

        public void Ocultar()
        {
            _estaOculta = true;
        }

        public void Exibir()
        {
            _estaOculta = false;
        }

        public bool EstaOculta()
        {
            return _estaOculta;
        }

        public string ObterTexto()
        {
            if (_estaOculta)
            {
                return new string('_', _texto.Length);
            }
            else
            {
                return _texto;
            }
        }
    }

    public class Escritura
    {
        private Referencia _referencia;
        private List<Palavra> _palavras;

        public Escritura(Referencia referencia, string texto)
        {
            _referencia = referencia;
            _palavras = new List<Palavra>();

            string[] pedacos = texto.Split(' ');
            foreach (var pedaco in pedacos)
            {
                _palavras.Add(new Palavra(pedaco));
            }
        }

        public void OcultarPalavrasAleatorias(int numeroParaOcultar)
        {
            Random random = new Random();
            int ocultadas = 0;

            while (ocultadas < numeroParaOcultar && !EstaCompletamenteOculta())
            {
                List<Palavra> disponiveis = new List<Palavra>();
                foreach (var p in _palavras)
                {
                    if (!p.EstaOculta())
                    {
                        disponiveis.Add(p);
                    }
                }

                if (disponiveis.Count == 0) break;

                int indiceAleatorio = random.Next(disponiveis.Count);
                disponiveis[indiceAleatorio].Ocultar();
                ocultadas++;
            }
        }

        public string ObterReferenciaTexto()
        {
            return _referencia.ObterTexto();
        }

        public string ObterTexto()
        {
            List<string> partes = new List<string>();
            foreach (var palavra in _palavras)
            {
                partes.Add(palavra.ObterTexto());
            }

            string textoCombinado = string.Join(" ", partes);
            return $"{_referencia.ObterTexto()} - {textoCombinado}";
        }

        public bool EstaCompletamenteOculta()
        {
            foreach (var palavra in _palavras)
            {
                if (!palavra.EstaOculta())
                {
                    return false;
                }
            }
            return true;
        }
    }
}