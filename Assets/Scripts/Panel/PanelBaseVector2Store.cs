public class PanelBaseVector2Store : PanelBaseVector2<PanelCellItem, PanelGridTownItem>
{
    public int NowCapacity = 0;

    public virtual void UpdateInfoByAdd(E_Item p_e_Item)
    {
        NowCapacity += Hot.BodyDicItem[p_e_Item].X * Hot.BodyDicItem[p_e_Item].Y;
    }

    public virtual void UpdateInfoByReduce(E_Item p_e_Item)
    {
        NowCapacity -= Hot.BodyDicItem[p_e_Item].X * Hot.BodyDicItem[p_e_Item].Y;
    }
}
