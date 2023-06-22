namespace App;

public class Perceptron {
    public double[][] TrainingSet { get; set; }
    public double[] Weights { get; set; }
    public double Bias { get; set; }
    public double LearningRate { get; set; }
    public int Iteractions { private get; set; }

    private Random rand = new Random();

    public Perceptron(double[][] trainingSet, int iteractions, double learningRate) {
        TrainingSet = trainingSet;
        Iteractions = iteractions;
        LearningRate = learningRate;
        Weights = new double[trainingSet[0].Length];

        InitWeights();
    }

    private void InitWeights() {
        for (int i = 0; i < Weights.Length; i++) {
            Weights[i] = rand.NextDouble();
            Console.WriteLine($"Weights: {Weights[i]}");
        }

        Bias = rand.NextDouble();
        Console.WriteLine($"Bias: {Bias}");
    }

    private double Sigmoid(double x) => 1 / (1 + Math.Exp(-1 * x));

    private double Run(double[] inputs) {
        var sum = Bias;

        for (int i = 0; i < Weights.Length; i++) {
            sum += (inputs[i] * Weights[i]);
        }

        return Sigmoid(sum);
    }

    public bool Train(double[] desired) {
        var count = 0;

        do {
            for (int i = 0; i < TrainingSet.Length; i++) {
                var y = Run(TrainingSet[i]);
                // Fix weights
                for (int j = 0; j < Weights.Length; j++) {
                    Weights[j] += (LearningRate * (desired[i] - y) * TrainingSet[i][j]);
                }

                Bias += (desired[i] - y);
            }
            count++;
        } while (count < Iteractions);

        return true;
    }

    public int Activate(double[] inputs) => (int)Math.Round(Run(inputs), 0); // 1 if > 0.5
}