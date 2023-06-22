namespace App;

public class Program {
    public static void Main(string[] args) {
    double[][] inputs = {         //      AND | OR
        new double[] { 0, 0, 0 }, // output 0 | 0
        new double[] { 0, 0, 1 }, // output 0 | 1
        new double[] { 0, 1, 0 }, // output 0 | 1
        new double[] { 0, 1, 1 }, // output 0 | 1
        new double[] { 1, 0, 0 }, // output 0 | 1
        new double[] { 1, 0, 1 }, // output 0 | 1
        new double[] { 1, 1, 0 }, // output 0 | 1
        new double[] { 1, 1, 1 }, // output 1 | 1
    };

    double[] desiredAND = { 0, 0, 0, 0, 0, 0, 0, 1 };
    double[] desiredOR = { 0, 1, 1, 1, 1, 1, 1, 1 };

        var net = new Perceptron(inputs, 1_000, 0.01);

        net.Train(desiredOR);

        for (int i = 0; i < 4; i++) {
            Console.Write("Valor 1: ");
            double val1 = Double.Parse(Console.ReadLine());

            Console.Write("Valor 2: ");
            double val2 = Double.Parse(Console.ReadLine());

            Console.Write("Valor 3: ");
            double val3 = Double.Parse(Console.ReadLine());

            Console.WriteLine($"Retorno: {net.Activate(new double[] { val1, val2, val3 })}");
        }
    }
}