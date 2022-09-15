using System;

namespace SalaryCalculator {
    class Program {
        static void Main(string[] args) {
            double grossSalary;

            Console.WriteLine("Enter monthly gross salary to retrive your monthly net salary (integer or use '.' for decimal number):");
            while (!double.TryParse(Console.ReadLine(), out grossSalary)) Console.WriteLine("Input was not a number! Enter gross salary as integer to retrive net salary:");

            grossSalary = Math.Round(grossSalary, 2);
            double taxFreeIncome = calculateTaxFreeIncome(grossSalary);
            double savingsPension = calculateSavingsPension(grossSalary);
            double unemploymentInsurance = calculateUnemploymentInsurance(grossSalary);
            double tax = calculateTax(grossSalary, taxFreeIncome, savingsPension, unemploymentInsurance);
            double netSalary = calculateNetSalary(grossSalary, tax, savingsPension, unemploymentInsurance);

            Console.WriteLine($"Your monthly net salary is {netSalary}");
            Console.WriteLine($"Your monthly tax payment is {tax}");
            Console.WriteLine($"Your monthly tax-free income is {taxFreeIncome}");
            Console.WriteLine($"Your monthly savings pension payment is {savingsPension}");
            Console.WriteLine($"Your monthly unemmployment insurance payment is {unemploymentInsurance}");
        }

        static double calculateNetSalary(double grossSalary, double tax, double savingsPension, double unemploymentInsurance) {
            return Math.Round((grossSalary - tax - savingsPension - unemploymentInsurance), 2);
        }

        static double calculateTaxFreeIncome(double grossSalary) {
            if (grossSalary <= 1200) {
                return 500;
            } else if (grossSalary >= 1201 && grossSalary <= 2099) {
                return Math.Round((500 - 0.55556 * (grossSalary - 1200)), 2);
            } else {
                return 0;
            }
        }

        static double calculateSavingsPension(double grossSalary) {
            return Math.Round((grossSalary * 0.02), 2);
        }

        static double calculateUnemploymentInsurance(double grossSalary) {
            return Math.Round((grossSalary * 0.016), 2);
        }

        static double calculateTax(double grossSalary, double taxFreeIncome, double savingsPension, double unemploymentInsurance) {
            return Math.Round(((grossSalary - taxFreeIncome - savingsPension - unemploymentInsurance) * 0.2), 2);
        }
    }
}
