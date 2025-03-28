// See https://aka.ms/new-console-template for more information
using QR_Code;

Console.WriteLine("Hello, World!");

byte[] values = new Class1().GenQRCode("HELLOWORLDWHATSUPMOVINGYO");

for (int i = 0; i < values.Length;)
{
    for (int j = 0; j < 23; j++)
    {
        Console.Write(values[i].ToString());
        i++;
    }
    Console.WriteLine();
}

//foreach (byte value in values)
//{
//    Console.Write(Convert.ToString(value, 16) + " ");
//}