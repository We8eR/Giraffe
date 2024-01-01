public sealed class Item { /* ... */ }

public sealed class ShoppingCart
{
    private List<Item> m_cart = new List<Item>();
    private Decimal m_totalCost = 0;

    public ShoppingCart() { 
    }
    public void AddItem(Item item)
    {
        AddItemHelper(m_cart, item, ref m_totalCost);
    }
    private static void AddItemHelper(
        List<Item> m_cart, Item newItem, ref Decimal totalCost)
    {
        Contract.Requires(newItem != null);
        Contract.Requires(Contract.ForAll(m_cart, s => s != newItem));

        Contract.Ensures(Contract.Exists(m_cart, s => s == newItem));
        Contract.Ensures(totalCost >= Contract.OldValue(totalCost));
        Contract.EnsuresOnThrow<IOException>(totalCost == Contract.OldValue(totalCost));

        m_cart.Add(newItem);
        totalCost += 1.00М;

    }
    private void ObjectInvariant()
    {
        Contract.Invariant(m_totalCost >= 0);
    }
}