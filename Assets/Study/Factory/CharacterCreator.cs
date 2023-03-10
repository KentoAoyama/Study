/// <summary>
///  FactoryのCreatorにあたる抽象クラス
/// </summary>
public abstract class CharactorCreator
{
    //これがFactoryMethod
    public abstract Character Create(string name, int damage);
}