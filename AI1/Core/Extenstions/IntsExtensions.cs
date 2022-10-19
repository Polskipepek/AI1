namespace AI1.Infrastructure.Extenstions {
    internal static class IntsExtensions {
        public static double CalcMean(this IEnumerable<int> numbers) => numbers.Average();

        public static double CalcTruncatedMean(this IEnumerable<int> numbers) {
            var numbersCount = numbers.Count();
            var orderedNumbers = numbers.OrderBy(x => x).ToList();

            for (int i = 0; i < numbersCount * .25f; i++) {
                orderedNumbers.RemoveAt(i);
                orderedNumbers.RemoveAt(orderedNumbers.Count - 1);
            }
            return orderedNumbers.Average();
        }

        public static int CalcDominant(this IEnumerable<int> numbers) {
            var numberIncidence = new Dictionary<int, int>();

            foreach (var num in numbers) {
                if (numberIncidence.ContainsKey(num)) {
                    numberIncidence[num]++;
                } else {
                    numberIncidence.Add(num, 1);
                }
            }
            return numberIncidence.MaxBy(x => x.Value).Key;
        }

        public static int CalcMedian(this IEnumerable<int> numbers) {
            var list = numbers.OrderBy(x => x).ToList();
            return list.Count % 2 == 0
                ? (list.IndexOf(list.Count / 2 - 1) + list.IndexOf(list.Count / 2)) / 2
                : list.IndexOf(list.Count / 2);
        }

        public static double CalcVariance(this IEnumerable<int> numbers) {
            double mean = numbers.CalcMean();
            double variance = 0;

            foreach (var number in numbers) {
                variance += Math.Pow(number - mean, 2);
            }
            variance /= numbers.Count();
            return variance;
        }

        public static double CalcStandardDevation(this IEnumerable<int> numbers) => Math.Sqrt(numbers.CalcVariance());

        public static double CalcPercentile(this IEnumerable<int> numbers, double p) {
            var sortedData = numbers.OrderBy(x => x).ToList();

            if (p >= 100.0d) return sortedData[^1];

            double position = (sortedData.Count + 1) * p / 100.0;
            double leftNumber = 0.0d, rightNumber = 0.0d;

            double n = p / 100.0d * (sortedData.Count - 1) + 1.0d;

            if (position >= 1) {
                leftNumber = sortedData[(int)Math.Floor(n) - 1];
                rightNumber = sortedData[(int)Math.Floor(n)];
            } else {
                leftNumber = sortedData[0];
                rightNumber = sortedData[1];
            }

            if (Equals(leftNumber, rightNumber))
                return leftNumber;
            double part = n - Math.Floor(n);
            return leftNumber + part * (rightNumber - leftNumber);
        }
    }
}
