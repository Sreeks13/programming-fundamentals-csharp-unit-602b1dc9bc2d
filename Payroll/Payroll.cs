namespace Payroll;

public interface IPayable
{
    decimal CalculatePay();
    string GetPayslipLine();
}

public class SalariedEmployee : IPayable
{
    private readonly decimal salary;

    public SalariedEmployee(decimal salary)
    {
        this.salary = salary;
    }

    public decimal CalculatePay()
    {
        return salary;
    }

    public string GetPayslipLine()
    {
        return $"Salaried: {CalculatePay():0.00}";
    }
}

public class HourlyEmployee : IPayable
{
    private readonly decimal hourlyRate;
    private readonly decimal hoursWorked;

    public HourlyEmployee(decimal hourlyRate, decimal hoursWorked)
    {
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    public decimal CalculatePay()
    {
        return hourlyRate * hoursWorked;
    }

    public string GetPayslipLine()
    {
        return $"Hourly: {CalculatePay():0.00}";
    }
}

public static class PayrollProcessor
{
    public static IReadOnlyList<string> GeneratePayslips(
        IEnumerable<IPayable> employees)
    {
        return employees
            .Select(employee => employee.GetPayslipLine())
            .ToList();
    }

    public static decimal CalculateTotal(IEnumerable<IPayable> employees)
    {
        return employees.Sum(employee => employee.CalculatePay());
    }
}