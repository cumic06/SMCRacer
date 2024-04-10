public class MoneyManager : MonoSingleton<MoneyManager>
{
    public static int money;

    public void AddMoney(int value)
    {
        money += value;
        InGameUIManager.Instance.SetMoneyText($"{money:N0}��");
    }

    public void RemoveMoney(int value)
    {
        money -= value;
        InGameUIManager.Instance.SetMoneyText($"{money:N0}��");
    }
}
