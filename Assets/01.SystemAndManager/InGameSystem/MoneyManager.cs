public class MoneyManager : MonoSingleton<MoneyManager>
{
    public static int money;

    public void AddMoney(int value)
    {
        money += value;
        InGameUIManager.Instance.SetMoneyText($"{money:N0}¿ø");
    }

    public void RemoveMoney(int value)
    {
        money -= value;
        InGameUIManager.Instance.SetMoneyText($"{money:N0}¿ø");
    }
}
