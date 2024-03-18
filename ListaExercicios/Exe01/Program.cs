Console.WriteLine("Digite a altura: ");
int altura = Int32.Parse(Console.ReadLine());

Console.WriteLine("Digite a largura: ");
int largura = Convert.ToInt32(Console.ReadLine());

int area = largura * altura;

Console.WriteLine($"Área: {area}");
Console.WriteLine("Área: " + area);
